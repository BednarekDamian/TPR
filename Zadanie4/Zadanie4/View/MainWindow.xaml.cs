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
using ViewModel;

namespace View
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void DisplayPopup(string popoutM)
        {
            MessageBox.Show(popoutM);
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            MainWindowActions mw = (MainWindowActions)DataContext;
        //    mw.MainWindow = this;
        }
    }
}
