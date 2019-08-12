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
            
        }

        private void ChangeK(object sender, EventArgs e)
        {
            ComboBox box = sender as ComboBox;
            if(box.Name == "combo1")
            {
                //v1 = float.Parse(((ComboBoxItem)combo1.SelectedItem).Tag.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            }
            else if(box.Name == "combo1")
            {
                //v2 = float.Parse(((ComboBoxItem)combo2.SelectedItem).Tag.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            }


        }
    }

}



