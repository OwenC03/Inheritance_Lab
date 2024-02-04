using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Lab
{
    class PartTime : Employee
    {
        //sets up the getters/setters for rate and hours before setting up what the PartTime can expect and what vairables it goes under
        public double Rate { get; set; }
        public double Hours { get; set; }
        public PartTime(string personId, string name, string address, string phone, long sin, string birthday, string job, double rate, double hours) : base(personId, name, address, phone, sin, birthday, job)
        {
            this.Rate = rate;
            this.Hours = hours;
        }


        //sets up the getpay function for the PartTimme employees 
        public double GetPay()
        {
            double calculatedPay = Rate * Hours;
            //Console.WriteLine("the calculated pay for Part Time workers are: " + calculatedPay);
            return calculatedPay;
        }

        // sets up the tostring function overriding the default one set up by the employee class
        public override string ToString()
        {
            return "Wages ID = " + PersonId + ", Name = " + Name + ", address =" + Address + ",phone number = " + PhoneNumber +
                ", SIN = " + Sin + ", date of birth = " + Birthday + ", department = " + Job + ", rate of pay = " + Rate + ", hours worked = " +
                Hours;
        }



    }
}
