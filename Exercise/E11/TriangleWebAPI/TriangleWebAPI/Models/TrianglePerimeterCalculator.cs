using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TriangleWebAPI.Models
{
    public class TrianglePerimeterCalculator
    {
        private double CalculateDistance(GeoPoint p1, GeoPoint p2)
        {
            const double R = 6371;
            double lat1 = ToRadians(p1.Y);
            double lon1 = ToRadians(p1.X);
            double lat2 = ToRadians(p2.Y);
            double lon2 = ToRadians(p2.X);

            double dlat = lat2 - lat1;
            double dlon = lon2 - lon1;

            double a = Math.Sin(dlat / 2) * Math.Sin(dlat / 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Sin(dlon / 2) * Math.Sin(dlon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c; 
        }

        private double ToRadians(double degree)
        {
            return degree * (Math.PI / 180);
        }

        public double CalculatePerimeter(GeoPoint p1, GeoPoint p2, GeoPoint p3)
        {
            double side1 = CalculateDistance(p1, p2);
            double side2 = CalculateDistance(p2, p3);
            double side3 = CalculateDistance(p3, p1);

            return side1 + side2 + side3; 
        }
    }

}