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
        const double FIRST_BRACKET = 1028.125; //1144545
        const double SECOND_BRACKET = 959.3875; //8998075
        const double THIRD_BRACKET = 1294.983333333333; //6997737
        const double FOURTH_BRACKET = 762.6380952380952; //4803327
        const double FIFTH_BRACKET = 1244.791666666667; //1563,650
        const double SIXTH_BRACKET = 2102.581481481481; //2094906
        const double TAXABLE_CORPORATE_PROFITS = 977.1428571428571;

        double surdef;

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
                         (CorporateTaxRate.Value / 100 * TAXABLE_CORPORATE_PROFITS);
            surdef = totRev;

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
                         (CorporateTaxRate.Value / 100 * TAXABLE_CORPORATE_PROFITS);

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
