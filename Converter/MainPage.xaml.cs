﻿using System;
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
using Windows.UI.Popups; 

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Converter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region Some variable declarations
        string focusedTxtBox = "";
        string binaryLine;
        string decLine; 
        string hexLine;
        #endregion

        public  MainPage()
        {
            this.InitializeComponent();
        }

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
            switch (focusedTxtBox)
            {
                case "binary":
                    if (binaryLine != "")
                    {
                        decValue = Convert.ToInt32(binaryLine, 2);
                        hexValue = decValue.ToString("X");
                        hexTxtBox.Text = hexValue;
                        decimalTxtBox.Text = decValue.ToString();
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
                        binaryTxtBox.Text = binaryValue;
                    }
                    else
                    {
                        hexTxtBox.Text = "";
                        binaryTxtBox.Text = "";
                    }
                    break; 
                case "hex":
                    if (hexLine != "")
                    {
                        decValue = int.Parse(hexLine, System.Globalization.NumberStyles.HexNumber);
                        binaryValue = Convert.ToString(decValue, 2);
                        binaryTxtBox.Text = binaryValue;
                        decimalTxtBox.Text = decValue.ToString();
                    }
                    else
                    {
                        binaryTxtBox.Text = "";
                        decimalTxtBox.Text = "";
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
            if(OnlyHexValues(hexLine) || hexLine == "")
                textChanged(); 
            else
            {
                hexLine = hexLine.Remove(hexLine.Length -1 , 1);  // remove the last value
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
        #endregion        
    }
}
