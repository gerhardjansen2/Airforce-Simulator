using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airforce_Project.Classes
{
    class Default_Jet_Values
    {
        public List<Jet> LoadDefaultJetValues() 
        {
            List<Jet> values = new List<Jet>();

            Jet jet = new Jet();
            jet.JetID = 1;
            jet.JetName = "Jet1";
            jet.MaxSpeed = 1900.0;
            jet.MaxWeight = 1500.0;
            jet.FuelTankSize = 200.0;
            jet.MaxAltitude = 1560;
            jet.CargoCapacity = 5;
            values.Add(jet);

            jet.JetID = 2;
            jet.JetName = "Jet2";
            jet.MaxSpeed = 1850.0;
            jet.MaxWeight = 1100.0;
            jet.FuelTankSize = 150.0;
            jet.MaxAltitude = 1600;
            jet.CargoCapacity = 3;
            values.Add(jet);

            jet.JetID = 3;
            jet.JetName = "Jet3";
            jet.MaxSpeed = 2000.0;
            jet.MaxWeight = 1700.0;
            jet.FuelTankSize = 210.0;
            jet.MaxAltitude = 1950;
            jet.CargoCapacity = 8;
            values.Add(jet);

            jet.JetID = 4;
            jet.JetName = "Jet4";
            jet.MaxSpeed = 1980.0;
            jet.MaxWeight = 1650.0;
            jet.FuelTankSize = 180.0;
            jet.MaxAltitude = 2105;
            jet.CargoCapacity = 6;
            values.Add(jet);

            jet.JetID = 5;
            jet.JetName = "Jet5";
            jet.MaxSpeed = 2150.0;
            jet.MaxWeight = 1800.0;
            jet.FuelTankSize = 220.0;
            jet.MaxAltitude = 2156;
            jet.CargoCapacity = 5;
            values.Add(jet);

            jet.JetID = 6;
            jet.JetName = "Jet6";
            jet.MaxSpeed = 2200.0;
            jet.MaxWeight = 1500.0;
            jet.FuelTankSize = 230.0;
            jet.MaxAltitude = 2500;
            jet.CargoCapacity = 8;
            values.Add(jet);

            return values;
        }
    }
}
