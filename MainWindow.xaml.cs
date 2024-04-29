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
using TcpPeerToPeerChat_CLI.Network;
using TcpPeerToPeerChat_CLI.Tcp;

namespace PeerToPeerChat
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            string serverIpPort = $"{IpTextBox.Text}:{PortTextBox.Text}";
            IHostMessageService passiveService = new PassiveSocketMessageService(serverIpPort);
            IHostMessageService activeService = new ActiveSocketMessageService(serverIpPort);
            ChatWindow activeChat = new ChatWindow(activeService, "active");
            activeChat.Show();
            ChatWindow passiveChat = new ChatWindow(passiveService, "passive");
            passiveChat.Show();            
        }
        private void CloneButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();            
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
