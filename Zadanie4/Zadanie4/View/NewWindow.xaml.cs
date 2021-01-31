using System.Windows;
using System.ComponentModel;

namespace View
{
    /// <summary>
    /// Logika interakcji dla klasy NewWindow.xaml
    /// </summary>
    public partial class NewWindow : Window
    {
        public NewWindow()
        {
            InitializeComponent();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
        }
    }
}
