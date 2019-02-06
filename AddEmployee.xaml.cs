using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Employees
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddEmployee : Page
    {
        public AddEmployee()
        {
            this.InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var employee = new Employee()
            {
                Name = EmployeeNameTb.Text,
                Department = EmployeeDeptTb.Text
            };
            var employeejson = JsonConvert.SerializeObject(employee);
            var client=new HttpClient();
            var httpcontent=new StringContent(employeejson);
            httpcontent.Headers.ContentType=new MediaTypeHeaderValue("application/json");
            await client.PostAsync("http://localhost:62463/api/employees", httpcontent);
            Frame.Navigate(typeof(MainPage));
        }

        private void ButtonBase_OnClick1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
