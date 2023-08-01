using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using FirstApp.Views;
using Microsoft.UI.Xaml.Controls;
using FirstApp.ViewModels;
using Microsoft.UI.Xaml;
using Style = Microsoft.UI.Xaml.Style;
using FirstApp.Contracts.Services;

namespace FirstApp.Models;
public class MainPageModel : INotifyPropertyChanged
{
    private string _email;
    private string _password;

    public string Email
    {
        get {return _email; }

        set{ _email = value;}
    }
    public string Password
    {
        get
        {return _password;}
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
  
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));  
    }

}



   

   
