using LampControl.Classes;
using LampControl.ContentDialogs;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;

namespace LampControl
{
    public sealed partial class MainPage : Page
    {
        public bool LampAvailability { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            TitlebarHelper.SetCustomTitlebar();
            InitializeApp();
        }

        private async void InitializeApp()
        {
            LampAvailability = await LampHelper.TryGetDefaultLamp();
            if (!LampAvailability)
            {
                await DialogHelper.ShowDialog("Error", "Unable to get the default lamp");
            }
        }

        private void TorchToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            LampHelper.ToggleDefaultLamp();
        }

        private async void ToolbarButton_Click(object sender, RoutedEventArgs e)
        {
            switch((sender as Button).Tag)
            {
                case "About":
                    AboutContentDialog AboutDialog = new AboutContentDialog();
                    await AboutDialog.ShowAsync();
                    break;
            }
        }
    }
}
