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
using Windows.Web.Http;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            TextBlock txtBlk = new TextBlock();
            txtBlk.Text = "This is the app.  Type your message, and get your response.";
            TextBox txtBox = new TextBox();
            txtBox.PlaceholderText = "Write message here!";
            txtBox.Name = "input Box";
            txtBox.Width = 653;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sendData();
        }
        private async void sendData()
        {
            HttpClient hc = new HttpClient();
            Uri goTo = new Uri(uri.Text);
            HttpStringContent data = new HttpStringContent(parseAddSpaces(input.Text));
            HttpResponseMessage msg = await hc.PostAsync(goTo, data);
            forUser.Text = msg.ToString();
        }
        //didn't feel like putting this class elsewhere.  Much easier this way.
        private string parseAddSpaces(String toParse)
        {
            String[] holder = toParse.Split(null);
            String output = "msg=";
            for(var i = 0; i < holder.Length; i++)
            {
                output += (i == (holder.Length - 1))? holder[i]: holder[i] + "%20";
            }
            return output;
        }
    }
}
