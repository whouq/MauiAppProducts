namespace MauiAppProducts
{
    public partial class MainPage : ContentPage
    {
        DBService dBService = new DBService();

        public MainPage()
        {
            InitializeComponent();

        }

        private async void Meet_Click(object sender, EventArgs e)
        {
          await Navigation.PushAsync(new ProductMeet(dBService));
        }

        private async void Milk_Click(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new ProductMilk());
        }

        private async void Vegetable_Click(object sender, EventArgs e)
        {
          await Navigation.PushAsync(new ProductVegetable());
        }

        private async void Snacks_Click(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new ProductSnaks());
        }
    }
}
