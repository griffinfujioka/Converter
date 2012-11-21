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

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Converter
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : Converter.Common.LayoutAwarePage
    {
        #region Some variable declarations
        string focusedTxtBox = "";
        string binaryLine;
        string decLine;
        string hexLine;
        string octalLine; 
        #endregion

        #region Page constructor 
        public MainPage()
        {
            this.InitializeComponent();
        }
        #endregion 

        #region On Navigated To
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        #endregion

        #region textChanged()
        public void textChanged()
        {
            int decValue;
            string hexValue;
            string binaryValue;
            string octalValue; 
            switch (focusedTxtBox)
            {
                case "binary":
                    if (binaryLine != "")
                    {
                        decValue = Convert.ToInt32(binaryLine, 2);
                        hexValue = decValue.ToString("X");
                        octalValue = Convert.ToString(decValue, 8); 
                        hexTxtBox.Text = hexValue;
                        decimalTxtBox.Text = decValue.ToString();
                        octalTxtBox.Text = octalValue; 
                    }
                    else
                    {
                        hexTxtBox.Text = "";
                        decimalTxtBox.Text = "";
                    }
                    break;
                case "decimal":
                    if (decLine != "")
                    {
                        decValue = Convert.ToInt32(decLine);
                        binaryValue = Convert.ToString(decValue, 2);
                        hexValue = decValue.ToString("X");
                        hexTxtBox.Text = hexValue;
                        octalValue = Convert.ToString(decValue, 8); 
                        binaryTxtBox.Text = binaryValue;
                        octalTxtBox.Text = octalValue; 
                    }
                    else
                    {
                        hexTxtBox.Text = "";
                        binaryTxtBox.Text = "";
                        octalTxtBox.Text = ""; 
                    }
                    break;
                case "hex":
                    if (hexLine != "")
                    {
                        decValue = int.Parse(hexLine, System.Globalization.NumberStyles.HexNumber);
                        binaryValue = Convert.ToString(decValue, 2);
                        octalValue = Convert.ToString(decValue, 8); 
                        binaryTxtBox.Text = binaryValue;
                        decimalTxtBox.Text = decValue.ToString();
                        octalTxtBox.Text = octalValue; 
                    }
                    else
                    {
                        binaryTxtBox.Text = "";
                        decimalTxtBox.Text = "";
                        octalTxtBox.Text = ""; 
                    }
                    break;
                case "octal":
                    if (octalLine != "")
                    {
                        decValue = Convert.ToInt32(octalLine, 8);
                        hexValue = decValue.ToString("X");
                        octalValue = Convert.ToString(octalLine);
                        decimalTxtBox.Text = decValue.ToString(); 
                        binaryValue = Convert.ToString(decValue, 2);
                        binaryTxtBox.Text = binaryValue.ToString();
                        hexTxtBox.Text = hexValue.ToString(); 
                    }
                    else
                    {
                        binaryTxtBox.Text = "";
                        decimalTxtBox.Text = "";
                        hexTxtBox.Text = "";
                        octalTxtBox.Text = ""; 
                    }
                    break; 
                default: break;
            }
        }
        #endregion

        #region hexTxtBox_TextChanged
        private void hexTxtBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            hexLine = hexTxtBox.Text;
            if (OnlyHexValues(hexLine) || hexLine == "")
                textChanged();
            else
            {
                hexLine = hexLine.Remove(hexLine.Length - 1, 1);  // remove the last value
                hexTxtBox.Text = hexLine;
                hexTxtBox.Select(hexLine.Length, 0);
            }

        }
        #endregion

        #region decimalTxtBox_TextChanged
        private void decimalTxtBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            decLine = decimalTxtBox.Text;
            if (OnlyIntValues(decLine) || decLine == "")
                textChanged();
            else
            {
                decLine = decLine.Remove(decLine.Length - 1, 1);
                decimalTxtBox.Text = decLine;
                if (decLine.Length == 0)
                    decimalTxtBox.Select(0, 0);
                else
                    decimalTxtBox.Select(binaryLine.Length, 0);
            }

        }
        #endregion

        #region binaryTxtBox_TextChanged
        private void binaryTxtBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            binaryLine = binaryTxtBox.Text;
            if (OnlyBinaryValues(binaryLine) || binaryLine == "")
                textChanged();
            else
            {
                binaryLine = binaryLine.Remove(binaryLine.Length - 1, 1);
                binaryTxtBox.Text = binaryLine;
                binaryTxtBox.Select(binaryLine.Length, 0);
            }
        }
        #endregion

        #region octalTxtBox_TextChanged_1 
        private void octalTxtBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            octalLine = octalTxtBox.Text;
          if (OnlyOctalValues(octalLine) || octalLine == "")
                textChanged();
            else
            {
                octalLine = octalLine.Remove(octalLine.Length - 1, 1);
                octalTxtBox.Text = octalLine;
                octalTxtBox.Select(octalLine.Length, 0); 
                
            }
        }
        #endregion 

        #region txtBox GotFocus events - change value of focusedTxtBox
        private void binaryTxtBox_GotFocus_1(object sender, RoutedEventArgs e)
        {
            focusedTxtBox = "binary";
            //textChanged(); 
        }

        private void decimalTxtBox_GotFocus_1(object sender, RoutedEventArgs e)
        {
            focusedTxtBox = "decimal";
            //textChanged(); 
        }

        private void hexTxtBox_GotFocus_1(object sender, RoutedEventArgs e)
        {
            focusedTxtBox = "hex";
            //textChanged(); 
        }

        private void octalTxtBox_GotFocus_1(object sender, RoutedEventArgs e)
        {
            focusedTxtBox = "octal";
        }
        #endregion

        #region Clear button click
        private void clearButton_Click_1(object sender, RoutedEventArgs e)
        {
            binaryLine = "";
            binaryTxtBox.Text = "";

            decLine = "";
            decimalTxtBox.Text = "";

            hexLine = "";
            hexTxtBox.Text = "";

            octalLine = "";
            octalTxtBox.Text = ""; 
        }
        #endregion

        #region Input validation functions
        public bool OnlyHexValues(string line)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(line, @"\A\b[0-9a-fA-F]+\b\Z");
        }


        public bool OnlyBinaryValues(string line)
        {
            foreach (var c in line)
                if (c != '0' && c != '1')
                    return false;

            return true;
        }

        public bool OnlyIntValues(string line)
        {
            int number;
            return int.TryParse(line, out number);
        }

        public bool OnlyOctalValues(string line)
        {
            /* Wish I could have figured out Regular expressions here... Don't judge me! */
            foreach (var c in line)
            {
                if (c != '0' && c != '1' &&
                    c != '2' && c != '3' &&
                    c != '4' && c != '5' &&
                    c != '6' && c != '7')
 
                    return false;

                
            }

            return true; 
        }
        #endregion  

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        

        
    }
}
