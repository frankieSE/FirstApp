using FirstApp.ViewModels;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Data.SqlClient;

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

    private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        string connectionString;
        SqlConnection cnn;

        connectionString = @"Data Source = localhost; Initial Catalog = reborn_app; Integrated Security = True";

        cnn = new SqlConnection(connectionString);

        cnn.Open();

        SqlCommand command;
        SqlDataReader dataReader;
        String sql, Output = "";

        sql = "Select email, password from reborn_app";

        command = new SqlCommand(sql, cnn);

        dataReader = command.ExecuteReader();

        while (dataReader.Read())
        {
            Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1);

        }

        cnn.Close();

    }


    private void Button_Click_1(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        this.mainFrame.Navigate(typeof(sign_upPage));
    }
}
