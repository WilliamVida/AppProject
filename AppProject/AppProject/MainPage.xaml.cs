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
            double totSpend = HealthMan.Value + SocialSecurityMan.Value + AgricultureMan.Value + VeteransMan.Value + TransportationMan.Value +
                              MilitaryDisc.Value + EducationDisc.Value + GovernmentDisc.Value + HousingDisc.Value + AffairsDisc.Value +
                              EnergyDisc.Value + ScienceDisc.Value + INTEREST_PAYMENTS;

            var spendingFormat = String.Format("Total Spending: ${0:0.00} Billion", totSpend);
            TotalSpending.Text = spendingFormat;
        }

        private void RevenueMinusSpending(object sender, ValueChangedEventArgs e)
        {
            like.Text = "";
            dislike.Text = "";

            double totRev = (FirstBracket.Value / 100 * FIRST_BRACKET) +
                            (SecondBracket.Value / 100 * SECOND_BRACKET) +
                            (ThirdBracket.Value / 100 * THIRD_BRACKET) +
                            (FourthBracket.Value / 100 * FOURTH_BRACKET) +
                            (FifthBracket.Value / 100 * FIFTH_BRACKET) +
                            (SixthBracket.Value / 100 * SIXTH_BRACKET) +
                            (PayrollRate.Value / 100 * PAYROLL) +
                            (CorporateTaxRate.Value / 100 * TAXABLE_CORPORATE_PROFITS) +
                            (MISC_REVENUE);

            double totSpend = HealthMan.Value + SocialSecurityMan.Value + AgricultureMan.Value + VeteransMan.Value + TransportationMan.Value +
                              MilitaryDisc.Value + EducationDisc.Value + GovernmentDisc.Value + HousingDisc.Value + AffairsDisc.Value +
                              EnergyDisc.Value + ScienceDisc.Value + INTEREST_PAYMENTS;

            if ((totRev - totSpend) > 0)
            {
                var budgetFormat = String.Format("Surplus of: ${0:0.00} Billion, as percentage of GDP: {1:0.00}%", totRev - totSpend, (totRev - totSpend) / 20660.00 * 100);
                SurplusBalanceDeficit.Text = budgetFormat;
            }
            else if ((totRev - totSpend) < 0)
            {
                var budgetFormat = String.Format("Deficit of: ${0:0.00} Billion, as percentage of GDP: {1:0.00}%", totSpend - totRev, (totSpend - totRev) / 20660.00 * 100);
                SurplusBalanceDeficit.Text = budgetFormat;
            }
            else
            {
                var budgetFormat = String.Format("Budget Balanced");
                SurplusBalanceDeficit.Text = budgetFormat;
            }

            if (FirstBracket.Value < 4)
            {
                var opinion = String.Format("Lower class tax cuts.\n");
                like.Text += opinion;
            }
            else if (FirstBracket.Value > 4)
            {
                var opinion = String.Format("Lower class tax hikes.\n");
                dislike.Text += opinion;
            }

            if (SecondBracket.Value < 16 || ThirdBracket.Value < 18)
            {
                var opinion = String.Format("Middle class tax cuts.\n");
                like.Text += opinion;
            }
            else if (SecondBracket.Value > 16 || ThirdBracket.Value > 18)
            {
                var opinion = String.Format("Middle class tax hikes.\n");
                dislike.Text += opinion;
            }

            if (FourthBracket.Value < 21 || FifthBracket.Value < 24 || SixthBracket.Value < 27)
            {
                var opinion = String.Format("Tax cuts for the rich.\n");
                dislike.Text += opinion;
                var opinion2 = String.Format("Some people believe that lower taxes for the rich will encourage them to invest causing more employment and better growth.\n");
                dislike.Text += opinion2;
            }

            if (FourthBracket.Value >= 25 || FifthBracket.Value >= 28 || SixthBracket.Value >= 34)
            {
                var opinion = String.Format("Tax rate is too high for the rich that could cause them to engage in tax evasion.\n");
                dislike.Text += opinion;
                var opinion2 = String.Format("Some people believe that rich people are paying their fair share of taxes.\n");
                like.Text += opinion2;
            }

            if (PayrollRate.Value > 15)
            {
                var opinion = String.Format("Payroll tax increase.\n");
                dislike.Text += opinion;
            }
            else if (PayrollRate.Value < 15)
            {
                var opinion = String.Format("Payroll tax cut.\n");
                like.Text += opinion;
            }
            else
            {

            }

            if (CorporateTaxRate.Value >= 35)
            {
                var opinion = String.Format("Some people believe that corporations should be paying more in taxes.\n");
                like.Text += opinion;
                var opinion2 = String.Format("Some people believe that companies are paying too much in taxes which is putting off investment in the US and/or causing them to engage in tax evasion.\n");
                dislike.Text += opinion2;
            }
            else if (CorporateTaxRate.Value < 35)
            {
                var opinion = String.Format("Some people believe that corporations should be paying less in taxes to attract more companies back in the US.\n");
                like.Text += opinion;
                var opinion2 = String.Format("Some people believe that companies are paying too little in taxes.\n");
                dislike.Text += opinion2;
            }



            if (HealthMan.Value >= 1179)
            {
                var opinion = String.Format("\nHealth spending increased.\n");
                like.Text += opinion;
            }
            else if (HealthMan.Value < 1179)
            {
                var opinion = String.Format("Health spending cut.\n");
                dislike.Text += opinion;
            }

            if (SocialSecurityMan.Value >= 1392)
            {
                var opinion = String.Format("Social Security spending increased.\n");
                like.Text += opinion;
            }
            else if (SocialSecurityMan.Value < 1392)
            {
                var opinion = String.Format("Social Security spending cut.\n");
                dislike.Text += opinion;
            }

            if (AgricultureMan.Value >= 139)
            {
                var opinion = String.Format("Agriculture spending increased.\n");
                like.Text += opinion;
            }
            else if (AgricultureMan.Value < 1392)
            {
                var opinion = String.Format("Agriculture spending cut.\n");
                dislike.Text += opinion;
            }

            if (VeteransMan.Value >= 179)
            {
                var opinion = String.Format("Veterans' Benefits spending increased.\n");
                like.Text += opinion;
            }
            else if (VeteransMan.Value > 179)
            {
                var opinion = String.Format("Veterans' Benefits spending cut.\n");
                dislike.Text += opinion;
            }

            if (TransportationMan.Value >= 179)
            {
                var opinion = String.Format("Transportation spending increased.\n");
                like.Text += opinion;
            }
            else if (TransportationMan.Value > 179)
            {
                var opinion = String.Format("Transportation spending cut.\n");
                dislike.Text += opinion;
            }

            if (MilitaryDisc.Value >= 900)
            {
                var opinion = String.Format("Many people think that the budget is too high.\n");
                dislike.Text += opinion;
            }
            if (MilitaryDisc.Value >= 623)
            {
                var opinion = String.Format("Military budget increased.\n");
                like.Text += opinion;
            }
            else if (MilitaryDisc.Value < 623)
            {
                var opinion = String.Format("Military budget cut.\n");
                dislike.Text += opinion;
            }

            if (EducationDisc.Value >= 85)
            {
                var opinion = String.Format("Education spending increases.\n");
                like.Text += opinion;
            }
            else if (EducationDisc.Value < 85)
            {
                var opinion = String.Format("Education spending cuts.\n");
                dislike.Text += opinion;
            }

            if (GovernmentDisc.Value >= 69)
            {
                var opinion = String.Format("The people feel safer.\n");
                like.Text += opinion;
            }
            else if (GovernmentDisc.Value < 69)
            {
                var opinion = String.Format("The people feel less safe.\n");
                dislike.Text += opinion;
            }

            if (AffairsDisc.Value >= 41)
            {
                var opinion = String.Format("Foreign affairs spending increased.\n");
                like.Text += opinion;
                dislike.Text += opinion;
            }

            if (EnergyDisc.Value >= 51)
            {
                var opinion = String.Format("Energy spending increased.\n");
                like.Text += opinion;
            }
            else if (EnergyDisc.Value < 51)
            {
                var opinion = String.Format("Energy spending cut.\n");
                dislike.Text += opinion;
            } 

            if (ScienceDisc.Value >= 31)
            {
                var opinion = String.Format("Science spending increased.\n");
                like.Text += opinion;
            }
            else if (ScienceDisc.Value < 69)
            {
                var opinion = String.Format("Science spending cut.\n");
                dislike.Text += opinion;
            }

        }

    }
}
