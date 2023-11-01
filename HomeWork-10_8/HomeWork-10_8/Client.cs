using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_10_8
{
    public class Client
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string patronymic { get; set; }
        public string mobileNumber {  get; set; }
        public string passportSeries { get; set; }
        public string passportNumber { get; set; }

        public Client() { }

        public Client(string surname,
            string name,              
            string patronymic, 
            string mobileNumber, 
            string passportSeries, 
            string passportNumber)
        {            
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            this.mobileNumber = mobileNumber;
            this.passportSeries = passportSeries;
            this.passportNumber = passportNumber;
        }
    }
}
