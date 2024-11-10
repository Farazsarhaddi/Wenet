using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TriangleWebAPI.Models
{
    // This class provides methods to calculate the perimeter of a triangle using geographical coordinates
    public class TrianglePerimeterCalculator
    {
        // Private method to calculate the distance between two geographical points using the Haversine formula
        private double CalculateDistance(GeoPoint p1, GeoPoint p2)
        {
            const double R = 6371; // Radius of the Earth in kilometers
            double lat1 = ToRadians(p1.Y); // Convert latitude of point 1 to radians
            double lon1 = ToRadians(p1.X); // Convert longitude of point 1 to radians
            double lat2 = ToRadians(p2.Y); // Convert latitude of point 2 to radians
            double lon2 = ToRadians(p2.X); // Convert longitude of point 2 to radians

            // Calculate the differences in latitude and longitude
            double dlat = lat2 - lat1;
            double dlon = lon2 - lon1;

            // Haversine formula to calculate the great-circle distance between two points
            double a = Math.Sin(dlat / 2) * Math.Sin(dlat / 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Sin(dlon / 2) * Math.Sin(dlon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c; // Return the distance in kilometers
        }

        // Private method to convert degrees to radians
        private double ToRadians(double degree)
        {
            return degree * (Math.PI / 180);
        }

        // Public method to calculate the perimeter of a triangle formed by three geographical points
        public double CalculatePerimeter(GeoPoint p1, GeoPoint p2, GeoPoint p3)
        {
            // Calculate the distances between each pair of points
            double side1 = CalculateDistance(p1, p2);
            double side2 = CalculateDistance(p2, p3);
            double side3 = CalculateDistance(p3, p1);

            // Return the sum of the distances as the perimeter of the triangle
            return side1 + side2 + side3;
        }
    }
}
