using Airforce_Project.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airforce_Project.Classes
{
    class Obstacle_Creation
    {
        public static List<Obstacle_Properties> Obstacle_Properties = new List<Obstacle_Properties>();
        private string obstacleTypeSelected;
        private int obstacleFiringAltatude;
        public PictureBox AddObstacle(Point CursorPosition) 
        {
            Obstacle_Information.ObstacleNumber += 1;
            var obstacleLocation = new Point(CursorPosition.X-16, CursorPosition.Y-16);
            PictureBox obstacle = new PictureBox
            {
                Name = "Obstacle" + Obstacle_Information.ObstacleNumber.ToString(),
                Height = 32,
                Width = 32,
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(CursorPosition.X - 16, CursorPosition.Y - 16)
            };

            if (Obstacle_Information.AntiAirGunSelect == true) 
            {
                obstacle.Image = Airforce_Project.Properties.Resources.anti_aircraft_gun;
                obstacleTypeSelected = "Anti Air Gun";
                obstacleFiringAltatude = 1800;
            }
            if (Obstacle_Information.AntiAirMissileSelect == true)
            {
                obstacle.Image = Airforce_Project.Properties.Resources.missile_launcher;
                obstacleTypeSelected = "Anti Air Missile";
                obstacleFiringAltatude = 2100;
            }
            if (Obstacle_Information.RPGUnitSelect == true)
            {
                obstacle.Image = Airforce_Project.Properties.Resources.panzerfaust;
                obstacleTypeSelected = "RPG Unit";
                obstacleFiringAltatude = 1400;
            }

            Obstacle_Properties.Add(new Obstacle_Properties {obstacleType = obstacleTypeSelected, location = obstacleLocation, firingAltitude = obstacleFiringAltatude,obstacleName = "Obstacle" + Obstacle_Information.ObstacleNumber.ToString() });

            return obstacle;
            
        }

    }
}
