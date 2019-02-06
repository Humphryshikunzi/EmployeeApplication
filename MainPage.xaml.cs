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
using System.Net.Http;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Employees
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            HttpClient http=new HttpClient();
            var clientresponse = await http.GetStringAsync("http://localhost:62463/api/employees");
            var employeesresponse = JsonConvert.DeserializeObject<List<Employee>>(clientresponse);
            EmployeesListBox.ItemsSource = employeesresponse;

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddEmployee));
        }

        private void EmployeesListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var employee = EmployeesListBox.SelectedItem as Employee;
            Frame.Navigate(typeof(EditEmployee),employee);
        }
    }
}
