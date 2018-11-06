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
        const double LESS_THAN_25000 = 20;
        const double SECOND_BRACKET = 0;
        const double THIRD_BRACKET = 0;
        const double FOURTH_BRACKET = 0;
        const double FIFTH_BRACKET = 0;

        const double TAXABLE_CORPORATE_PROFITS = 848.57;

        public MainPage()
        {
            InitializeComponent();
        }

        private void submit_Clicked(object sender, EventArgs e)
        {
            double corprev = Convert.ToDouble(CorporateTaxRate.Value);
            double tax = (corprev / 100) * TAXABLE_CORPORATE_PROFITS;

            var taxOutput = String.Format("Total Revenue: ${0:0.00} Billion", tax);

            TotalRevenue.Text = taxOutput;
        }

        //private void CorporateTaxRate_ValueChanged(object sender, ValueChangedEventArgs e)
        //{
        //    var totRev = CorporateTaxRate.Value / 100 * TAXABLE_CORPORATE_PROFITS;
        //    var taxOutput = String.Format("Total Revenue: ${0:0.00} Billion", totRev);

        //    RevenueTest.Text = taxOutput;
        //}

        //private void LessThan25_ValueChanged(object sender, ValueChangedEventArgs e)
        //{
        //    var totRev = LessThan25.Value / 100 * LESS_THAN_25000;
        //    var taxOutput = String.Format("Total Revenue: ${0:0.00} Billion", totRev);

        //    RevenueTest.Text = taxOutput;
        //}

        private void TotalSliderRevenue_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var totRev = (LessThan25.Value / 100 * LESS_THAN_25000) + 
                         (CorporateTaxRate.Value / 100 * TAXABLE_CORPORATE_PROFITS);

            var taxOutput = String.Format("Total Revenue: ${0:0.00} Billion", totRev);
            RevenueTest.Text = taxOutput;
        }
    }
}
