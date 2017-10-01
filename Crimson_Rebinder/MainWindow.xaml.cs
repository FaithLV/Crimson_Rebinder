using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Crimson_Rebinder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CreateKey("Toggle Toolbar", "ToggleDvrToolbarHotkey");
            CreateKey("Toggle Recording", "ToggleDvrRecordingHotkey");
            CreateKey("Save Instant Replay", "SaveInstantReplayHotkey");
            CreateKey("Toggle Streaming", "ToggleStreamingHotkey");
            CreateKey("Take Screenshot", "TakeScreenshotHotkey");
            CreateKey("Toggle Microphone", "ToggleMicrophoneHotkey");
            CreateKey("Toggle Camera", "ToggleCameraHotkey");
        }

        void CreateKey(string name, string hkey)
        {
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;
            panel.Margin = new Thickness(0,0,0,15);

            TextBlock text = new TextBlock();
            text.Text = name;
            text.Margin = new Thickness(0,0,15,0);

            Button btn = new Button();
            btn.Tag = hkey;
            btn.Content = "Disable";
            btn.Click += Btn_Click;

            panel.Children.Add(text);
            panel.Children.Add(btn);
            BindPanel.Children.Add(panel);
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            string hkey = ((Button)sender).Tag.ToString();
            DisableBind(hkey);
            //Console.WriteLine(hkey);
        }

        string DVRroot = @"HKEY_CURRENT_USER\Software\AMD\DVR\";
        void DisableBind(string hkey)
        {
            try
            {
                Registry.SetValue(DVRroot, hkey, "none");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something went wrong...");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
