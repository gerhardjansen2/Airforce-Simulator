using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airforce_Project.Classes
{
    class Flight_Calculations
    {
        public double IncreaseAltitude(double currentAltitude, double currentSpeed, double maxAltitude) 
        {
            double altitude;
            double realSpeed = 301 - currentSpeed;

            if (currentAltitude < maxAltitude)
            {
                altitude = currentAltitude + (realSpeed * 0.1);
                if (altitude > maxAltitude)
                {
                    altitude = maxAltitude;
                }
            }
            else
            {
                altitude = currentAltitude;
            }
            return altitude;
        }

        public double DecreaseAltitude(double currentAltitude, double currentSpeed, double maxAltitude)
        {
            double altitude;
            double realSpeed = 301 - currentSpeed;

            if (currentAltitude > 50)
            {
                altitude = currentAltitude - (realSpeed * 0.2);
                if (altitude < 50)
                {
                    altitude = 50;
                }
            }
            else
            {
                altitude = currentAltitude;
            }
            return altitude;
        }
        public double DecreaseSpeed(double currentSpeed)
        {
            double speed;
            if (currentSpeed < 300)
            {
                speed = currentSpeed + 4;
                if (speed > 300)
                {
                    speed = 300;
                }
            }
            else 
            {
                speed = currentSpeed;
            }
            return speed;
        }

        public double IncreaseSpeed(double currentSpeed)
        {
            double speed;
            if (currentSpeed > 1)
            {
                speed = currentSpeed - 2;
                if (speed < 1)
                {
                    speed = 1;
                }
            }
            else
            {
                speed = currentSpeed;
            }
            return speed;
        }
        public double CalculateFuelConsumption(double currentFuel, double weight, double speed, double altitude) 
        {
            double realSpeed = 301 - speed; //Reverse range from high to low TO from low to high
            double fuel = currentFuel - ((weight*0.000005)+(realSpeed * 0.000006)+(altitude * 0.000004));
            return fuel;
        }

        public double CalculateRealSpeed(double speed, double maxSpeed) 
        {
            double realSpeed = ((301-speed)/300) * maxSpeed;
            return realSpeed;
        }

        public double CalculateCurrrentWeight(int SRAM, int HARM, int BLU, int GBU) 
        {
            double currentWeight = (SRAM * 300) + (HARM * 450) + (BLU * 600) + (GBU * 550);
            return currentWeight;
        }

        public int CalculateCurrrentCargoNumber(int SRAM, int HARM, int BLU, int GBU)
        {
            int cargoNumber = (SRAM) + (HARM) + (BLU) + (GBU);
            return cargoNumber;
        }

    }
}
