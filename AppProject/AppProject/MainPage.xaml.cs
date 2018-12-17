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
                var budgetFormat = String.Format("Deficit of: ${0:0.00} Billion, as percentage of GDP: %{1:0.00}", totSpend - totRev, (totSpend - totRev) / 20660.00 * 100);
                SurplusBalanceDeficit.Text = budgetFormat;
            }
            else
            {
                var budgetFormat = String.Format("Budget Balanced");
                SurplusBalanceDeficit.Text = budgetFormat;
            }

            if (MilitaryDisc.Value > 623)
            {
                var opinion = String.Format("Military budget increased.\n");
                like.Text += opinion;
            }
            else if (MilitaryDisc.Value < 623)
            {
                var opinion = String.Format("Military budget cut.\n");
                dislike.Text += opinion;
            }

            if (HealthMan.Value > 1179)
            {
                var opinion = String.Format("Heath spending increased.\n");
                like.Text += opinion;
            }
            else if (HealthMan.Value < 1179)
            {
                var opinion = String.Format("Heath spending cut.\n");
                dislike.Text += opinion;
            }
        
            if (SocialSecurityMan.Value > 1392)
            {
                var opinion = String.Format("Social Security spending increased.\n");
                like.Text += opinion;
            }
            else if (SocialSecurityMan.Value < 1392)
            {
                var opinion = String.Format("Social Security spending cut.\n");
                dislike.Text += opinion;
            }

            if (VeteransMan.Value > 179)
            {
                var opinion = String.Format("Veterans' Benefits spending increased.\n");
                like.Text += opinion;
            }
            else if (VeteransMan.Value > 179)
            {
                var opinion = String.Format("Veterans' Benefits spending cut.\n");
                dislike.Text += opinion;
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
                var opinion = String.Format("Middle class tax cuts.");
                like.Text += opinion;
            }
            else if (SecondBracket.Value > 16 || ThirdBracket.Value > 18)
            {
                var opinion = String.Format("Middle class tax hikes.");
                dislike.Text += opinion;
            }

            if (FourthBracket.Value < 21 || FifthBracket.Value < 24 || SixthBracket.Value < 27)
            {
                var opinion = String.Format("Tax cuts for the rich.");
                dislike.Text += opinion;
            }

        }

        private void ApprovedActions()
        {
            // the people like your tax cuts
            // ss increases
            // education increases

            if (MilitaryDisc.Value > 623)
            {
                var opinion = String.Format("Military increased");
                like.Text = opinion;
            }
            if (HealthMan.Value > 1179)
            {
                var opinion = String.Format("Budget Balanced");
                like.Text += opinion;
            }
        }

        private void DisApprovedActions()
        {
            // tax increases
            // health cuts
            // ss cuts
            // education cuts
            // tax cuts for the wealthy
            // tax cuts increased deficit
        }
    }
}
