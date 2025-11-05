namespace MauiAppProducts
{
    public partial class MainPage : ContentPage
    {
        DBService dBService = new DBService();

        public MainPage()
        {
            InitializeComponent();

        }

      

        private async void  AddCategory_click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCategory());
        }

        private async void EditCategory_click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCategory());
        }

        private void DeleteCategory_click(object sender, EventArgs e)
        {

        }
    }
}
