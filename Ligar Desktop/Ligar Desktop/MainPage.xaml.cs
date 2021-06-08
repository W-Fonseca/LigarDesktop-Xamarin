using Ligar_Desktop.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ligar_Desktop
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        FireBaseService firebaseService = new FireBaseService();
        public MainPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var texto = await firebaseService.ObterTexto();
            lvtexto.ItemsSource = texto;
        }

        private async void btnLigar_Clicked(object sender, EventArgs e)
        {
            await firebaseService.Ligar();
            var texto = await firebaseService.ObterTexto();
            lvtexto.ItemsSource = texto;
        }

        private async void btnDesligar_Clicked(object sender, EventArgs e)
        {
            await firebaseService.Desligar();
           var texto = await firebaseService.ObterTexto();
            lvtexto.ItemsSource = texto;
        }
    }
}
