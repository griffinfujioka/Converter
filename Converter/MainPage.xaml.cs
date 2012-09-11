using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Converter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        public void textChanged(string sender, string line)
        {
            int decValue;
            string hexValue;
            string binaryValue;
            switch (sender)
            {
                case "binary":
                    decValue = Convert.ToInt32(line);
                    hexValue = decValue.ToString("X");
                    hexTxtBox.Text = hexValue;
                    decimalTxtBox.Text = decValue.ToString();
                    break; 
                case "decimal":
                    decValue = Convert.ToInt32(line);
                    binaryValue = Convert.ToString(decValue, 2);
                    hexValue = decValue.ToString("X");
                    hexTxtBox.Text = hexValue;
                    binaryTxtBox.Text = binaryValue;
                    break; 
                case "hex":
                    decValue = int.Parse(line, System.Globalization.NumberStyles.HexNumber);
                    binaryValue = Convert.ToString(decValue, 2);
                    binaryTxtBox.Text = binaryValue;
                    decimalTxtBox.Text = decValue.ToString();
                    break; 
                default: break; 
            }
        }

        private void hexTxtBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            string line;
            string hexValue = ""; 
            string binaryValue;
            int decValue;

            hexTxtBox.Text = sender.ToString(); 

            line = hexTxtBox.Text;

            textChanged("hex", line); 
            //if (line != "")
            //{
            //    decValue = int.Parse(line, System.Globalization.NumberStyles.HexNumber);
            //    binaryValue = Convert.ToString(decValue, 2);
            //    binaryTxtBox.Text = binaryValue;
            //    decimalTxtBox.Text = decValue.ToString();
            //}
            //else
            //{
            //    binaryTxtBox.Text = "";
            //    decimalTxtBox.Text = ""; 
            //}
        }

        private void decimalTxtBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            string line;
            int decValue;
            string binaryValue;
            string hexValue; 
            
            line = decimalTxtBox.Text;
            textChanged("decimal", line); 
            //if (line != "")
            //{
            //    decValue = Convert.ToInt32(line);
            //    binaryValue = Convert.ToString(decValue, 2);
            //    hexValue = decValue.ToString("X");
            //    hexTxtBox.Text = hexValue;
            //    binaryTxtBox.Text = binaryValue;
            //}
            //else
            //{
            //    hexTxtBox.Text = "";
            //    binaryTxtBox.Text = ""; 
            //}
            
        }

        private void binaryTxtBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            string line = string.Empty; 
            string hexValue;
            int decValue;
            
            
            line = binaryTxtBox.Text;
            textChanged("binary", line); 
            //if (line != "")
            //{
            //    decValue = Convert.ToInt32(line);
            //    hexValue = decValue.ToString("X");
            //    hexTxtBox.Text = hexValue;
            //    decimalTxtBox.Text = decValue.ToString();

            //}
            //else
            //{
            //    hexTxtBox.Text = "";
            //    decimalTxtBox.Text = ""; 
            //}
        }

        
    }
}
