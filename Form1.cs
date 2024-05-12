using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Management;

namespace OptimizerApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SystemEvents.PowerModeChanged += OnPowerModeChanged;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void OnPowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            if (e.Mode == PowerModes.StatusChange)
            {
                string message = SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online ?
                                 "Charger Plugged In" : "Charger Unplugged";
                bool plugged = SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online;
                MessageBox.Show(message);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // It's important to unsubscribe from the event to prevent memory leaks
            SystemEvents.PowerModeChanged -= OnPowerModeChanged;
            base.OnFormClosed(e);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
            int val = trackBar1.Value * 10;
            WindowsSettingsBrightnessController.Set(val);
        }
    }

    public static class WindowsSettingsBrightnessController
    {
        public static int Get()
        {
            using var mclass = new ManagementClass("WmiMonitorBrightness")
            {
                Scope = new ManagementScope(@"\\.\root\wmi")
            };
            using var instances = mclass.GetInstances();
            foreach (ManagementObject instance in instances)
            {
                return (byte)instance.GetPropertyValue("CurrentBrightness");
            }
            return 0;
        }

        public static void Set(int brightness)
        {
            using var mclass = new ManagementClass("WmiMonitorBrightnessMethods")
            {
                Scope = new ManagementScope(@"\\.\root\wmi")
            };
            using var instances = mclass.GetInstances();
            var args = new object[] { 1, brightness };
            foreach (ManagementObject instance in instances)
            {
                instance.InvokeMethod("WmiSetBrightness", args);
            }
        }
    }
}
