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
    /// Логика взаимодействия для MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
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
        public MessageWindow()
        {
            InitializeComponent();
        }
        public MessageWindow(string strmessage)
        {
            InitializeComponent();
            MessageText = strmessage;
        }
    }
}
