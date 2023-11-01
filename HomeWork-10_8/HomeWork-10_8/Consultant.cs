using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_10_8
{
    internal class Consultant : IConsultantAccess
    {
        protected Client client;

        public Consultant(Client client)
        {
            this.client = client;
        }

        public string GetMobileNumber()
        {
            return client.mobileNumber;
        }

        public string GetName()
        {
            return client.name;
        }

        public virtual string GetPassportNumber()
        {
            return new string('*', client.passportNumber.Length);
        }

        public virtual string GetPassportSeries()
        {
            return new string('*', client.passportSeries.Length);
        }

        public string GetPatronymic()
        {
            return client.patronymic;
        }

        public string GetSurname()
        {
            return client.surname;
        }

        public void SetMobileNumber(string mobileNumber, string role)
        {
            string oldMobile = client.mobileNumber;
            client.mobileNumber = mobileNumber;
            Modifications($"{oldMobile} на {mobileNumber}", role, "изменил"); ;
        }

        public void Modifications(string whatWasModified, string whoModified, string type)
        {
            client.dateWasModified = $"{DateTime.Now}";
            client.whatWasModified = whatWasModified;          
            client.whoHasModified = whoModified;
            client.modificationType = type;
        }
    }
}
