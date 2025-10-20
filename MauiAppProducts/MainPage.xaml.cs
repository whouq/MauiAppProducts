namespace MauiAppProducts
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void Meet(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProductMeet());
        }

        private void Milk(object sender, EventArgs e)
        {

        }

        private void Vegetable(object sender, EventArgs e)
        {

        }

        private void Snacks(object sender, EventArgs e)
        {

        }
    }
}
