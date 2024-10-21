using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window, INotifyPropertyChanged
    {
        /*
        public static readonly DependencyProperty MessageTextProperty;
        public string MessageText
        {
            get { return (string)GetValue(MessageTextProperty); }
            set { SetValue(MessageTextProperty, value); }
        }
        static MessageWindow()
        {
            MessageTextProperty = DependencyProperty.Register("MessageText", typeof(string), typeof(MessageWindow));
        }
        */
        string? messageText;
        public string MessageText
        {
            get { return messageText; }
            set { messageText=value; OnPropertyChanged(); }
        }
        public MessageWindow()
        {
            InitializeComponent();
            MessageText = "***";
        }
        public MessageWindow(string strmessage)
        {
            InitializeComponent();
            MessageText = strmessage;
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
