using System;
using System.Windows.Forms;

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        
        const double EarthRadiusKm = 6371;

        public Form1()
        {
            InitializeComponent();
        }

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

        
        private double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                double lat1 = Convert.ToDouble(textBox1.Text);
                double long1 = Convert.ToDouble(textBox2.Text);
                double lat2 = Convert.ToDouble(textBox4.Text);
                double long2 = Convert.ToDouble(textBox5.Text);
                double lat3 = Convert.ToDouble(textBox6.Text);
                double long3 = Convert.ToDouble(textBox7.Text);

               
                double sideAB = HaversineDistance(lat1, long1, lat2, long2);
                double sideBC = HaversineDistance(lat2, long2, lat3, long3);
                double sideCA = HaversineDistance(lat3, long3, lat1, long1);

              
                double sum = sideAB + sideBC + sideCA;

                
                textBox3.Text = sum.ToString("F2"); 
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid number.", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
