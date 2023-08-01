using System.Data;
using System.Data.SqlClient;
using FirstApp.ViewModels;
using Microsoft.UI.Xaml;
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

    private async void DisplayRegSS()
    {
        ContentDialog regss = new ContentDialog();
        {
            //  Content = "Registration successful."
        }
    }

    private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        this.sign_upFrame.Navigate(typeof(MainPage));
    }

    private async void Button_Click_1(object sender, RoutedEventArgs e)
    {

        var fname = fnameTB.Text;
        var lname = lnameTB.Text;
        var email = emailTB.Text;
        var phone = phoneTB.Text;
        var password = passTB.Text;


        SqlConnection conn = new SqlConnection(@"Data Source=SEFRANKIE\SQLEXPRESS;Initial Catalog=rebornDB;Integrated Security=True");

        SqlCommand cmd;

        if (fname != "" && lname != "" && email != "" && phone != "" && password != "")
        {
            var sql = "insert into register (fname,lname,email,phone,password) values ('" + fname + "','" + lname + "','" + email + "','" + phone + "','" + password + "')";

            cmd = new SqlCommand(sql, conn);

            conn.Open();
            var rows = cmd.ExecuteNonQuery();
            conn.Close();

            if (rows >= 1)
            {
                ContentDialog dialog = new ContentDialog();
                // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
                dialog.XamlRoot = this.XamlRoot;
                dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
                dialog.Title = "Registration Successful";
                dialog.CloseButtonText = "Close";
                dialog.DefaultButton = ContentDialogButton.Primary;
                //   dialog.Content = new RegDialogBoxPage();

                var result = await dialog.ShowAsync();

            }

            else
            {
                ContentDialog dialog1 = new ContentDialog();
                // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
                dialog1.XamlRoot = this.XamlRoot;
                dialog1.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
                dialog1.Title = "Failed to Register user";
                dialog1.CloseButtonText = "Close";
                dialog1.DefaultButton = ContentDialogButton.Primary;
                //   dialog.Content = new RegDialogBoxPage();

                var result1 = await dialog1.ShowAsync();

            }

        }

        else
        {
            ContentDialog dialog2 = new ContentDialog();
            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            dialog2.XamlRoot = this.XamlRoot;
            dialog2.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
            dialog2.Title = "Fields cannot be left blank";
            dialog2.CloseButtonText = "Close";
            dialog2.DefaultButton = ContentDialogButton.Primary;
            //   dialog.Content = new RegDialogBoxPage();

            var result2 = await dialog2.ShowAsync();

        }
    }

}