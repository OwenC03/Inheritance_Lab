using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Lab
{
    class Employee
    {
        // Creates a list using the Employee template and names it "emlpoyees"
       List<Employee> employees = new List<Employee>();

        // Creates the Public employee function for the Entire Class
        public Employee()
        {
            // Calls the "LoadEmployeeFiles Funnction to initiate the employees from the file into the program itself 
            LoadEmployeeFiles();

            // Creates the Text of what will be displayed for the user and calls the results for each question to be shown
            Console.WriteLine("The average pay for all employees is: " + AveragePay());
            Console.WriteLine("The Wages employee with the highest pay is: " + HighestPaidEmployee());
            Console.WriteLine("The Salaried employee with the lowest pay is: " + LowestPaidSalaried());
            Console.WriteLine("Percentage of Salaried employees is: " + PercentageOfSalaried() + "%");
            Console.WriteLine("Percentage of Wages employees is: " + PercentageOfWages() + "%");
            Console.WriteLine("Percentage of Part Time employees is: " + PercentageOfPartTime() + "%");
        }

        // creates the function to load the employees into the code and how it should be, it also filters which which employees go to where depending on the ID code using the Cases 
        public void LoadEmployeeFiles()
        {
            string[] lines = File.ReadAllLines( @"C:\users\Momow\source\repos\OOPS 2\Week 1\Inheritance Lab\res\employees.txt");

            foreach (string line in lines)
            {
                string[] fields = line.Split(":");

                if (fields.Length >= 8)
                {
                    
                    switch (fields[0][0])
                    {
                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                            employees.Add(new Salaried(fields[0], fields[1], fields[2], fields[3], long.Parse(fields[4]), fields[5],
                                fields[6], Double.Parse(fields[7])));

                            break;
                        case '5':
                        case '6':
                        case '7':
                            employees.Add(new Wages(fields[0], fields[1], fields[2], fields[3], long.Parse(fields[4]), fields[5],
                                fields[6], Double.Parse(fields[7]), Double.Parse(fields[8])));
                            break;
                        case '8':
                        case '9':
                            employees.Add(new PartTime(fields[0], fields[1], fields[2], fields[3], long.Parse(fields[4]), fields[5],
                                fields[6], Double.Parse(fields[7]), Double.Parse(fields[8])));
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Line: " + line);
                }
            }
     
        }

        // Creates the function to grab the totals of what each employee makes add them all together and divide it by the average to get an average 
        private double AveragePay()
        {
            double totalPay = 0;
            foreach(Employee emp in employees)
            {
                if (emp is Salaried)
                {
                    totalPay += ((Salaried)emp).GetPay();
                }
                else if (emp is Wages)
                {
                    totalPay += ((Wages)emp).GetPay();
                }
                else if(emp is PartTime)
                {
                    totalPay += ((PartTime)emp).GetPay();
                }
            }
            return employees.Count >0 ? totalPay / employees.Count : 0;
        }

        // Creates the functions that is incharge of grabing the info from Wages subclass and seeing which employee was paid the most and returning their information 

        private Wages HighestPaidEmployee()
        {
            double highestPay = double.MinValue;
            Wages highestPayEmp = null;
            foreach (Employee emp in employees)
            {
                if (emp is Wages)
                {
                    Wages wageEmp = (Wages)emp;
                    if (wageEmp.GetPay() > highestPay)
                    {
                        highestPay = wageEmp.GetPay();
                        highestPayEmp = wageEmp;
                    }
                }
            }
            return highestPayEmp;
        }

        // Creates the function that grabs the info from the Salaried subclass and returns the person that makes the least amount in a salary base
        private Salaried LowestPaidSalaried()
        {
            double lowestPay = double.MaxValue;
            Salaried lowestPayEmp = null;
            
            foreach (Employee emp in employees)
            {
                if (emp is Salaried)
                {
                    Salaried salariedEmp = (Salaried)emp;
                    if (salariedEmp.GetPay() < lowestPay)
                    {
                        lowestPay = salariedEmp.GetPay();
                        lowestPayEmp = salariedEmp;
                    }
                }
            }
            return lowestPayEmp;
        }

        // creates the function that will grab the amount of employees in the Salaried subclass and then divide it by how many employees there are total to create the percentage before returning it
        private double PercentageOfSalaried()
        {
            int count = 0;
            foreach (Employee emp in employees)
            {
                if (emp is Salaried)
                {
                    count++;
                }
            }
            return (double)count/employees.Count() * 100;
        }

        // creates the function that will grab the amount of employees in the Wages subclass and then divide it by how many employees there are total to create the percentage before returning it
        private double PercentageOfWages()
        {
            int count = 0;
            foreach(Employee emp in employees)
            {
                if(emp is Wages)
                {
                    count++;
                }
            }
            return (double) count/employees.Count() * 100;
        }

        // creates the function that will grab the amount of employees in the PartTime subclass and then divide it by how many employees there are total to create the percentage before returning it
        private double PercentageOfPartTime()
        {
            int count = 0;
            foreach (Employee emp in employees)
            {
                if (emp is PartTime)
                {
                    count++;
                }
            }
            return (double) count / employees.Count() * 100;
        }

        private string personId;
        private string name;
        private string address;
        private string phoneNumber;
        private long sin;
        private string birthday;
        private string job;

       // sets up the main functions and variables for the Primary Class Employee and how it will be filtered in, while setting the getters and setters 
        public Employee(string personId, string name, string address, string phoneNumber, long sin,
            string birthday, string job)
        {
            this.PersonId = personId;
            this.Name = name;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Sin = sin;
            this.Birthday = birthday;
            this.Job = job;
        }
        
        public string PersonId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public long Sin { get; set; }
        public string Birthday { get; set; }
        public string Job { get; set; }

        // sets the basic ToString that the rest will follow if they dont have anything to override it
        public override string ToString() {

            return "Employee ID= " + PersonId + ", name= " + Name + ", address= " + Address +
           ", phone= " + PhoneNumber + ", Sin= " + Sin +", date of birth= " + Birthday +
           ", department= " + Job;
        }
    
        



    }
}
