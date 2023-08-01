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
    public MainPageViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = new MainPageViewModel(this, mainFrame);
        InitializeComponent();
        DataContext = ViewModel;
    }

    private async void Button_LoginClick(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {   
        ViewModel.Button_LoginClick(sender, e);
    }
 
    private void Button_Click_1(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ViewModel.Button_Click_1(sender, e);
    }

    private void Button_Click()
    {

    }
}
