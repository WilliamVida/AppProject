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
        const double FIRST_BRACKET = 1304.2614956785728777421603815692; // 1128.00
        const double SECOND_BRACKET = 1214.3847973097594534676547727516; // 1050.00
        const double THIRD_BRACKET = 1635.9063612710611154962724693922; // 1415.00
        const double FOURTH_BRACKET = 1043.567598685452793705434706427; // 903.00
        const double FIFTH_BRACKET = 1577.8794197950753479053159271241; // 1365.00
        const double SIXTH_BRACKET = 2582.3132460372396375276198767204; //2234.00
        const double PAYROLL = 8146.6666666666666666666666666667;
        const double TAXABLE_CORPORATE_PROFITS = 1014.2857142857142857142857142857; // 1014.00
        const double MISC_REVENUE = 294.00;

        const double INTEREST_PAYMENTS = 316.00;

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
                              + MilitaryDisc.Value + EducationDisc.Value + GovernmentDisc.Value + HousingDisc.Value + AffairsDisc.Value
                              + EnergyDisc.Value + ScienceDisc.Value + INTEREST_PAYMENTS;

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
                             + MilitaryDisc.Value + EducationDisc.Value + GovernmentDisc.Value + HousingDisc.Value + AffairsDisc.Value
                             + EnergyDisc.Value + ScienceDisc.Value + INTEREST_PAYMENTS;

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
