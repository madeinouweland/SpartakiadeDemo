using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using SolidNavigation.Sdk;
using SpartakiadeDemo.Navigation;

namespace SpartakiadeDemo.Details
{
    public sealed partial class TaskDetailsPage
    {
        public TaskDetailsPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var target = Router.Current.CreateTarget(e.Parameter.ToString());
            DataContext = new TaskDetailsViewModel(target);
            NavInfo.Text = e.Parameter.ToString();
        }

        private void OnBackButtonClick(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).GoBack();
        }
    }
}
