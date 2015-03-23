using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using SolidNavigation.Sdk;
using SpartakiadeDemo.Navigation;

namespace SpartakiadeDemo.Tasks
{
    public sealed partial class TasksPage
    {
        public TasksPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var target = (ListTarget)Router.Current.CreateTarget(e.Parameter.ToString());
            DataContext = new TasksPageViewModel(target);
            NavInfo.Text = e.Parameter.ToString();
        }

        private void OnBackButtonClick(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).GoBack();
        }
    }
}
