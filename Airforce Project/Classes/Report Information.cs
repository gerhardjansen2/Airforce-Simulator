using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airforce_Project.Classes
{
    public class Report_Information
    {
        public static List<string> ObstacleAvoidanceList = new List<string>();
        public static int NumberOfBuildingsBombed { get; set; }
        public static double WeightBefore { get; set; }
        public static double WeightAfter { get; set; }
        public static double FuelBefore { get; set; }
        public static double FuelAfter { get; set; }
        public static int MissilesBefore { get; set; }
        public static int MisslilesAfter { get; set; }
        public static int BombsBefore { get; set; }
        public static int BombsAfter { get; set; }
        public static bool EnemyBaseBombed { get; set; }
        public static Point EnemyBaseLocation { get; set; }
        public static bool ReportShown { get; set; }
    }
}
