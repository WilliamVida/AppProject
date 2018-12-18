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
        const double FIRST_BRACKET = 1304.2614956785728777421603815692;
        const double SECOND_BRACKET = 1214.3847973097594534676547727516;
        const double THIRD_BRACKET = 1635.9063612710611154962724693922;
        const double FOURTH_BRACKET = 1043.567598685452793705434706427;
        const double FIFTH_BRACKET = 1577.8794197950753479053159271241;
        const double SIXTH_BRACKET = 2582.3132460372396375276198767204;
        const double PAYROLL = 8146.6666666666666666666666666667;
        const double TAXABLE_CORPORATE_PROFITS = 1014.2857142857142857142857142857;
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
            ApprovalRating.Text = "";

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

            int EconomicApprovalRating = 0;

            if ((totRev - totSpend) > 0)
            {
                var budgetFormat = String.Format("Surplus: ${0:0.00} billion, as percentage of GDP: {1:0.00}%", totRev - totSpend, (totRev - totSpend) / 20660.00 * 100);
                SurplusBalanceDeficit.BackgroundColor = Color.Green;
                SurplusBalanceDeficit.Text = budgetFormat;

                if ((totRev - totSpend) > 600)
                {
                    EconomicApprovalRating += -100;
                }
                else if ((totRev - totSpend) > 400)
                {
                    EconomicApprovalRating += -55;
                }
                else if ((totRev - totSpend) > 200)
                {
                    EconomicApprovalRating += 10;
                }
                else if ((totRev - totSpend) > 0)
                {
                    EconomicApprovalRating += 15;
                }

                var DebtAfter = String.Format("Current debt: {0:0.00} billion, as percentage of GDP: {1:0.00}%\n", 21600.00 - (totRev - totSpend), (21600.00 - (totRev - totSpend)) / 20660.00 * 100);
                CurrentDebt.Text = DebtAfter;

                //var DebtPaid = String.Format("Assuming an annual GDP growth of 2% and the surplus grows at the same rate the debt will be paid in {0:0.00}", (totRev - totSpend) / 20660.00 * 100);
            }
            else if ((totRev - totSpend) < 0)
            {
                var budgetFormat = String.Format("Deficit: ${0:0.00} billion, as percentage of GDP: {1:0.00}%", totSpend - totRev, (totSpend - totRev) / 20660.00 * 100);
                SurplusBalanceDeficit.Text = budgetFormat;

                if ((totSpend - totRev) > 1000)
                {
                    EconomicApprovalRating += -75;
                }
                else if ((totSpend - totRev) > 750)
                {
                    EconomicApprovalRating += -60;
                }
                else if ((totSpend - totRev) > 500)
                {
                    EconomicApprovalRating += -40;
                }
                else if ((totSpend - totRev) > 250)
                {
                    EconomicApprovalRating += -25;
                }
                else if ((totSpend - totRev) > 0)
                {
                    EconomicApprovalRating += -10;
                }

                var DebtAfter = String.Format("Current debt: {0:0.00} billion, as percentage of GDP: {1:0.00}%\n", 21600.00 - (totSpend - totRev), (21600.00 + (totSpend - totRev)) / 20660.00 * 100);
                SurplusBalanceDeficit.BackgroundColor = Color.Red;
                CurrentDebt.Text = DebtAfter;
            }
            else
            {
                var budgetFormat = String.Format("Budget Balanced");
                SurplusBalanceDeficit.BackgroundColor = Color.Yellow;
                SurplusBalanceDeficit.Text = budgetFormat;

                var DebtAfter = String.Format("Current debt: {0:0.00} billion, as percentage of GDP: {1:0.00}%\n", 21600.00 - (totSpend - totRev), (21600.00 + (totSpend - totRev)) / 20660.00 * 100);
                CurrentDebt.Text = DebtAfter;
            }

            if (FirstBracket.Value < 4)
            {
                var opinion = String.Format("Lower class tax cuts.\n");
                like.Text += opinion;
                EconomicApprovalRating += 25;
            }
            else if (FirstBracket.Value > 4)
            {
                var opinion = String.Format("Lower class tax hikes.\n");
                dislike.Text += opinion;
                EconomicApprovalRating += -50;
            }

            if (SecondBracket.Value < 16 || ThirdBracket.Value < 18)
            {
                var opinion = String.Format("Middle class tax cuts.\n");
                like.Text += opinion;
                EconomicApprovalRating += 40;
            }
            else if (SecondBracket.Value > 16 || ThirdBracket.Value > 18)
            {
                var opinion = String.Format("Middle class tax hikes.\n");
                dislike.Text += opinion;
                EconomicApprovalRating += -30;
            }

            if (FourthBracket.Value < 21 || FifthBracket.Value < 24 || SixthBracket.Value < 27)
            {
                var opinion = String.Format("Tax cuts for the rich.\n");
                dislike.Text += opinion;
                var opinion2 = String.Format("Some people believe that lower taxes for the rich will encourage them to invest causing more employment and better growth.\n");
                like.Text += opinion2;
                EconomicApprovalRating += -25;
            }
            else if (FourthBracket.Value >= 32 || FifthBracket.Value >= 35 || SixthBracket.Value >= 42)
            {
                var opinion = String.Format("Tax rate is too high for the rich that could cause them to engage in tax evasion.\n");
                dislike.Text += opinion;
                EconomicApprovalRating += -50;
            }
            else if (FourthBracket.Value >= 25 || FifthBracket.Value >= 28 || SixthBracket.Value >= 34)
            {
                var opinion = String.Format("Tax rate is too high for the rich that could cause them to engage in tax evasion.\n");
                dislike.Text += opinion;
                var opinion2 = String.Format("Some people believe that rich people are paying their fair share of taxes.\n");
                like.Text += opinion2;
                EconomicApprovalRating += 15;
            }
            

            if (PayrollRate.Value > 20)
            {
                var opinion = String.Format("Payroll tax increase.\n");
                dislike.Text += opinion;
                EconomicApprovalRating += -100;
            }
            else if (PayrollRate.Value > 15)
            {
                var opinion = String.Format("Payroll tax increase.\n");
                dislike.Text += opinion;
                EconomicApprovalRating += -60;
            }
            else if (PayrollRate.Value < 15)
            {
                var opinion = String.Format("Payroll tax cut.\n");
                like.Text += opinion;
                EconomicApprovalRating += 60;
            }

            if (CorporateTaxRate.Value >= 35)
            {
                var opinion = String.Format("Some people believe that corporations should be paying more in taxes.\n");
                like.Text += opinion;
                var opinion2 = String.Format("Some people believe that companies are paying too much in taxes which is putting off investment in the US and/or causing them to engage in tax evasion.\n");
                dislike.Text += opinion2;
                EconomicApprovalRating += -5;
            }
            else if (CorporateTaxRate.Value < 35)
            {
                var opinion = String.Format("Some people believe that corporations should be paying less in taxes to attract more companies back in the US.\n");
                like.Text += opinion;
                var opinion2 = String.Format("Some people believe that companies are paying too little in taxes.\n");
                dislike.Text += opinion2;
                EconomicApprovalRating += 10;
            }



            if (HealthMan.Value >= 1200)
            {
                var opinion = String.Format("\nHealth spending increased.\n");
                like.Text += opinion;
                EconomicApprovalRating += 60;
            }
            else if (HealthMan.Value < 800)
            {
                var opinion = String.Format("Major health spending cut.\n");
                dislike.Text += opinion;
                EconomicApprovalRating += -100;
            }
            else if (HealthMan.Value < 950)
            {
                var opinion = String.Format("Major health spending cut.\n");
                dislike.Text += opinion;
                EconomicApprovalRating += -75;
            }
            else if (HealthMan.Value < 1150)
            {
                var opinion = String.Format("Health spending cut.\n");
                dislike.Text += opinion;
                EconomicApprovalRating += -50;
            }
           
            if (SocialSecurityMan.Value >= 1400)
            {
                var opinion = String.Format("Social Security spending increased.\n");
                like.Text += opinion;
                EconomicApprovalRating += 60;
            }
            else if (SocialSecurityMan.Value < 1000)
            {
                var opinion = String.Format("Major Social Security spending cut.\n");
                dislike.Text += opinion;
                EconomicApprovalRating += -75;
            }
            else if (SocialSecurityMan.Value < 1200)
            {
                var opinion = String.Format("Major Social Security spending cut.\n");
                dislike.Text += opinion;
                EconomicApprovalRating += -50;
            }
            else if (SocialSecurityMan.Value < 1350)
            {
                var opinion = String.Format("Social Security spending cut.\n");
                dislike.Text += opinion;
                EconomicApprovalRating += -20;
            }

            if (AgricultureMan.Value > 140)
            {
                var opinion = String.Format("Agriculture spending increased.\n");
                like.Text += opinion;
                EconomicApprovalRating += 20;
            }
            else if (AgricultureMan.Value < 130)
            {
                var opinion = String.Format("Agriculture spending cut.\n");
                dislike.Text += opinion;
                EconomicApprovalRating += -15;
            }

            if (VeteransMan.Value >= 180)
            {
                var opinion = String.Format("Veterans' Benefits spending increased.\n");
                like.Text += opinion;
                EconomicApprovalRating += 30;
            }
            else if (VeteransMan.Value < 179)
            {
                var opinion = String.Format("Veterans' Benefits spending cut.\n");
                dislike.Text += opinion;
                EconomicApprovalRating += -50;
            }

            if (TransportationMan.Value >= 109)
            {
                var opinion = String.Format("Transportation spending increased.\n");
                like.Text += opinion;
                EconomicApprovalRating += 30;
            }
            else if (TransportationMan.Value > 109)
            {
                var opinion = String.Format("Transportation spending cut.\n");
                dislike.Text += opinion;
                EconomicApprovalRating += -15;
            }

            if (MilitaryDisc.Value >= 900)
            {
                var opinion = String.Format("Many people think that the budget is too high.\n");
                dislike.Text += opinion;
                EconomicApprovalRating += -10;
            }
            else if (MilitaryDisc.Value >= 623)
            {
                var opinion = String.Format("Military budget increased.\n");
                like.Text += opinion;
                EconomicApprovalRating += 60;
            }
            else if (MilitaryDisc.Value < 600)
            {
                var opinion = String.Format("Military budget cut.\n");
                dislike.Text += opinion;
                EconomicApprovalRating += -70;
            }

            if (EducationDisc.Value >= 120)
            {
                var opinion = String.Format("Education spending increases.\n");
                like.Text += opinion;
                EconomicApprovalRating += 40;
            }
            else if (EducationDisc.Value >= 85)
            {
                var opinion = String.Format("Education spending increases.\n");
                like.Text += opinion;
                EconomicApprovalRating += 20;
            }
            else if (EducationDisc.Value < 85)
            {
                var opinion = String.Format("Education spending cuts.\n");
                dislike.Text += opinion;
                EconomicApprovalRating += -20;
            }

            if (GovernmentDisc.Value >= 69)
            {
                var opinion = String.Format("The people feel safer.\n");
                like.Text += opinion;
                EconomicApprovalRating += 20;
            }
            else if (GovernmentDisc.Value < 69)
            {
                var opinion = String.Format("The people feel less safe.\n");
                dislike.Text += opinion;
                EconomicApprovalRating += -15;
            }

            if (AffairsDisc.Value >= 41)
            {
                var opinion = String.Format("Most people don't like the Foreign affairs spending increase.\n");
                like.Text += opinion;
                dislike.Text += opinion;
                EconomicApprovalRating += -40;
            }

            if (EnergyDisc.Value >= 51)
            {
                var opinion = String.Format("Energy spending increased.\n");
                like.Text += opinion;
                EconomicApprovalRating += 10;
            }
            else if (EnergyDisc.Value < 51)
            {
                var opinion = String.Format("Energy spending cut.\n");
                dislike.Text += opinion;
                EconomicApprovalRating += -10;
            } 

            if (ScienceDisc.Value >= 75)
            {
                var opinion = String.Format("Major Science spending increase.\n");
                like.Text += opinion;
                EconomicApprovalRating += 30;
            }
            else if (ScienceDisc.Value >= 31)
            {
                var opinion = String.Format("Science spending increased.\n");
                like.Text += opinion;
                EconomicApprovalRating += 15;
            }
            else if (ScienceDisc.Value < 69)
            {
                var opinion = String.Format("Science spending cut.\n");
                dislike.Text += opinion;
                EconomicApprovalRating += -20;
            }

            if (EconomicApprovalRating < 0)
            {
                EconomicApprovalRating = 0;
                var lessThan0 = String.Format("Economic approval rating: {0:0}%", EconomicApprovalRating);
                ApprovalRating.Text += lessThan0;
            }
            else if (EconomicApprovalRating > 100)
            {
                EconomicApprovalRating = 100;
                var greaterThan100 = String.Format("Economic approval rating: {0:0}%", EconomicApprovalRating);
                ApprovalRating.Text += greaterThan100;
            }
            else
            {
                var approvalString = String.Format("Economic approval rating: {0:0}%", EconomicApprovalRating);
                ApprovalRating.Text += approvalString;
            }            
        }
    }
}
