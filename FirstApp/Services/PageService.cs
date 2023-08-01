using CommunityToolkit.Mvvm.ComponentModel;

using FirstApp.Contracts.Services;
using FirstApp.ViewModels;
using FirstApp.Views;

using Microsoft.UI.Xaml.Controls;

namespace FirstApp.Services;

public class PageService : IPageService
{
    private readonly Dictionary<string, Type> _pages = new();

    public PageService()
    {
        Configure<MainPageViewModel, MainPage>();
        Configure<ContentGridViewModel, ContentGridPage>();
        Configure<ContentGridDetailViewModel, ContentGridDetailPage>();
        Configure<WebViewViewModel, WebViewPage>();
        Configure<ListDetailsViewModel, ListDetailsPage>();
        Configure<DataGridViewModel, DataGridPage>();
        Configure<SettingsViewModel, SettingsPage>();
       
        Configure<sign_upViewModel, sign_upPage>();
        Configure<HomeViewModel, HomePage>();
        Configure<BlankViewModel, BlankPage>();
        Configure<RegDialogBoxViewModel, RegDialogBoxPage>();
        Configure<FailedLoginDialogBoxViewModel, FailedLoginDialogBoxPage>();
    }

    public Type GetPageType(string key)
    {
        Type? pageType;
        lock (_pages)
        {
            if (!_pages.TryGetValue(key, out pageType))
            {
                throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
            }
        }

        return pageType;
    }

    private void Configure<VM, V>()
        where VM : ObservableObject
        where V : Page
    {
        lock (_pages)
        {
            var key = typeof(VM).FullName!;
            if (_pages.ContainsKey(key))
            {
                throw new ArgumentException($"The key {key} is already configured in PageService");
            }

            var type = typeof(V);
            if (_pages.Any(p => p.Value == type))
            {
                throw new ArgumentException($"This type is already configured with key {_pages.First(p => p.Value == type).Key}");
            }

            _pages.Add(key, type);
        }
    }
}
