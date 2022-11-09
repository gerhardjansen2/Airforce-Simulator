using Airforce_Project.Classes;
using ProjectFormReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airforce_Project.Forms
{
    public partial class frmMapSimulation : Form
    {
        List<Jet> JetList = new List<Jet>();
        List<Point> TargetList = new List<Point>();
        Pen routePen = new Pen(Color.Lime);
        Graphics graphics = null;
        Timer jetTime = new Timer();
        public int routePoint { get; set; }
        public frmMapSimulation()
        {
            InitializeComponent();
            HideSubMenus();
            ResetSelectedObject();
            Obstacle_Information.ObstacleNumber = 0;
            JetProperties.CurrentSpeed = 300;
            JetProperties.CurrentAltitude = 0;
            JetProperties.CurrentWeight = 0;
            JetProperties.Jetselected = false;
            JetProperties.EnemyBaseScouted = false;

            TargetList.Add(pbOfficersQuarters.Location);
            TargetList.Add(pbTankDepo.Location);
            TargetList.Add(pbArmoury.Location);
            TargetList.Add(pbBarracks.Location);
            TargetList.Add(pbHospital.Location);

            SQL_Data_Connections SQLconn = new SQL_Data_Connections();
            JetList.AddRange(SQLconn.getJetList());

            btnJet1.Text = JetList[0].JetName;
            btnJet2.Text = JetList[1].JetName;
            btnJet3.Text = JetList[2].JetName;
            btnJet4.Text = JetList[3].JetName;
            btnJet5.Text = JetList[4].JetName;
            btnJet6.Text = JetList[5].JetName;

            Report_Information.NumberOfBuildingsBombed = 0;
            Report_Information.EnemyBaseBombed = false;
            Report_Information.EnemyBaseLocation = new Point(pbEnemyBase.Location.X + 20, pbEnemyBase.Location.Y + 20);
            Report_Information.ReportShown = false;
        }

        private void HideSubMenus()
        {
            pnlAddObsticleSubmenu.Visible = false;
            pnlSelectJetSubMenu.Visible = false;
            pnlSelectPayloadSubmenu.Visible = false;
        }

        private void HighlightButton(Button button) 
        {
            button.BackColor = Color.DarkOliveGreen;
        }

        private void ObstacleButtonDefault()
        {
            btnAddAntiAirGun.BackColor = Color.DimGray;
            btnAddAntiAirMissile.BackColor = Color.DimGray;
            btnAddRPGUnit.BackColor = Color.DimGray;
        }

        private void JetButtonDefault()
        {
            btnJet1.BackColor = Color.DimGray;
            btnJet2.BackColor = Color.DimGray;
            btnJet3.BackColor = Color.DimGray;
            btnJet4.BackColor = Color.DimGray;
            btnJet5.BackColor = Color.DimGray;
            btnJet6.BackColor = Color.DimGray;
        }

        private void ShowSubMenu(Panel Submenu) 
        {
            Submenu.Visible = true;
        }

       private void ResetSelectedObject()
        {
            Obstacle_Information.AntiAirGunSelect = false;
            Obstacle_Information.AntiAirMissileSelect = false;
            Obstacle_Information.RPGUnitSelect = false;
        }

        private void btnAddObsticle_Click(object sender, EventArgs e)
        {
            HideSubMenus();
            ShowSubMenu(pnlAddObsticleSubmenu);
        }

        private void btnSelectJet_Click(object sender, EventArgs e)
        {
            HideSubMenus();
            ShowSubMenu(pnlSelectJetSubMenu);
        }

        private void btnSelectPayload_Click(object sender, EventArgs e)
        {
            HideSubMenus();
            ShowSubMenu(pnlSelectPayloadSubmenu);
        }

        private void btnLaunchJet_Click(object sender, EventArgs e)
        {
            HideSubMenus();
            JetProperties.targetNumber = 0;
            var flightCalculations = new Flight_Calculations();
            var targetCalculations = new Target_Calculations();
            JetProperties.CurrentSramMissile = Convert.ToInt32(nudSRAMMissile.Value);
            JetProperties.CurrentHarmMisslie = Convert.ToInt32(nudHARMMissile.Value);
            JetProperties.CurrentBluBomb = Convert.ToInt32(nudBLUBomb.Value);
            JetProperties.CurrentGbuBomb = Convert.ToInt32(nudGBUBomb.Value);
            JetProperties.CurrentCargoNumber = flightCalculations.CalculateCurrrentCargoNumber(JetProperties.CurrentSramMissile, JetProperties.CurrentHarmMisslie, JetProperties.CurrentBluBomb, JetProperties.CurrentGbuBomb);
            JetProperties.CurrentWeight = flightCalculations.CalculateCurrrentWeight(JetProperties.CurrentSramMissile, JetProperties.CurrentHarmMisslie, JetProperties.CurrentBluBomb, JetProperties.CurrentGbuBomb);

            if (JetProperties.Jetselected == false)
            {
                MessageBox.Show(this, "Please select a Jet", "Jet not selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if ((JetProperties.CurrentWeight > JetProperties.SelectedMaxWeight) || (JetProperties.CurrentCargoNumber > JetProperties.SelectedCargoCapacity))
            {
                MessageBox.Show(this,"The current weight or cargo amount exceeds the selected jet's capacity. Please reduce the cargo.\n" + 
                                "Current Weight: \t \t" + JetProperties.CurrentWeight.ToString() + "\n" +
                                "Max Weight: \t \t" + JetProperties.SelectedMaxWeight.ToString() + "\n" +
                                "Current Cargo Number: \t" + JetProperties.CurrentCargoNumber.ToString() + "\n" +
                                "Cargo Capacity: \t \t" + JetProperties.SelectedCargoCapacity.ToString()
                                , "Jet capacity exceeded",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else 
            {
                btnAddObsticle.Enabled = false;
                btnSelectJet.Enabled = false;
                btnSelectPayload.Enabled = false;
                btnLaunchJet.Enabled = false;

                if (btnLaunchJet.Text == "Scout Enemy Base")
                {
                    Report_Information.WeightBefore = JetProperties.CurrentWeight;
                    Report_Information.FuelBefore = JetProperties.Fuel;
                    Report_Information.MissilesBefore = JetProperties.CurrentHarmMisslie + JetProperties.CurrentSramMissile;
                    Report_Information.BombsBefore = JetProperties.CurrentBluBomb + JetProperties.CurrentGbuBomb;
                }
                
                Route_Calculations.startPoint = pbFighterJet.Location;
                Route_Calculations.endPoint = targetCalculations.CalculateNextTarget(TargetList,pbEnemyBase.Location,JetProperties.CurrentCargoNumber,JetProperties.EnemyBaseScouted);
                var Route = new Route_Calculations();
        
                JetProperties.Fuel = 100;
                pbFighterJet.Visible = true;
                pbFighterJet.BringToFront();
                routePoint = 1;
                JetProperties.TargetBombed = false;
                int xIncrement, yIncrement, dXInterval, dYInterval, dX = 0, dY = 0;
                Point CurentPoint = new Point();
                CurentPoint = Route_Calculations.startPoint;
                Route.CalculateRoute();
                pnlMap.Refresh();

                jetTime.Tick += (senderO, a) =>
                {
                    var EnemyBasePoint = new Point(pbEnemyBase.Location.X + 20, pbEnemyBase.Location.Y + 20);
                    var AlliedBasePoint = new Point(pbAllyBase.Location.X + 20, pbAllyBase.Location.Y + 20);
                    var OfficerQuatersPoint = new Point(pbOfficersQuarters.Location.X + 20, pbOfficersQuarters.Location.Y + 20);
                    var TankDepoPoint = new Point(pbTankDepo.Location.X + 20, pbTankDepo.Location.Y + 20);
                    var ArmouryPoint = new Point(pbArmoury.Location.X + 20, pbArmoury.Location.Y + 20);
                    var BarracksPoint = new Point(pbBarracks.Location.X + 20, pbBarracks.Location.Y + 20);
                    var HospitalPoint = new Point(pbHospital.Location.X + 20, pbHospital.Location.Y + 20);

                    if (routePoint != Route_Calculations.RoutePoints.Count - 1)
                    {
                        if (pbFighterJet.Location == Route_Calculations.RoutePoints[routePoint])
                        {
                            CurentPoint = Route_Calculations.RoutePoints[routePoint];
                            routePoint += 1;
                        }
                        else
                        {
                            if (CurentPoint.X > Route_Calculations.RoutePoints[routePoint].X)
                            {
                                xIncrement = CurentPoint.X - Route_Calculations.RoutePoints[routePoint].X;
                                dXInterval = Convert.ToInt32(Math.Ceiling(xIncrement / 8.0));
                                dX = pbFighterJet.Location.X - dXInterval;
                            }
                            if (CurentPoint.X < Route_Calculations.RoutePoints[routePoint].X)
                            {
                                xIncrement = Route_Calculations.RoutePoints[routePoint].X - CurentPoint.X;
                                dXInterval = Convert.ToInt32(Math.Ceiling(xIncrement / 8.0));
                                dX = pbFighterJet.Location.X + dXInterval;
                            }

                            if (CurentPoint.Y > Route_Calculations.RoutePoints[routePoint].Y)
                            {
                                yIncrement = CurentPoint.Y - Route_Calculations.RoutePoints[routePoint].Y;
                                dYInterval = Convert.ToInt32(Math.Ceiling(yIncrement / 8.0));
                                dY = pbFighterJet.Location.Y - dYInterval;
                            }
                            if (CurentPoint.Y < Route_Calculations.RoutePoints[routePoint].Y)
                            {
                                yIncrement = Route_Calculations.RoutePoints[routePoint].Y - CurentPoint.Y;
                                dYInterval = Convert.ToInt32(Math.Ceiling(yIncrement / 8.0));
                                dY = pbFighterJet.Location.Y + dYInterval;
                            }

                            if (CurentPoint.X == Route_Calculations.RoutePoints[routePoint].X)
                            {
                                pbFighterJet.Location = new Point(pbFighterJet.Location.X, dY);
                                CurentPoint = pbFighterJet.Location;
                            }
                            if (CurentPoint.Y == Route_Calculations.RoutePoints[routePoint].Y)
                            {
                                pbFighterJet.Location = new Point(dX, pbFighterJet.Location.Y);
                                CurentPoint = pbFighterJet.Location;
                            }
                            else
                            {
                                pbFighterJet.Location = new Point(dX, dY);
                                CurentPoint = pbFighterJet.Location;
                            }

                        }
                        JetProperties.TargetBombed = false;
                    }
                    else
                    {
                        pbFighterJet.Location = Route_Calculations.endPoint;
                        if (JetProperties.CurrentCargoNumber > 0)
                        {
                            if ((pbFighterJet.Location == OfficerQuatersPoint) && (JetProperties.TargetBombed == false))
                            {
                                targetCalculations.SelectExplosiveToUse();
                                targetCalculations.BombBuilding(pbOfficersQuarters);
                            }
                            if ((pbFighterJet.Location == TankDepoPoint) && (JetProperties.TargetBombed == false))
                            {
                                targetCalculations.SelectExplosiveToUse();
                                targetCalculations.BombBuilding(pbTankDepo);
                            }
                            if ((pbFighterJet.Location == ArmouryPoint) && (JetProperties.TargetBombed == false))
                            {
                                targetCalculations.SelectExplosiveToUse();
                                targetCalculations.BombBuilding(pbArmoury);
                            }
                            if ((pbFighterJet.Location == BarracksPoint) && (JetProperties.TargetBombed == false))
                            {
                                targetCalculations.SelectExplosiveToUse();
                                targetCalculations.BombBuilding(pbBarracks);
                            }
                            if ((pbFighterJet.Location == HospitalPoint) && (JetProperties.TargetBombed == false))
                            {
                                targetCalculations.SelectExplosiveToUse();
                                targetCalculations.BombBuilding(pbHospital);
                            }
                        }
                        if (pbFighterJet.Location == Route_Calculations.endPoint)
                        {
                            jetTime.Stop();
                            if (Route_Calculations.endPoint == AlliedBasePoint)
                            {
                                btnLaunchJet.Text = "Bomb Enemy Base";
                                btnLaunchJet.Enabled = true;
                                if (Report_Information.EnemyBaseBombed == true)
                                {
                                    Report_Information.WeightAfter = JetProperties.CurrentWeight;
                                    Report_Information.FuelAfter = JetProperties.Fuel;
                                    Report_Information.MisslilesAfter = JetProperties.CurrentHarmMisslie + JetProperties.CurrentSramMissile;
                                    Report_Information.BombsAfter = JetProperties.CurrentBluBomb + JetProperties.CurrentGbuBomb;

                                    if (Report_Information.ReportShown == false)
                                    {
                                        Report_Information.ReportShown = true;
                                        var temp = new frmReportAnalysis();
                                        temp.Region = this.Region;
                                        temp.Show();
                                        this.Hide();
                                    }
                                    
                                }
                            }
                        }
                        
                        if ((Route_Calculations.endPoint != AlliedBasePoint) && (pbFighterJet.Location == Route_Calculations.endPoint))
                        {
                            Route_Calculations.startPoint = pbFighterJet.Location;
                            Route_Calculations.endPoint = targetCalculations.CalculateNextTarget(TargetList, pbAllyBase.Location, JetProperties.CurrentCargoNumber, JetProperties.EnemyBaseScouted);
                            routePoint = 1;
                            var newRoute = new Route_Calculations();
                            newRoute.CalculateRoute();
                            if (JetProperties.EnemyBaseScouted == false)
                            {
                                JetProperties.EnemyBaseScouted = true;
                                pbOfficersQuarters.Visible = true;
                                pbTankDepo.Visible = true;
                                pbArmoury.Visible = true;
                                pbBarracks.Visible = true;
                                pbHospital.Visible = true;
                            }
                            pnlMap.Refresh();
                            jetTime.Start();
                        }

                    }


                    if (Route_Calculations.endPoint != AlliedBasePoint)
                    {
                        JetProperties.CurrentSpeed = flightCalculations.IncreaseSpeed(JetProperties.CurrentSpeed);
                        JetProperties.CurrentAltitude = flightCalculations.IncreaseAltitude(JetProperties.CurrentAltitude, JetProperties.CurrentSpeed, JetProperties.SelectedMaxAltitude);

                    }

                    if (Route_Calculations.endPoint == AlliedBasePoint)
                    {
                        double distanceToEndPoint = Math.Sqrt(Math.Pow((pbFighterJet.Location.X - Route_Calculations.endPoint.X), 2) + Math.Pow((pbFighterJet.Location.Y - Route_Calculations.endPoint.Y), 2));
                        if (distanceToEndPoint < 100)
                        {
                            JetProperties.CurrentSpeed = flightCalculations.DecreaseSpeed(JetProperties.CurrentSpeed);
                            JetProperties.CurrentAltitude = flightCalculations.DecreaseAltitude(JetProperties.CurrentAltitude, JetProperties.CurrentSpeed, JetProperties.SelectedMaxAltitude);
                        }
                    }

                    JetProperties.Fuel = flightCalculations.CalculateFuelConsumption(JetProperties.Fuel, JetProperties.CurrentWeight, JetProperties.CurrentSpeed, JetProperties.CurrentAltitude);
                    jetTime.Interval = Convert.ToInt32(JetProperties.CurrentSpeed);
                    pgbFuelLevel.Value = Convert.ToInt32(JetProperties.Fuel);
                    lblSpeed.Text = Math.Round(flightCalculations.CalculateRealSpeed(JetProperties.CurrentSpeed, JetProperties.SelectedMaxSpeed)).ToString() + " Km/h";
                    lblAltitude.Text = Math.Round(JetProperties.CurrentAltitude).ToString() + " m";
                    lblBombs.Text = Convert.ToString(JetProperties.CurrentBluBomb + JetProperties.CurrentGbuBomb);
                    lblMissiles.Text = Convert.ToString(JetProperties.CurrentHarmMisslie + JetProperties.CurrentSramMissile);
                };


                jetTime.Interval = 300;
                jetTime.Start();
            }
        }

        private void btnStopReset_Click(object sender, EventArgs e)
        {
            HideSubMenus();
            ObstacleButtonDefault();
            JetButtonDefault();

            btnAddObsticle.Enabled = true;
            btnSelectJet.Enabled = true;
            btnSelectPayload.Enabled = true;
            btnLaunchJet.Enabled = true;

            JetProperties.CurrentAltitude = 1.0;
            JetProperties.CurrentSpeed = 300.0;
            JetProperties.Fuel = 100;
            lblAltitude.Text = "0";
            lblSpeed.Text = "0";
            lblBombs.Text = "0";
            lblMissiles.Text = "0";
            pgbFuelLevel.Value = 100;

            jetTime.Stop();
            pbFighterJet.Visible = false;
            pbFighterJet.Location = new Point(986, 607);
            
            Route_Calculations.RoutePoints.Clear();
            for (int i = 0; i < Obstacle_Information.ObstacleNumber; i++)
            {
                foreach (PictureBox obstacle in pnlMap.Controls.OfType<PictureBox>())
                {
                    if (obstacle.Name == Obstacle_Creation.Obstacle_Properties[i].obstacleName)
                        pnlMap.Controls.Remove(obstacle);
                }
            }
            Obstacle_Information.ObstacleNumber = 0;
            Obstacle_Creation.Obstacle_Properties.Clear();
            pnlMap.Refresh();
        }

        private void btnJet1_Click(object sender, EventArgs e)
        {
            JetButtonDefault();
            HighlightButton(btnJet1);
            JetProperties.Jetselected = true;
            JetProperties.Fuel = 100;
            JetProperties.SelectedCargoCapacity = JetList[0].CargoCapacity;
            JetProperties.SelectedMaxAltitude = JetList[0].MaxAltitude;
            JetProperties.SelectedMaxSpeed = JetList[0].MaxSpeed;
            JetProperties.SelectedMaxWeight = JetList[0].MaxWeight;
        }

        private void btnJet2_Click(object sender, EventArgs e)
        {
            JetButtonDefault();
            HighlightButton(btnJet2);
            JetProperties.Jetselected = true;
            JetProperties.Fuel = 100;
            JetProperties.SelectedCargoCapacity = JetList[1].CargoCapacity;
            JetProperties.SelectedMaxAltitude = JetList[1].MaxAltitude;
            JetProperties.SelectedMaxSpeed = JetList[1].MaxSpeed;
            JetProperties.SelectedMaxWeight = JetList[1].MaxWeight;
        }

        private void btnJet3_Click(object sender, EventArgs e)
        {
            JetButtonDefault();
            HighlightButton(btnJet3);
            JetProperties.Jetselected = true;
            JetProperties.Fuel = 100;
            JetProperties.SelectedCargoCapacity = JetList[2].CargoCapacity;
            JetProperties.SelectedMaxAltitude = JetList[2].MaxAltitude;
            JetProperties.SelectedMaxSpeed = JetList[2].MaxSpeed;
            JetProperties.SelectedMaxWeight = JetList[2].MaxWeight;
        }

        private void btnJet4_Click(object sender, EventArgs e)
        {
            JetButtonDefault();
            HighlightButton(btnJet4);
            JetProperties.Jetselected = true;
            JetProperties.Fuel = 100;
            JetProperties.SelectedCargoCapacity = JetList[3].CargoCapacity;
            JetProperties.SelectedMaxAltitude = JetList[3].MaxAltitude;
            JetProperties.SelectedMaxSpeed = JetList[3].MaxSpeed;
            JetProperties.SelectedMaxWeight = JetList[3].MaxWeight;
        }

        private void btnJet5_Click(object sender, EventArgs e)
        {
            JetButtonDefault();
            HighlightButton(btnJet5);
            JetProperties.Jetselected = true;
            JetProperties.Fuel = 100;
            JetProperties.SelectedCargoCapacity = JetList[4].CargoCapacity;
            JetProperties.SelectedMaxAltitude = JetList[4].MaxAltitude;
            JetProperties.SelectedMaxSpeed = JetList[4].MaxSpeed;
            JetProperties.SelectedMaxWeight = JetList[4].MaxWeight;
        }

        private void btnJet6_Click(object sender, EventArgs e)
        {
            JetButtonDefault();
            HighlightButton(btnJet6);
            JetProperties.Jetselected = true;
            JetProperties.Fuel = 100;
            JetProperties.SelectedCargoCapacity = JetList[5].CargoCapacity;
            JetProperties.SelectedMaxAltitude = JetList[5].MaxAltitude;
            JetProperties.SelectedMaxSpeed = JetList[5].MaxSpeed;
            JetProperties.SelectedMaxWeight = JetList[5].MaxWeight;
        }

        private void btnAddAntiAirGun_Click(object sender, EventArgs e)
        {
            ObstacleButtonDefault();
            HighlightButton(btnAddAntiAirGun);
            ResetSelectedObject();
            Obstacle_Information.AntiAirGunSelect = true;
        }

        private void btnAddAntiAirMissile_Click(object sender, EventArgs e)
        {
            ObstacleButtonDefault();
            HighlightButton(btnAddAntiAirMissile);
            ResetSelectedObject();
            Obstacle_Information.AntiAirMissileSelect = true;
        }

        private void btnAddRPGUnit_Click(object sender, EventArgs e)
        {
            ObstacleButtonDefault();
            HighlightButton(btnAddRPGUnit);
            ResetSelectedObject();
            Obstacle_Information.RPGUnitSelect = true;
        }

        private void pnlMap_Paint(object sender, PaintEventArgs e)
        {
            routePen.Width = 2;
            graphics = pnlMap.CreateGraphics();
            DrawObstacleLines();
            if(Route_Calculations.RoutePoints.Count != 0)
            {
                Point[] routePoints = Route_Calculations.RoutePoints.ToArray();
                graphics.DrawLines(routePen, routePoints);
            }
            
        }
        private void pnlMap_Click(object sender, EventArgs e)
        {
            if (Obstacle_Information.AntiAirGunSelect == true || Obstacle_Information.AntiAirMissileSelect == true || Obstacle_Information.RPGUnitSelect == true)
            {
                var location = Point.Empty;
                var CursorPosition = this.PointToClient(Cursor.Position);
                var obstacle = new Obstacle_Creation();
                PictureBox NewObstacle = obstacle.AddObstacle(CursorPosition);

                NewObstacle.MouseDown += (senderO, a) =>
                {
                    if (a.Button == MouseButtons.Left)
                    {
                        location = new Point(a.X, a.Y);
                    }
                };

                NewObstacle.MouseMove += (senderO, a) =>
                {
                    if (location != Point.Empty)
                    {
                        Point newlocation = NewObstacle.Location;
                        newlocation.X += a.X - location.X;
                        newlocation.Y += a.Y - location.Y;
                        NewObstacle.Location = newlocation;
                        //Update new location on list
                        for (int i = 0; i < Obstacle_Creation.Obstacle_Properties.Count; i++)
                        {
                            if (Obstacle_Creation.Obstacle_Properties[i].obstacleName == NewObstacle.Name)
                            {
                                Obstacle_Creation.Obstacle_Properties[i].location = NewObstacle.Location;
                                pnlMap.Refresh();
                                break;
                            }
                        }
                    }
                };

                NewObstacle.MouseUp += (senderO, a) =>
                {
                    location = Point.Empty;
                    if (pbFighterJet.Visible == true)
                    {
                        var NewRoute2 = new Route_Calculations();
                        NewRoute2.CalculateRoute();
                        double currentDistance = 0,minDistance = 90000;
                        int interval =0;
                        Point JetLocation = pbFighterJet.Location;
                        for (int i = 0; i < Route_Calculations.RoutePoints.Count; i++)
                        {
                            currentDistance = Math.Sqrt(Math.Pow((JetLocation.X - Route_Calculations.RoutePoints[i].X),2) + Math.Pow((JetLocation.Y - Route_Calculations.RoutePoints[i].Y),2));
                            if (currentDistance <= minDistance)
                            {
                                minDistance = currentDistance;
                                interval = i;
                            }
                        }
                        routePoint = interval;
                        pnlMap.Refresh();
                    }
                };

                pnlMap.Controls.Add(NewObstacle);
                NewObstacle.BringToFront();

            }
        }

        private void DrawObstacleLines() 
        {
            for (int i = 0; i < Obstacle_Creation.Obstacle_Properties.Count; i++)
            {
                Point[] obstacleLocations = {
                                              new Point(Obstacle_Creation.Obstacle_Properties[i].location.X, Obstacle_Creation.Obstacle_Properties[i].location.Y),
                                              new Point(Obstacle_Creation.Obstacle_Properties[i].location.X +32, Obstacle_Creation.Obstacle_Properties[i].location.Y),
                                              new Point(Obstacle_Creation.Obstacle_Properties[i].location.X +32, Obstacle_Creation.Obstacle_Properties[i].location.Y+32),
                                              new Point(Obstacle_Creation.Obstacle_Properties[i].location.X, Obstacle_Creation.Obstacle_Properties[i].location.Y+32),
                                              new Point(Obstacle_Creation.Obstacle_Properties[i].location.X, Obstacle_Creation.Obstacle_Properties[i].location.Y)
                                            };
                graphics.DrawLines(routePen, obstacleLocations);
            }
            
        }

        private void frmMapSimulation_Shown(object sender, EventArgs e)
        {
            HideSubMenus();
            ObstacleButtonDefault();
            JetButtonDefault();

            btnAddObsticle.Enabled = true;
            btnSelectJet.Enabled = true;
            btnSelectPayload.Enabled = true;
            btnLaunchJet.Enabled = true;

            JetProperties.CurrentAltitude = 1.0;
            JetProperties.CurrentSpeed = 300.0;
            JetProperties.Fuel = 100;
            lblAltitude.Text = "0";
            lblSpeed.Text = "0";
            lblBombs.Text = "0";
            lblMissiles.Text = "0";
            pgbFuelLevel.Value = 100;

            jetTime.Stop();
            pbFighterJet.Visible = false;
            pbFighterJet.Location = new Point(986, 607);

            Route_Calculations.RoutePoints.Clear();
            for (int i = 0; i < Obstacle_Information.ObstacleNumber; i++)
            {
                foreach (PictureBox obstacle in pnlMap.Controls.OfType<PictureBox>())
                {
                    if (obstacle.Name == Obstacle_Creation.Obstacle_Properties[i].obstacleName)
                        pnlMap.Controls.Remove(obstacle);
                }
            }
            Obstacle_Information.ObstacleNumber = 0;
            Obstacle_Creation.Obstacle_Properties.Clear();
            pnlMap.Refresh();
        }
    }
}
