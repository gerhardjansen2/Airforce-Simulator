using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airforce_Project.Classes
{
    class Target_Calculations
    {
        public Point CalculateNextTarget(List<Point> targetList, Point finalDestination, int cargoNumber, bool enemyBaseScouted) 
        {
            var endpoint = new Point();
            if ((enemyBaseScouted == true)&&((cargoNumber > 0)&&(JetProperties.targetNumber < targetList.Count)))
            {
                endpoint = targetList[JetProperties.targetNumber];
                JetProperties.targetNumber += 1;
            }
            else
            {
                endpoint = finalDestination;
            }
            endpoint = new Point(endpoint.X + 20,endpoint.Y + 20);
            return endpoint;
        }
        public void SelectExplosiveToUse() 
        {
            if (JetProperties.CurrentGbuBomb > 0)
            {
                JetProperties.CurrentGbuBomb -= 1;
            }
            else if (JetProperties.CurrentBluBomb > 0)
            {
                JetProperties.CurrentBluBomb -= 1;
            }
            else if (JetProperties.CurrentHarmMisslie > 0)
            {
                JetProperties.CurrentHarmMisslie -= 1;
            }
            else if (JetProperties.CurrentSramMissile > 0)
            {
                JetProperties.CurrentSramMissile -= 1;
            }
        }
        public void BombBuilding(PictureBox building) 
        {
            var flightCalculations = new Flight_Calculations();
            JetProperties.CurrentCargoNumber = flightCalculations.CalculateCurrrentCargoNumber(JetProperties.CurrentSramMissile, JetProperties.CurrentHarmMisslie, JetProperties.CurrentBluBomb, JetProperties.CurrentGbuBomb);
            building.Visible = false;
            JetProperties.TargetBombed = true;
            Report_Information.NumberOfBuildingsBombed += 1;
            Report_Information.EnemyBaseBombed = true;
        }
    }
}
