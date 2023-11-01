using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeWork_10_8
{
    internal class Manager : Consultant, IManagerAccess
    {
        private string whoModified = "Менеджер";
        private string type = "изменил";

        public Manager(Client client) : base(client)
        {
        }

        public override string GetPassportNumber()
        {
            return client.passportNumber;
        }

        public override string GetPassportSeries()
        {
            return client.passportSeries;
        }

        public void SetName(string name)
        {
            if (!name.Equals(""))
            {
                string oldName = client.name;
                client.name = name;
                Modifications($"{oldName} на {name}", whoModified, type);
            }
        }

        public void SetPassportNumber(string passportNumber)
        {
            if (!passportNumber.Equals(""))
            {
                string oldPassNum = client.passportNumber;
                client.passportNumber = passportNumber;
                Modifications($"{oldPassNum} на {passportNumber}", whoModified, type);
            }
        }

        public void SetPassportSeries(string passportSeries)
        {
            if (!passportSeries.Equals(""))
            {
                string oldPassSeries = client.passportSeries;
                client.passportSeries = passportSeries;
                Modifications($"{oldPassSeries} на {passportSeries}", whoModified, type);
            }
        }

        public void SetPatronymic(string patronymic)
        {
            if (!patronymic.Equals(""))
            {
                string oldPatronymic = client.patronymic;
                client.patronymic = patronymic;
                Modifications($"{oldPatronymic} на {patronymic}", whoModified, type);
            }
        }

        public void SetSurname(string surname)
        {
            if (!surname.Equals(""))
            {
                string oldSurname = client.surname;
                client.surname = surname;
                Modifications($"{oldSurname} на {surname}", whoModified, type);
            }
        }
    }
}
