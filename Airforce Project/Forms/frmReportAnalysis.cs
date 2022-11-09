using Airforce_Project.Classes;
using Airforce_Project.Forms;
using System;
using System.Windows.Forms;

namespace Airforce_Project
{
    public partial class frmReportAnalysis : Form
    {
        public frmReportAnalysis()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var temp = new frmMapSimulation();
            temp.Region = this.Region;
            temp.Show();
            this.Close();
        }

        private void frmReportAnalysis_Load(object sender, EventArgs e)
        {
            string display;
            string damageAnalysis;
            switch (Report_Information.NumberOfBuildingsBombed)
            {
                case 1:
                    damageAnalysis = "Damage delt to enemy base is 30%. Bombing strike was successful";
                    break;

                case 2:
                    damageAnalysis = "Damage delt to enemy base is 55%. Bombing strike was successful";
                    break;

                case 3:
                    damageAnalysis = "Damage delt to enemy base is 80%. Bombing strike was successful";
                    break;

                case 4:
                    damageAnalysis = "Damage delt to enemy base is 90%. Bombing strike was successful";
                    break;

                case 5:
                    damageAnalysis = "Damage delt to enemy base is 100%. Bombing strike was successful";
                    break;

                default:
                    damageAnalysis = "Damage delt to enemy base is 0%. Bombing strike was unsuccessful";
                    break;
            }
            rtbDamageAnalysis.Text = damageAnalysis;

            rtbDescriptionOfStrike.Text = "The Strike took place at " + Report_Information.EnemyBaseLocation.X + " latatude and " +
                                            Report_Information.EnemyBaseLocation.Y + " longdetude. On " + DateTime.Now.ToString();

            display = "";
            for (int i = 0; i < Obstacle_Creation.Obstacle_Properties.Count; i++)
            {
                display = display + (Obstacle_Creation.Obstacle_Properties[i].obstacleType + " detected at " +
                                              Obstacle_Creation.Obstacle_Properties[i].location.X + " latatude and " +
                                              Obstacle_Creation.Obstacle_Properties[i].location.Y + " longdetude. \n");
            }
            rtbObstacleDetected.Text = display;

            display = "";
            for (int i = 0; i < Report_Information.ObstacleAvoidanceList.Count; i++)
            {
                 display = display + Report_Information.ObstacleAvoidanceList[i] + "\n";
            }
            rtbObstacleAvoided.Text = display;

            display = "";
            display = display + "Weight :" + Math.Round(Report_Information.WeightBefore) + "\n";
            display = display + "Fuel :" + Math.Round(Report_Information.FuelBefore) + "\n";
            display = display + "Missiles :" + Report_Information.MissilesBefore + "\n";
            display = display + "Bombs :" + Report_Information.BombsBefore + "\n";
            rtbStatsBeforeFlight.Text = display;

            display = "";
            display = display + "Weight :" + Math.Round(Report_Information.WeightAfter) + "\n";
            display = display + "Fuel :" + Math.Round(Report_Information.FuelAfter) + "\n";
            display = display + "Missiles :" + Report_Information.MisslilesAfter + "\n";
            display = display + "Bombs :" + Report_Information.BombsAfter + "\n";
            rtbStatsAfterFlight.Text = display;

        }
    }
}
