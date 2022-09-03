using FirstApp.ViewModels;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Data.SqlClient;
using System.Diagnostics;
using ColorCode.Styling;
using Microsoft.UI.Xaml;
using Style = Microsoft.UI.Xaml.Style;

namespace FirstApp.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }

    private async void Button_LoginClick(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        string connectionString;
        SqlConnection cnn;
        var username = emailTB.Text;
        var password = passTB.Text;

        connectionString = @"Data Source = localhost; Initial Catalog = reborn_app; Integrated Security = True";

        cnn = new SqlConnection(connectionString);

        SqlCommand command ;

        var sql = "Select email, password from reborn_app where email ='" + username + "' and password ='" + password + "'";
        command = new SqlCommand(sql, cnn);

        cnn.Open();
        
        SqlDataReader dataReader = command.ExecuteReader();

        if (dataReader.HasRows)
        {
            this.mainFrame.Navigate(typeof(HomePage));
        }
        else 
        {
            ContentDialog dialog4 = new ContentDialog();
            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            dialog4.XamlRoot = this.XamlRoot;
            dialog4.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
            dialog4.Title = "User not found, Please sign up for an account. ";
            dialog4.CloseButtonText = "Close";
            dialog4.DefaultButton = ContentDialogButton.Primary;
            //   dialog.Content = new RegDialogBoxPage();

            var result1 = await dialog4.ShowAsync();
        }
        cnn.Close();
    }
 
    private void Button_Click_1(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        this.mainFrame.Navigate(typeof(sign_upPage));
    }
}
