using FirstApp.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace FirstApp.Views;

public sealed partial class FailedLoginDialogBoxPage : Page
{
    public FailedLoginDialogBoxViewModel ViewModel
    {
        get;
    }

    public FailedLoginDialogBoxPage()
    {
        ViewModel = App.GetService<FailedLoginDialogBoxViewModel>();
        InitializeComponent();
    }



}
