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
using System.Windows.Threading;

namespace MauroTemplateApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Mainform_Loaded(object sender, RoutedEventArgs e)
        {
                lblStatus.Content = "Loading ...";
            DoEvents();
                MauroTemplate.MauroAPI.EndpointConnection.Username = "nicholas.oughtibridge@nhs.net";
                MauroTemplate.MauroAPI.EndpointConnection.Password = "DYScYu6UG%7f7d91ojADN2J7#sG@LX9";
                // MauroTemplate.MauroAPI.EndpointConnection.Login.Wait();
                MauroTemplate.MauroAPI.EndpointConnection.GetModels().Wait();
                lblStatus.Content = "Loaded.";
            }
  

        public static void DoEvents()
        {
            var frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
                new DispatcherOperationCallback(
                    delegate (object f)
                    {
                        ((DispatcherFrame)f).Continue = false;
                        return null;
                    }), frame);
            Dispatcher.PushFrame(frame);
        }
  }
}
