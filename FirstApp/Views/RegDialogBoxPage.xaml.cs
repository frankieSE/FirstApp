using FirstApp.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace FirstApp.Views;

public sealed partial class RegDialogBoxPage : Page
{
    public RegDialogBoxViewModel ViewModel
    {
        get;
    }

    public RegDialogBoxPage()
    {
        ViewModel = App.GetService<RegDialogBoxViewModel>();
        InitializeComponent();
    }


}
