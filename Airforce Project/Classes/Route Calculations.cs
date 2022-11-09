using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airforce_Project.Classes
{
    class Route_Calculations
    {
        public static Point startPoint = new Point();
        public static Point endPoint = new Point();
        
        public static List<Point> RoutePoints = new List<Point>();
        private List<Point> BackTrackPointList = new List<Point>();
        private List<Point> CalculationPoints = new List<Point>();
        private Point nextPoint = new Point(), currentPoint = new Point();

        public void CalculateRoute() 
        {
            BackTrackPointList.Clear();
            RoutePoints.Clear();
            CalculationPoints.Clear();

            if ((currentPoint.X == 0) && (currentPoint.Y == 0))
            {
                currentPoint = startPoint;
            }

            while(((endPoint.X-20 <= currentPoint.X && currentPoint.X <= endPoint.X+20) && (endPoint.Y-20 <= currentPoint.Y && currentPoint.Y <= endPoint.Y+20)) != true)
            {
                nextPoint = CalculateNextPoint(currentPoint, CalculeAngleBetweenPoints(currentPoint, endPoint));

                if ((ObstacleDetect(nextPoint) == false) && (IsPointOnBacktrackList(nextPoint) == false))
                {
                    CalculationPoints.Add(new Point{ X= nextPoint.X , Y = nextPoint.Y } );
                    currentPoint = nextPoint;
                }
                else 
                {
                    nextPoint = CalculateAlternativePoint(currentPoint);
                    if (nextPoint.X == 0 && nextPoint.Y ==0)
                    {
                        currentPoint = Backtrack();
                    }
                    else
                    {
                        CalculationPoints.Add(new Point { X = nextPoint.X, Y = nextPoint.Y });
                        currentPoint = nextPoint;   
                    }
                }
            }
            RoutePoints.Add(startPoint);
            RoutePoints.AddRange(CalculationPoints);
            RoutePoints.Add(endPoint);
        }
        private Point Backtrack() 
        {
            Point nextP = new Point();
            BackTrackPointList.Add(CalculationPoints[CalculationPoints.Count - 1]);
            CalculationPoints.RemoveAt(CalculationPoints.Count -1);
            nextP.X = CalculationPoints[CalculationPoints.Count - 1].X;
            nextP.Y = CalculationPoints[CalculationPoints.Count - 1].Y;

            return nextP;

        }

        private bool IsPointOnBacktrackList(Point nextP) 
        {
            bool PointIsOnList = false;
            for (int i = 0; i < BackTrackPointList.Count; i++)
            {
                if ((BackTrackPointList[i].X == nextP.X) && (BackTrackPointList[i].Y == nextP.Y))
                {
                    PointIsOnList = true;
                    break;
                }
            }
            return PointIsOnList;
        }
        private Point CalculateAlternativePoint(Point currentP) 
        {
            bool Routefound = false;
            Point nextP = new Point();
            for (int i = 0; i <= 18; i++)
            {
                Point AltPoint = CalculateNextPoint(currentP, CalculateAlternateAngle(i));
                if ((ObstacleDetect(AltPoint) == false) && (IsPointOnBacktrackList(AltPoint) == false))
                {
                    nextP = AltPoint;
                    Routefound = true;
                    break;
                }
            }
            if (Routefound == false)
            {
                nextP.X = 0;
                nextP.Y = 0;
            }

            return nextP;
        }
        private double CalculateAlternateAngle(int increment) 
        {
            double nextAngle;

                int remainder = increment % 2;
                if (remainder == 0) //even number
                {
                    nextAngle = CalculeAngleBetweenPoints(currentPoint, endPoint) + (0.0872665 * Math.Ceiling(increment / 2.0));
                }
                else //odd Number
                {
                    nextAngle = CalculeAngleBetweenPoints(currentPoint, endPoint) - (0.0872665 * Math.Ceiling(increment / 2.0));
                }
            return nextAngle;
        }

        private Point CalculateNextPoint(Point curentP, double NextAngle) 
        {
            Point nextP = new Point();
            nextP.X = (int)(curentP.X + Math.Cos(NextAngle) * 8);
            nextP.Y = (int)(curentP.Y + Math.Sin(NextAngle) * 8);

            return nextP;
        }
        private bool ObstacleDetect(Point evaluationPoint) 
        {
            bool obstacleDetected = false;
            for (int i = 0; i < Obstacle_Creation.Obstacle_Properties.Count; i++)
            {
                if (((Obstacle_Creation.Obstacle_Properties[i].location.X -5 <= evaluationPoint.X) &&
                    (evaluationPoint.X <= Obstacle_Creation.Obstacle_Properties[i].location.X+37)) &&
                    ((Obstacle_Creation.Obstacle_Properties[i].location.Y-5 <= evaluationPoint.Y) &&
                    (evaluationPoint.Y <= Obstacle_Creation.Obstacle_Properties[i].location.Y + 37)))
                {
                    obstacleDetected = true;
                    string obstacleinformation = Obstacle_Creation.Obstacle_Properties[i].obstacleType + " avoided at " +
                           Obstacle_Creation.Obstacle_Properties[i].location.ToString() +". " +
                           "Aircraft would have been in" + Obstacle_Creation.Obstacle_Properties[i].obstacleType +
                           "firing range";
                    Report_Information.ObstacleAvoidanceList.Add(obstacleinformation);
                    break;
                }
            }

            return obstacleDetected;
        }

        public double CalculeAngleBetweenPoints(Point CurrentPoint, Point EndPoint)
        {
            var deltaX = Math.Pow((EndPoint.X - CurrentPoint.X), 2);
            var deltaY = Math.Pow((EndPoint.Y - CurrentPoint.Y), 2);

            var radians = Math.Atan2((EndPoint.Y - CurrentPoint.Y), (EndPoint.X - CurrentPoint.X));
            //var degrees = (radians * (180 / Math.PI) + 360) % 360;

            return radians;
        }
    }
}
