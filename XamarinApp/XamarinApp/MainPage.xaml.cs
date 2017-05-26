using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnTeste1_Clicked(object sender, EventArgs e)
        {
            lblResult.Text = "btnTeste1_Clicked";
        }

        private void btnTeste2_Clicked(object sender, EventArgs e)
        {
            lblResult.Text = "btnTeste2_Clicked";
        }

        private void btnTeste3_Clicked(object sender, EventArgs e)
        {
            lblResult.Text = "btnTeste3_Clicked";
        }
    }
}
