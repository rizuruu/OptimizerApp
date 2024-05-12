using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Management;

namespace OptimizerApp
{
    public partial class Form1 : Form
    {
        private int BP;
        private int BUP;

        public Form1()
        {
            InitializeComponent();
            SystemEvents.PowerModeChanged += OnPowerModeChanged;
            BP = Properties.Settings.Default.BP;
            BUP = Properties.Settings.Default.BUP;
            Initialise();
        }

        void Initialise()
        {
            BUPSlider.Value = BUP;
            BPSlider.Value = BP;

            BUPInfo.Text = BUPSlider.Value.ToString() + "%";
            BPInfo.Text = BPSlider.Value.ToString() + "%";
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
                //MessageBox.Show(message);
                int brightness = plugged ? BP : BUP;
                WindowsSettingsBrightnessController.Set(brightness);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // It's important to unsubscribe from the event to prevent memory leaks
            SystemEvents.PowerModeChanged -= OnPowerModeChanged;
            base.OnFormClosed(e);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BUPSlider_Scroll(object sender, EventArgs e)
        {
            BUP = BUPSlider.Value;
            BUPInfo.Text = BUP.ToString() + "%";
        }

        private void BPSlider_Scroll(object sender, EventArgs e)
        {
            BP = BPSlider.Value;
            BPInfo.Text = BP.ToString() + "%";
        }


        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveValues();
        }

        void SaveValues()
        {
            Properties.Settings.Default.BP = BP;
            Properties.Settings.Default.BUP = BUP;
            Properties.Settings.Default.Save();
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
