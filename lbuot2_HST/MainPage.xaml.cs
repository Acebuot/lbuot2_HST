using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace lbuot2_HST
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            if (correctBrush == null)
                correctBrush = txtSales.Foreground;
        }
        private SolidColorBrush errorBrush = new SolidColorBrush(Windows.UI.Colors.Red);
        private Brush correctBrush = null;
        private decimal s;

        private decimal hst;
        private decimal c;
        private decimal r;
        private decimal k;
        private decimal months;

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lblHst.Text = "Total HST";
            lblExtraCredit.Text = "Extra Credit on First 30k";
            lblRemit.Text = "Total Remittance Owed";
            lblKeep.Text = "Net Income";
            txtSales.Text = "";
            radMonthly.IsChecked = true;

            lblInstallment.Text = "Payment per Installment";

        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {

            //check if it input can't be parsed
            if (!decimal.TryParse(txtSales.Text.ToString(), out s))
                txtSales.Foreground = errorBrush;
            else if (s < 0) //Why hire me to make this software if you losing money, here man. 5 bucks :)
                txtSales.Foreground = errorBrush;
            else
            {
                try
                {

                    if (radMonthly.IsChecked == true)
                        months = 12;
                    else
                        months = 4;

                    hst = TaxTime.hst(s);
                    c = TaxTime.c(s);
                    r = TaxTime.r(s, c);
                    k = TaxTime.k(hst, r);


                    lblHst.Text = $"Total HST: {hst.ToString("C")}";
                    lblExtraCredit.Text = $"Extra Credit on First 30k: {c.ToString("c")}";
                    lblRemit.Text = $"Total Remittance Owed: {r.ToString("c")}";
                    lblKeep.Text = $"Net Income: {k.ToString("c")}";
                    lblInstallment.Text = $"Payment per Installment: {TaxTime.installment(r, months).ToString("c")}";
                }
                catch
                {
                    
                }

            }


        }

        private void txtSales_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtSales.Foreground = correctBrush;
        }
    }
}
