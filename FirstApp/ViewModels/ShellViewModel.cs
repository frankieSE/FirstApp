using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using FirstApp.Contracts.Services;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Navigation;

namespace FirstApp.ViewModels;

public class ShellViewModel : ObservableRecipient
{
    private bool _isBackEnabled;

    public ICommand MenuFileExitCommand
    {
        get;
    }

    public ICommand MenuViewsFailedLoginDialogBoxCommand
    {
        get;
    }

    public ICommand MenuViewsRegDialogBoxCommand
    {
        get;
    }

    public ICommand MenuViewsHomeCommand
    {
        get;
    }

    public ICommand MenuViewssign_upCommand
    {
        get;
    }

    public ICommand MenuViewsBlankCommand
    {
        get;
    }

    public ICommand MenuSettingsCommand
    {
        get;
    }

    public ICommand MenuViewsDataGridCommand
    {
        get;
    }

    public ICommand MenuViewsListDetailsCommand
    {
        get;
    }

    public ICommand MenuViewsWebViewCommand
    {
        get;
    }

    public ICommand MenuViewsContentGridCommand
    {
        get;
    }

    public ICommand MenuViewsMainCommand
    {
        get;
    }

    public INavigationService NavigationService
    {
        get;
    }

    public bool IsBackEnabled
    {
        get => _isBackEnabled;
        set => SetProperty(ref _isBackEnabled, value);
    }

    public ShellViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;

        MenuFileExitCommand = new RelayCommand(OnMenuFileExit);
        MenuViewsFailedLoginDialogBoxCommand = new RelayCommand(OnMenuViewsFailedLoginDialogBox);
        MenuViewsRegDialogBoxCommand = new RelayCommand(OnMenuViewsRegDialogBox);
        MenuViewsHomeCommand = new RelayCommand(OnMenuViewsHome);
        MenuViewssign_upCommand = new RelayCommand(OnMenuViewssign_up);
        MenuViewsBlankCommand = new RelayCommand(OnMenuViewsBlank);
        MenuSettingsCommand = new RelayCommand(OnMenuSettings);
        MenuViewsDataGridCommand = new RelayCommand(OnMenuViewsDataGrid);
        MenuViewsListDetailsCommand = new RelayCommand(OnMenuViewsListDetails);
        MenuViewsWebViewCommand = new RelayCommand(OnMenuViewsWebView);
        MenuViewsContentGridCommand = new RelayCommand(OnMenuViewsContentGrid);
        MenuViewsMainCommand = new RelayCommand(OnMenuViewsMain);
    }

    private void OnNavigated(object sender, NavigationEventArgs e) => IsBackEnabled = NavigationService.CanGoBack;

    private void OnMenuFileExit() => Application.Current.Exit();

    private void OnMenuViewsFailedLoginDialogBox() => NavigationService.NavigateTo(typeof(FailedLoginDialogBoxViewModel).FullName!);

    private void OnMenuViewsRegDialogBox() => NavigationService.NavigateTo(typeof(RegDialogBoxViewModel).FullName!);

    private void OnMenuViewsHome() => NavigationService.NavigateTo(typeof(HomeViewModel).FullName!);

    private void OnMenuViewssign_up() => NavigationService.NavigateTo(typeof(sign_upViewModel).FullName!);

    private void OnMenuViewsBlank() => NavigationService.NavigateTo(typeof(BlankViewModel).FullName!);

    private void OnMenuSettings() => NavigationService.NavigateTo(typeof(SettingsViewModel).FullName!);

    private void OnMenuViewsDataGrid() => NavigationService.NavigateTo(typeof(DataGridViewModel).FullName!);

    private void OnMenuViewsListDetails() => NavigationService.NavigateTo(typeof(ListDetailsViewModel).FullName!);

    private void OnMenuViewsWebView() => NavigationService.NavigateTo(typeof(WebViewViewModel).FullName!);

    private void OnMenuViewsContentGrid() => NavigationService.NavigateTo(typeof(ContentGridViewModel).FullName!);

    private void OnMenuViewsMain() => NavigationService.NavigateTo(typeof(MainPageViewModel).FullName!);
}
