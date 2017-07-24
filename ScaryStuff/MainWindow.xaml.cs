using ScaryStuff.Model;
using ScaryStuff.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ScaryStuff
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lbOKCList.Items.Add(new Button { Tag = "Serial 1", Content = "Serial 1" });
            lbOKCList.Items.Add(new Button { Tag = "Serial 2", Content = "Serial 2" });
            lbOKCList.Items.Add(new Button { Tag = "Serial 3", Content = "Serial 3" });
        }

        private void lbOKCList_Click(object sender, RoutedEventArgs e)
        {

            Button btn = (Button)e.OriginalSource;
            var OKCSerial = btn.Tag.ToString();

            var db = new ZentegreDBContext();
            var MissingZList = db.GetMissingZList().Where(x => x.CashRegisterSerialNumber == OKCSerial);

            ObservableCollection<ZReportDataCheckModel> MissingZCollection = new ObservableCollection<ZReportDataCheckModel>(MissingZList);

            var missingCorrectionUC = new MissingReportCorrectionUC
            {
                DataContext = new MissingReportsCorrectionViewModel(1, OKCSerial, 2, 2017, MissingZCollection)
            };

            dataCorrectionStage.Children.Add(missingCorrectionUC);
        }
    }
}
