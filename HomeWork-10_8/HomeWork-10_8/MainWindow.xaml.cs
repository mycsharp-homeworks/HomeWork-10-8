using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace HomeWork_10_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int index = 0;

        string consultantRoleName = "Consultant";
        string managerRoleName = "Manager";
        string selectedRole = "";

        string changeNameText = "Изменить имя";
        string changeSurnameText = "Изменить фамилию";
        string changePatronymicText = "Изменить отчество";
        string changeMobileText = "Изменить мобильный";
        string changePassportSeriesText = "Изменить серию";
        string changePassportNumberText = "Изменить номер";

        public string[] users { get; }

        public ObservableCollection<Client> сlientsCollection { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            newName.Text = changeNameText;
            newSurname.Text = changeSurnameText;
            newPatronymic.Text = changePatronymicText;
            newMobile.Text = changeMobileText;
            newPassSeries.Text = changePassportSeriesText;
            newPassNumber.Text = changePassportNumberText;

            users = new string[] { consultantRoleName, managerRoleName };
     
            сlientsCollection = LoadClientInfoFromXml();

            DataContext = this;
        }

        #region Custom Methods

        /// <summary>
        /// Этот метод создает новый XML-документ, 
        /// перебирает клиентов в коллекции и добавляет их в виде элементов XML. 
        /// Затем сохраняет XML-документ в файл "clients.xml".
        /// </summary>
        /// <param name="clients"></param>
        public void SaveClientInfoToXml(ObservableCollection<Client> clients)
        {
            XDocument xmlDocument = new XDocument(
                    new XElement("ArrayOfClient",
                        clients.Select(client =>
                            new XElement("Client",
                                new XElement("name", client.name),
                                new XElement("surname", client.surname),
                                new XElement("patronymic", client.patronymic),
                                new XElement("cellPhoneNumber", client.mobileNumber),
                                new XElement("passportSeries", client.passportSeries),
                                new XElement("passportNumber", client.passportNumber)
                            )
                        )
                    )
            );
                xmlDocument.Save("clients.xml");
        }

        /// <summary>
        /// Этот метод выгружает информацию о клиентах из XML-файла "clients.xml", 
        /// преобразует в ObservableCollection<Client> и возвращает ее,
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Client> LoadClientInfoFromXml()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Client>));

            using (FileStream fs = new FileStream("clients.xml", FileMode.OpenOrCreate))
            {
                ObservableCollection<Client> newClientsList = xmlSerializer.Deserialize(fs) as ObservableCollection<Client>;
                return newClientsList;
            }
                
        }

        /// <summary>
        /// Этот вспомогательный метод создает новый XML-документ, 
        /// перебирает клиентов в коллекции и добавляет их в виде элементов XML. 
        /// Затем сохраняет XML-документ поверх существующего файла "clients.xml".
        /// Замем выгружает информацию из этог файла и обновляет список клиентов в ClientList
        /// </summary>
        /// <param name="clients"></param>
        public void UpdateClientsList(ObservableCollection<Client> clientCollection)
        {
            SaveClientInfoToXml(clientCollection);

            ClientList.ItemsSource = LoadClientInfoFromXml();
        }
        #endregion

        #region ListBox and ComboBox methods
        private void ClientList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClientList.SelectedItem is Client selectedClient)
            {
                index = ClientList.SelectedIndex;

                if (selectedRole.Equals(consultantRoleName))
                {
                    Consultant consultant = new Consultant(selectedClient);

                    name.Content = consultant.GetName();
                    surname.Content = consultant.GetSurname();
                    patronymic.Content = consultant.GetPatronymic();
                    mobile.Content = consultant.GetMobileNumber();
                    passSeries.Content = consultant.GetPassportSeries();
                    passNumber.Content = consultant.GetPassportNumber();
                }
                else
                {
                    Manager manager = new Manager(selectedClient);

                    name.Content = manager.GetName();
                    surname.Content = manager.GetSurname();
                    patronymic.Content = manager.GetPatronymic();
                    mobile.Content = manager.GetMobileNumber();
                    passSeries.Content = manager.GetPassportSeries();
                    passNumber.Content = manager.GetPassportNumber();
                }
            }
        }

        private void PickUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRole = PickUser.SelectedItem.ToString();
        }
        #endregion

        #region Save Button Clicks

        private void SaveName_Click(object sender, RoutedEventArgs e)
        {
            Manager manager = new Manager(сlientsCollection.ElementAt(index));

            manager.SetName(newName.Text);

            newName.Text = changeNameText;

            UpdateClientsList(сlientsCollection);
        }

        private void saveSurname_Click(object sender, RoutedEventArgs e)
        {
            Manager manager = new Manager(сlientsCollection.ElementAt(index));

            manager.SetSurname(newSurname.Text);

            newSurname.Text = changeSurnameText;

            UpdateClientsList(сlientsCollection);
        }

        private void savePatronymic_Click(object sender, RoutedEventArgs e)
        {
            Manager manager = new Manager(сlientsCollection.ElementAt(index));

            manager.SetPatronymic(newPatronymic.Text);

            newPatronymic.Text = changePatronymicText;

            UpdateClientsList(сlientsCollection);
        }

        private void saveMobile_Click(object sender, RoutedEventArgs e)
        {
            Consultant consultant = new Consultant(сlientsCollection.ElementAt(index));

            consultant.SetCellPhoneNumber(newMobile.Text);

            newMobile.Text = changeMobileText;

            UpdateClientsList(сlientsCollection);
        }

        private void savePassSeries_Click(object sender, RoutedEventArgs e)
        {
            Manager manager = new Manager(сlientsCollection.ElementAt(index));

            manager.SetPassportSeries(newPassSeries.Text);

            newPassSeries.Text = changePassportSeriesText;

            UpdateClientsList(сlientsCollection);
        }

        private void savePassNumber_Click(object sender, RoutedEventArgs e)
        {
            Manager manager = new Manager(сlientsCollection.ElementAt(index));

            manager.SetPassportNumber(newPassNumber.Text);

            newPassNumber.Text = changePassportNumberText;

            UpdateClientsList(сlientsCollection);
        }
        #endregion

        #region TextBox GotFocus

        private void newName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = string.Empty;
        }

        private void newSurname_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = string.Empty;
        }

        private void newPatronymic_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = string.Empty;
        }

        private void newMobile_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = string.Empty;
        }

        private void newPassSeries_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = string.Empty;
        }

        private void newPassNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = string.Empty;
        }

        private void newName_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = string.Empty;
        }
        #endregion
    }
}
