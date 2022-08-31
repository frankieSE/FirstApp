using System.Data;
using System.Data.SqlClient;
using FirstApp.ViewModels;
using Microsoft.UI.Xaml.Controls;
using Windows.UI.Popups;
using WinUIEx.Messaging;


namespace FirstApp.Views;

public sealed partial class sign_upPage : Page
{

    public sign_upViewModel ViewModel
    {
        get;
    }

    public sign_upPage()
    {
        ViewModel = App.GetService<sign_upViewModel>();
        InitializeComponent();
    }

    private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        this.sign_upFrame.Navigate(typeof(MainPage));
    }

    private void Button_Click_1(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=reborn_app;Integrated Security=True");
        SqlCommand cmd;

            conn.Open();
            cmd = new SqlCommand("insert into reborn_app(fname,lname,email,phone,password) values ('" + fnameTB.Text + "','" + lnameTB.Text + "','" + emailTB.Text + "','" + phoneTB.Text + "','" + passTB.Text + "')", conn);
            cmd.ExecuteNonQuery();
            var messageDialog = new MessageDialog("Registration Successful");
            conn.Close();
    }
}
