using CommunityToolkit.Maui.Views;

namespace MauiComm_ExpanderAndLazyView
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Expander_ExpandedChanged(object sender, CommunityToolkit.Maui.Core.ExpandedChangedEventArgs e)
        {
            var expander = (Expander)sender;
            if (expander.Content is not null)
            {
                var lazyView = (LazyViewExpanderContent)expander.Content;
                if (expander.IsExpanded)
                {
                    var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
                    await lazyView.LoadViewAsync(cts.Token);
                }
            }
        }
    }
}
