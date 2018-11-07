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
        const double FIRST_BRACKET = 1145; //1144545
        const double SECOND_BRACKET = 8998; //8998075
        const double THIRD_BRACKET = 6998; //6997737
        const double FOURTH_BRACKET = 4803; //4803327
        const double FIFTH_BRACKET = 3659; //3658556
        const double SIXTH_BRACKET = 2095; //2094906

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

        private void TotalSliderRevenue_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var totRev = (FirstBracket.Value / 100 * FIRST_BRACKET) +
                         (SecondBracket.Value / 100 * SECOND_BRACKET) +
                         (ThirdBracket.Value / 100 * THIRD_BRACKET) +
                         (FourthBracket.Value / 100 * FOURTH_BRACKET) +
                         (FifthBracket.Value / 100 * FIFTH_BRACKET) +
                         (SixthBracket.Value / 100 * SIXTH_BRACKET) +
                         (CorporateTaxRate.Value / 100 * TAXABLE_CORPORATE_PROFITS);

            var taxOutput = String.Format("Total Revenue: ${0:0.00} Billion", totRev);
            RevenueTest.Text = taxOutput;
        }
    }
}
