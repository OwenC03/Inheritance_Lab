using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Lab
{
    // creates the Salaried Subclass and attaches the Employee Class as the primary/inheritance 
    class Salaried : Employee
    {
        // sets the getter and setter for Salary 
        public double Salary { get; set; }

        // sets up what Salary is going to recieve that is going to be the same but also different then the base at the end. 
        public Salaried(string personId, string name, string address, string phonenumber, long sin, string birthday,
            string job, double salary): base(personId, name, address, phonenumber, sin,birthday,job)
        {
            this.Salary = salary;
            
        }

        // Sets up the GetPay function for the Salaried people 
        public double GetPay()
        {
            // sets up the salry to a variable name 
            double calculatedPay = Salary;
            // use the function bellow after uncommenting it to double check if the functions are running properly
            //Console.WriteLine("Calculated pay for Salaried Employees are:" +  calculatedPay);
            return calculatedPay;
        }

        // creates the override function for the ToString function that is specific to Salaried 
        public override string ToString()
        {
            return "Salaried ID = " + PersonId + ", name = " + Name + ", address = " + Address + 
                ", phone = " + PhoneNumber + ", SIN = " + Sin + ", Date of birth = " + Birthday + ", department = "
                + Job + ", salary = " + Salary + ", Pay = " + GetPay();
        }
    }
}
