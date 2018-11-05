using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppProject
{
    public partial class MainPage : ContentPage
    {
        const double TAXABLE_CORPORATE_PROFITS = 848.57;

        myAdder calc = new myAdder();

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = calc;
        }

        private void submit_Clicked(object sender, EventArgs e)
        {
            double corprev = Convert.ToDouble(AllRev.Value);
            double tax = corprev * TAXABLE_CORPORATE_PROFITS;
            var taxOutput = String.Format("Total Revenue: ${0:0.00} Billion", tax);

            Earnings1.Text = taxOutput;
        }

    }
}
