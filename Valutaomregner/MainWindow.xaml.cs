using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace Valutaomregner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        float v1;
        float v2;
        public MainWindow()
        {
            InitializeComponent();


            XDocument currencys = XDocument.Load("http://www.nationalbanken.dk/_vti_bin/DN/DataService.svc/CurrencyRatesXML?lang=da");
          
           
            foreach (var currency in currencys.Descendants("currency"))
            {
                var newItem1 = new ComboBoxItem();
                newItem1.Content = currency.Attribute("code").Value;
                newItem1.Tag = currency.Attribute("rate").Value;
                var newItem2 = new ComboBoxItem();
                newItem2.Content = currency.Attribute("code").Value;
                newItem2.Tag = currency.Attribute("rate").Value;

                combo1.Items.Add(newItem1);
                combo2.Items.Add(newItem2);
            }
            v1 = Getvaluta(1);
            v2 = Getvaluta(2);
        }

        private void ChangeK(object sender, EventArgs e)
        {
            ComboBox box = sender as ComboBox;
            if(box.Name == "combo1")
            {
                v1 = Getvaluta(1);
            }
            else if(box.Name == "combo2")
            {
                v2 = Getvaluta(2);
            }
            if (box.Name == "combo1")
            {
                Currency(2);
            }
            else if (box.Name == "combo2")
            {
                Currency(1);
            }

        }
        public float Getvaluta(int id)
        {
            switch (id)
            {
                case 1:
                    return float.Parse(((ComboBoxItem)combo1.SelectedItem).Tag.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                case 2:
                    return float.Parse(((ComboBoxItem)combo2.SelectedItem).Tag.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                default:
                    return 0;
                  

            }
        }


        

        private void Value_PreviewKeyUp(object sender, KeyEventArgs e)
        {

            TextBox value = sender as TextBox;
            if(value.Name == "value1")
            {
                Currency(1);
            }
            else if (value.Name == "value2")
            {
                Currency(2);
            }

              
            
        }
        public void Currency(int id)
        {
            bool is1Num = float.TryParse(value1.Text, out float num1);
            bool is2Num = float.TryParse(value2.Text, out float num2);

            if ((!is1Num) && (id == 1))
            {
                value2.Text = "not a number";
            }
            else if ((!is2Num) && (id == 2))
            {
                value1.Text = "not a number";
            }
            else
            {
                
                    if (id == 1)
                    {
                        value2.Text = (v1/v2*num1).ToString();

                    }
                    else if (id == 2)
                    {
                        value1.Text = (v2 / v1 * num2).ToString();

                    }
                
            }
        }

        private void SwitchValue(object sender, MouseButtonEventArgs e)
        {
            var a = value1.Text;
            var b = value2.Text;
            var c = combo1.SelectedIndex;
            var d = combo2.SelectedIndex;
            value1.Text = b;
            value2.Text = a;
            combo1.SelectedIndex = d;
            combo2.SelectedIndex = c;
        }
    }

}



