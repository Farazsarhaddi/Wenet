using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.UI;
using System.Globalization;

namespace GeoWeb // Ensure this namespace matches your project's namespace
{
    public partial class TriangleForm : Page
    {
        // API URL - Make sure to replace PORT with the actual port number your API is running on
        private static readonly string apiUrl = "http://localhost:49755/api/triangle/perimeter";

        protected async void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate that all inputs are numeric
                if (!IsValidDouble(txtLat1.Text) || !IsValidDouble(txtLon1.Text) ||
                    !IsValidDouble(txtLat2.Text) || !IsValidDouble(txtLon2.Text) ||
                    !IsValidDouble(txtLat3.Text) || !IsValidDouble(txtLon3.Text))
                {
                    lblResult.Text = "Please enter valid numeric values for all coordinates in English format.";
                    return;
                }

                // Retrieve the coordinates entered by the user
                double lat1 = Convert.ToDouble(txtLat1.Text, CultureInfo.InvariantCulture);
                double lon1 = Convert.ToDouble(txtLon1.Text, CultureInfo.InvariantCulture);
                double lat2 = Convert.ToDouble(txtLat2.Text, CultureInfo.InvariantCulture);
                double lon2 = Convert.ToDouble(txtLon2.Text, CultureInfo.InvariantCulture);
                double lat3 = Convert.ToDouble(txtLat3.Text, CultureInfo.InvariantCulture);
                double lon3 = Convert.ToDouble(txtLon3.Text, CultureInfo.InvariantCulture);

                // Check if the points are collinear
                if (ArePointsCollinear(lat1, lon1, lat2, lon2, lat3, lon3))
                {
                    lblResult.Text = "The points are collinear, so the perimeter is: 0 km";
                }
                else
                {
                    // Call the method to send a request to the API and get the result
                    double perimeter = await GetTrianglePerimeter(lat1, lon1, lat2, lon2, lat3, lon3);
                    lblResult.Text = $"The perimeter of the triangle is: {perimeter:F2} km";
                }
            }
            catch (FormatException)
            {
                lblResult.Text = "Please enter valid numeric values for all coordinates.";
            }
        }

        // Method to check if a string is a valid double
        private bool IsValidDouble(string input)
        {
            return double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
        }

        // Method to check if three points are collinear
        private bool ArePointsCollinear(double lat1, double lon1, double lat2, double lon2, double lat3, double lon3)
        {
            // Calculate the area of the triangle using the determinant formula
            double area = lat1 * (lon2 - lon3) + lat2 * (lon3 - lon1) + lat3 * (lon1 - lon2);

            // If the area is zero, the points are collinear
            return Math.Abs(area) < 1e-10; // Using a small tolerance for floating-point precision
        }

        // Method to send a request to the API
        private async Task<double> GetTrianglePerimeter(double lat1, double lon1, double lat2, double lon2, double lat3, double lon3)
        {
            using (HttpClient client = new HttpClient())
            {
                // Construct the URL for the API request
                string url = $"{apiUrl}?lat1={lat1}&lon1={lon1}&lat2={lat2}&lon2={lon2}&lat3={lat3}&lon3={lon3}";

                // Send the request and get the response
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // Read the response and convert to double
                    string result = await response.Content.ReadAsStringAsync();
                    return Convert.ToDouble(result, CultureInfo.InvariantCulture);
                }
                else
                {
                    // If the request fails, display an error message
                    lblResult.Text = "Error in API request.";
                    return 0;
                }
            }
        }
    }
}
