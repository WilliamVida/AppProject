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
        const double FIRST_BRACKET = 1128.1861937619655392469687300574; // 1128.00
        const double SECOND_BRACKET = 1050.4428496729419272495213784301; // 1050.00
        const double THIRD_BRACKET = 1415.0590024994678649042756860242; // 1415.00
        const double FOURTH_BRACKET = 902.68597286291666655520102105934; // 903.00
        const double FIFTH_BRACKET = 1364.8656981227401759380982769623; // 1365.00
        const double SIXTH_BRACKET = 2233.7009578222122864613911933631; //2234.00
        const double PAYROLL = 7753.3333333333333333333333333333; // 7753.00
        const double TAXABLE_CORPORATE_PROFITS = 848.57142857142857142857142857143; // 849.00
        const double MISC_REVENUE = 269;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void statisticsPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Statistics());
        }

        private void TotalRevenue_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var totRev = (FirstBracket.Value / 100 * FIRST_BRACKET) +
                         (SecondBracket.Value / 100 * SECOND_BRACKET) +
                         (ThirdBracket.Value / 100 * THIRD_BRACKET) +
                         (FourthBracket.Value / 100 * FOURTH_BRACKET) +
                         (FifthBracket.Value / 100 * FIFTH_BRACKET) +
                         (SixthBracket.Value / 100 * SIXTH_BRACKET) +
                         (PayrollRate.Value / 100 * PAYROLL) +
                         (CorporateTaxRate.Value / 100 * TAXABLE_CORPORATE_PROFITS) +
                         (MISC_REVENUE);

            var revenueFormat = String.Format("Total Revenue: ${0:0.00} Billion", totRev);
            TotalRevenue.Text = revenueFormat;
        }

        private void TotalSpending_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double totSpend = HealthMan.Value + SocialSecurityMan.Value + AgricultureMan.Value + VeteransMan.Value + TransportationMan.Value
                              + MilitaryDisc.Value + VeteransDisc.Value + EducationDisc.Value + GovernmentDisc.Value + HousingDisc.Value
                              + HealthDisc.Value + AffairsDisc.Value + EnergyDisc.Value + SocialSecurityDisc.Value + ScienceDisc.Value
                              + TransportationDisc.Value + AgricultureDisc.Value + Interest.Value;

            var spendingFormat = String.Format("Total Spending: ${0:0.00} Billion", totSpend);
            TotalSpending.Text = spendingFormat;
        }

        private void RevenueMinusSpending(object sender, ValueChangedEventArgs e)
        {
            double totRev = (FirstBracket.Value / 100 * FIRST_BRACKET) +
                         (SecondBracket.Value / 100 * SECOND_BRACKET) +
                         (ThirdBracket.Value / 100 * THIRD_BRACKET) +
                         (FourthBracket.Value / 100 * FOURTH_BRACKET) +
                         (FifthBracket.Value / 100 * FIFTH_BRACKET) +
                         (SixthBracket.Value / 100 * SIXTH_BRACKET) +
                         (PayrollRate.Value / 100 * PAYROLL) +
                         (CorporateTaxRate.Value / 100 * TAXABLE_CORPORATE_PROFITS) +
                         (MISC_REVENUE);

            double totSpend = HealthMan.Value + SocialSecurityMan.Value + AgricultureMan.Value + VeteransMan.Value + TransportationMan.Value
                             + MilitaryDisc.Value + VeteransDisc.Value + EducationDisc.Value + GovernmentDisc.Value + HousingDisc.Value
                             + HealthDisc.Value + AffairsDisc.Value + EnergyDisc.Value + SocialSecurityDisc.Value + ScienceDisc.Value
                             + TransportationDisc.Value + AgricultureDisc.Value + Interest.Value;

            if ((totRev - totSpend) > 0)
            {
                var spendingFormat = String.Format("Surplus of: ${0:0.00} Billion", totRev - totSpend);
                SurplusBalanceDeficit.Text = spendingFormat;
            }
            else if ((totRev - totSpend) < 0)
            {
                var spendingFormat = String.Format("Deficit of: ${0:0.00} Billion", totSpend - totRev);
                SurplusBalanceDeficit.Text = spendingFormat;
            }
            else
            {
                var spendingFormat = String.Format("Budget Balanced");
                SurplusBalanceDeficit.Text = spendingFormat;
            }
        }
    }
}
