using LampControl.Classes;
using Windows.UI.Xaml.Controls;

namespace LampControl.ContentDialogs
{
    public sealed partial class AboutContentDialog : ContentDialog
    {
        public AboutContentDialog()
        {
            this.InitializeComponent();
        }

        public string AppVersion
        {
            get
            {
                return AppVersionHelper.GetAppVersion();
            }
        }
    }
}
