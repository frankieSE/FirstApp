using System.Collections.ObjectModel;
using System.Data.SqlClient;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using FirstApp.Contracts.Services;
using FirstApp.Core.Contracts.Services;
using FirstApp.Core.Models;
using FirstApp.Models;
using FirstApp.Services;
using FirstApp.Views;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using FirstApp.Contracts.ViewModels;

namespace FirstApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public string Title
        {
        get; set; }

        public class NavigationService
        {
            private Frame _frame;

            public NavigationService(Frame frame)
            {
                _frame = frame;
            }

            public void NavigateTo(Type viewModelType)
            {
                if (viewModelType == typeof(MainPageViewModel))
                {
                    _frame.Navigate(typeof(MainPage));
                }
                else if (viewModelType == typeof(sign_upViewModel))
                {
                    _frame.Navigate(typeof(sign_upPage));
                }
                // Add more conditions for additional ViewModels if needed
            }
        }


        MainPage mainPage;
        Frame frame;
       public String Email
        {
            get; set;
        }
       public String Password
        {
            get;set;
        }
        public MainPageModel Model
        {
            get; set;
        }

        public MainPageViewModel(MainPage mainPage, Frame frame )
        {
            this.mainPage = mainPage;
            this.frame = frame;
            Model = new MainPageModel();
        }
       

        public async void Login()
        {
            string connectionString;
            SqlConnection cnn;

            var username = Email;
            var password = Password;

            connectionString = @"Data Source=SEFRANKIE\SQLEXPRESS;Initial Catalog=rebornDB;Integrated Security=True";


            cnn = new SqlConnection(connectionString);
            cnn.Open();

            SqlCommand command;
            SqlDataReader dataReader;


            var sql = "Select email, password from register where email ='" + username + "' and password ='" + password + "'";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {

                this.frame.Navigate(typeof(HomeViewModel));
            }
            else
            {
                ContentDialog dialog4 = new ContentDialog();
                // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
                dialog4.XamlRoot = mainPage.XamlRoot;
                dialog4.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
                dialog4.Title = "User not found, Please sign up for an account. ";
                dialog4.CloseButtonText = "Close";
                dialog4.DefaultButton = ContentDialogButton.Primary;
                //   dialog.Content = new RegDialogBoxPage();

                var result1 = await dialog4.ShowAsync();
            }
            cnn.Close();

        }

        public async void Button_LoginClick(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            Login();
        }

        public void Button_Click_1(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
           frame.Navigate(typeof(sign_upPage));
        }

        public void OnNavigatedTo(object parameter){

        }
        public void OnNavigatedFrom() {

        }
    }
}


