using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeWork_10_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ObservableCollection<Client> clients = new ObservableCollection<Client>()
            {
                new Client("Ягубов", "Ефрем", "Яковлевич", "+7 (954) 392-65-99", "4048", "597525"),
                new Client("Бунина", "Ксения", "Ивановна", "+7 (940) 253-98-17", "4064", "303374"),
                new Client("Греков", "Кирилл", "Юлианович", "+7 (942) 301-62-98", "4919", "245104"),
                new Client("Негес", "Арина", "Севастьяновна", "+7 (912) 409-81-32", "4673", "375509")
            };
            
            ClientList.ItemsSource = clients;

            DataContext = this;
        }

        private void PickUser_DropDownOpened(object sender, EventArgs e)
        {
            string selectedUserType = ((ComboBoxItem)PickUser.SelectedItem).Content.ToString();
            
        }

        private void ClientList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClientList.SelectedItem is Client selectedClient)
            {
                name.Content = selectedClient.name;
                surname.Content = selectedClient.surname;
                patronymic.Content = selectedClient.patronymic;
                mobile.Content = selectedClient.cellPhoneNumber;
                passSeries.Content = selectedClient.passportSeries;
                passNumber.Content = selectedClient.passportNumber;

                newName.Text = selectedClient.name;
                newSurname.Text = selectedClient.surname;
                newPatronymic.Text = selectedClient.patronymic;
                newMobile.Text = selectedClient.cellPhoneNumber;
                newPassSeries.Text = selectedClient.passportSeries;
                newPassNumber.Text = selectedClient.passportNumber;
            }
        }
    }
}
