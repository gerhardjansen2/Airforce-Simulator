using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airforce_Project.Classes
{
    public static class JetProperties
    {
        public static bool EnemyBaseScouted { get; set; }
        public static bool TargetBombed { get; set; }
        public  static int targetNumber { get; set; }
        public static bool Jetselected { get; set; }
        public static double SelectedMaxSpeed { get; set; }
        public static double SelectedMaxWeight { get; set; }
        public static double Fuel { get; set; }
        public static double SelectedMaxAltitude { get; set; }
        public static int SelectedCargoCapacity { get; set; }
        public static double CurrentSpeed { get; set; }
        public static double CurrentAltitude { get; set; }
        public static double CurrentWeight { get; set; }
        public static int CurrentCargoNumber { get; set; }
        public static int CurrentSramMissile { get; set; }
        public static int CurrentHarmMisslie { get; set; }
        public static int CurrentBluBomb { get; set; }
        public static int CurrentGbuBomb { get; set; }

    }
}
