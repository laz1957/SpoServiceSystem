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
using System.Windows.Shapes;

namespace SpoServiceSystem.Windows
{
    /// <summary>
    /// Логика взаимодействия для SystemSettingsWindow1.xaml
    /// </summary>
    public partial class ServerSettingsWindow : Window
    {

        Classes.SystemSettings ServerSettings;
        public ServerSettingsWindow()
        {
            InitializeComponent();
            ServerSettings = new Classes.SystemSettings();
            pwbox.Password = ServerSettings.MySqlPassword;
        }

        private void pwbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ServerSettings.MySqlPassword = pwbox.Password;
        }
    }
}
