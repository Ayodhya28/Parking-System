using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ParkingLotProblems
{
public partial class Form1 : Form
{
public Form1()
{
InitializeComponent();
}
private void button1_Click(object sender, EventArgs e)
{
// Clear all input fields when the "Exit" button is clicked
/*parkingTimeTxt.Clear();
currentTimeTxt.Clear();
paymentTxt.Clear();
carRadioButton.Checked = false;
truckRadioButton.Checked = false;*/
this.Close();
}
private void calculate_Click(object sender, EventArgs e)
{
// function for the when the "Calculate" button is clicked
try
{
if (DateTime.TryParseExact(parking_time.Text, "HH:mm:ss", null,
System.Globalization.DateTimeStyles.None, out DateTime entryTime)
&& DateTime.TryParseExact(current_time.Text, "HH:mm:ss", null,
System.Globalization.DateTimeStyles.None, out DateTime exitTime))
{
// Calculate the duration of parking in hours
TimeSpan duration = exitTime - entryTime;
double hours = duration.TotalHours;
// vehicle type and calculate the parking fee
double baseRate, additionalRate, maxRate;
if (car.Checked) // Car
{
baseRate = 5.0;
additionalRate = 3.0;
maxRate = 38.0;
}
else if (truck.Checked) // Truck
{
baseRate = 6.0;
additionalRate = 3.5;
maxRate = 44.5;
}
else
{
MessageBox.Show("Please select a vehicle type.");
return;
}
// Calculate the parking fee
double totalFee = Math.Min(baseRate + Math.Max(0, hours - 1) *
additionalRate, maxRate);
// Display the calculated fee
payment.Text = totalFee.ToString("C");
}
else
{
MessageBox.Show("Invalid time format. Please use HH:mm:ss.");
}
}
catch (Exception ex)
{
MessageBox.Show("Error: " + ex.Message);
}
}
}
}