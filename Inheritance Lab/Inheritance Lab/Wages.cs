using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Lab
{
    // creates the Wages Subclass inheriting from the Employee class 
    class Wages : Employee
    {
        // Sets up the getters/setters for rate and hours while making a constant for how many hours are a normal rate and what the incrase in the payrate is if those hours is exceted 
        public double Rate { get; set; }
        public double Hours { get; set; }
        private const double REG_HOURS = 40;
        private const double OVERTIME_PAY = 1.5;

        // Sets up the Wages id and how the program can expect to recieve info when in regards to the Wages information. 
        public Wages(string personId,  string name, string address, string phone, long sin, string birthday, string job, double rate, double hours):
            base(personId, name, address, phone, sin, birthday, job)
        {
            this.Rate = rate;
            this.Hours = hours;
        }

        // sets up the getpay function for the Wages people and has the infomation run through if the person works normal hours and if they work overtime hours 
        public double GetPay()
        {
            if (Hours <= REG_HOURS)
            {
                double calculatedPay = Rate * Hours;
               // Console.WriteLine("Calculated pay for Waged employees are: " +  calculatedPay);
                return calculatedPay;
            }
            else
            {
                double calculatedOvertimePay = Rate * REG_HOURS + Rate * OVERTIME_PAY * (Hours - REG_HOURS);
              //  Console.WriteLine("Calculated pay for Waged emplyees that have overtime are: " + calculatedOvertimePay);
                return calculatedOvertimePay;
            }
        }

        // sets up the ToString function for the wages emplyees that overrides the defualt set by the employee class
        public override string ToString()
        {
            return "Wages ID = " + PersonId + ", Name = " + Name + ", address =" + Address + ",phone number = " + PhoneNumber +
                ", SIN = " + Sin + ", date of birth = " + Birthday + ", department = " + Job + ", rate of pay = " + Rate + ", hours worked = " +
                Hours + ", pay = " + GetPay();
        }


    
    }
}
