using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FmcPush
{
    public partial class MainPage : ContentPage
    {
        private readonly ObservableCollection<LogItem> logs = new ObservableCollection<LogItem>();

        public MainPage()
        {
            InitializeComponent();
            listView.ItemsSource = logs;
        }

        public void LogMessage(string msg)
        {
            logs.Add(new LogItem
            {
                Date = DateTime.Now,
                Message = msg
            });


        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            logs.Clear();
        }
    }
}
