using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace esome
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private Dictionary<string, ContentView> SubViews = new Dictionary<string, ContentView>();
        public MainPage()
        {
            InitializeComponent();
        }
        int count = 0;
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            count++;
            ((Button)sender).Text = $"You clicked {count} times.";
        }

        private void Math_Clicked(object sender, EventArgs e)
        {
            if (!SubViews.ContainsKey("Math"))
            {
                SubViews.Add("Math", new SubPage.MathView());
            }
            controls.Content = SubViews["Math"];
        }

        private void Meter_Clicked(object sender, EventArgs e)
        {
            if (!SubViews.ContainsKey("Meter"))
            {
                SubViews.Add("Meter", new SubPage.MeterView());
            }
            controls.Content = SubViews["Meter"];
        }

        private void Bluetooth_Clicked(object sender, EventArgs e)
        {
            if (!SubViews.ContainsKey("Blue"))
            {
                SubViews.Add("Blue", new SubPage.BlueView());
            }
            controls.Content = SubViews["Blue"];
        }

        private void PhaseSequence_Clicked(object sender, EventArgs e)
        {
            if (!SubViews.ContainsKey("PS"))
            {
                SubViews.Add("PS", new SubPage.PhaseSequenceView());
            }
            controls.Content = SubViews["PS"];
        }
    }
}
