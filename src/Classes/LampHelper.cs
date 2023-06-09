using System;
using System.Threading.Tasks;
using Windows.Devices.Lights;

namespace LampControl.Classes
{
    public static class LampHelper
    {
        private static Lamp DefaultLamp { get; set; }

        public static async Task<bool> TryGetDefaultLamp()
        {
            DefaultLamp = await Lamp.GetDefaultAsync();
            if (DefaultLamp != null)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public static void ToggleDefaultLamp()
        {
            DefaultLamp.IsEnabled = !DefaultLamp.IsEnabled;
        }
    }
}
