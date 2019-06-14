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

namespace MiniProject_Batch_Rename
{
    /// <summary>
    /// Interaction logic for UpdateReplaceArgsDialog.xaml
    /// </summary>
    public partial class UpdateReplaceArgsDialog : Window
    {
        public ReplaceArgs Args;

        public UpdateReplaceArgsDialog(ReplaceArgs args)
        {
            Args = args;

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = Args;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
