using MVVM.ViewModels;
using System.Windows.Controls;

namespace MVVM.Views
{
    /// <summary>
    /// Interaction logic for BegegnungView.xaml
    /// </summary>
    public partial class BegegnungView : Page
    {
        public BegegnungView(IViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
