using System;
using System.Web.Http;

namespace TriangleAPI.Controllers
{
    public class TriangleController : ApiController
    {
        const double EarthRadiusKm = 6371;

        // Haversine formula for distance calculation
        private double HaversineDistance(double lat1, double lon1, double lat2, double lon2)
        {
            double dLat = DegreesToRadians(lat2 - lat1);
            double dLon = DegreesToRadians(lon2 - lon1);

            lat1 = DegreesToRadians(lat1);
            lat2 = DegreesToRadians(lat2);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return EarthRadiusKm * c;
        }

        // Convert degrees to radians
        private double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

        // Web API method to calculate perimeter of the triangle
        [HttpGet]
        [Route("api/triangle/perimeter")]
        public IHttpActionResult GetPerimeter(double lat1, double lon1, double lat2, double lon2, double lat3, double lon3)
        {
            try
            {
                // Calculate the sides of the triangle
                double sideAB = HaversineDistance(lat1, lon1, lat2, lon2);
                double sideBC = HaversineDistance(lat2, lon2, lat3, lon3);
                double sideCA = HaversineDistance(lat3, lon3, lat1, lon1);

                // Calculate the perimeter (sum of sides)
                double perimeter = sideAB + sideBC + sideCA;

                // Return the result
                return Ok(perimeter);
            }
            catch (Exception ex)
            {
                return BadRequest("Error in calculation: " + ex.Message);
            }
        }
    }
}
