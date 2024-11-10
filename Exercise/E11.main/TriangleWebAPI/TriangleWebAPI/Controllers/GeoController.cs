using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TriangleWebAPI.Models;

namespace TriangleWebAPI.Controllers
{
    public class TriangleController : ApiController
    {
       
        public List<GeoPoint> Points = new List<GeoPoint>()
    {
        new GeoPoint() {ID = 1, X = 51.1, Y = 35.5 },
        new GeoPoint() {ID = 2, X = 52.3, Y = 34.3 },
        new GeoPoint() {ID = 3, X = 53.2, Y = 32.3 },
        
    };


        [HttpGet]
        [Route("api/triangle/perimeter")]
        public IHttpActionResult GetPerimeter()
        {
       

            var calculator = new TrianglePerimeterCalculator();
            double perimeter = calculator.CalculatePerimeter(Points[0], Points[1], Points[2]);

            return Ok(new { Perimeter = perimeter });
        }
    }
}
