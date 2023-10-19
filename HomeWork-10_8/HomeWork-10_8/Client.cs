﻿using System;
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
        public string cellPhoneNumber {  get; set; }
        public string passportSeries { get; set; }
        public string passportNumber { get; set; }

        public Client(string name, 
            string surname, 
            string patronymic, 
            string cellPhoneNumber, 
            string passportSeries, 
            string passportNumber)
        {
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.cellPhoneNumber = cellPhoneNumber;
            this.passportSeries = passportSeries;
            this.passportNumber = passportNumber;
        }
    }
}
