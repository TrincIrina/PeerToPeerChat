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
using System.Windows.Threading;
using TcpPeerToPeerChat_CLI.Network;

namespace PeerToPeerChat
{
    /// <summary>
    /// Логика взаимодействия для ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        private IHostMessageService _service;        
        private string message = string.Empty;
        public ChatWindow(IHostMessageService service, string status)
        {
            InitializeComponent();

            StatusLabel.Content = status;
            _service = service;
            _service.EstablishConnection();
            
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Tick += new EventHandler(MessageReciver);
            timer.Start();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            _service.ShutdownConnection();
            Close();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {            
            message = MessageTextBox.Text;
            _service.Sender.Send(message);
            ChatListBox.Items.Add($"[my] -- {message}");
        }

        private void MessageReciver(object sender, EventArgs e)
        {
            //StatusLabel.Content = DateTime.Now.ToLongTimeString();
            message = _service.Receiver.Receive();
            if (message != string.Empty)
            {                
                ChatListBox.Items.Add($"[answer] -- {message}");
            }
        }

    }
}
