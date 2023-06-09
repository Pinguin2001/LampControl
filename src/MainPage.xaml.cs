using LampControl.Classes;
using LampControl.ContentDialogs;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;

namespace LampControl
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            TitlebarHelper.SetCustomTitlebar();
            InitializeApp();
        }

        private async void InitializeApp()
        {
            bool LampPresence = await LampHelper.TryGetDefaultLamp();
            if (!LampPresence)
            {
                await DialogHelper.ShowDialog("Error", "Unable to get the default lamp");
                TorchToggleBtn.IsEnabled = false;
            }
        }

        private void TorchToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            LampHelper.ToggleDefaultLamp();
        }

        private async void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            AboutContentDialog dialog = new AboutContentDialog();
            await dialog.ShowAsync();
        }
    }
}
