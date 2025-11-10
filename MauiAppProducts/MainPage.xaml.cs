



using System.Threading.Tasks;

namespace MauiAppProducts
{
    public partial class MainPage : ContentPage
    {
        
        private readonly DBService dBService = new DBService ();

       private List<Product> products = new List<Product> ();

        public List<Product> Products
        {
            get => products;
            set { products = value; OnPropertyChanged(); }
        }


        public MainPage()
        {
            InitializeComponent();
            dBService.LoadId();
        }
        
        public void OnAppearing()
        {
            LoadDataCommand
        }

      private async void LoadList()
        {
            ListViewCategory.ItemsSource = await dBService.GetAllCategoriesAsync();
            dBService.LoadId();

        }

        private async void  AddCategory_click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCategory(dBService));
            LoadList();
        }

        private async void EditCategory_click(object sender, EventArgs e)
        {
           
            await Navigation.PushAsync(new AddCategory(dBService));
            LoadList();
        }
        public int DeleteId { get; set; } = 0;
      
        private async void DeleteCategory_click(object sender, EventArgs e)
        {
            await dBService.DeleteCategoryAsync(DeleteId);
            LoadList();
        }
        private List<Product> productShow = new List<Product>();
        public List<Product> ProductShow
        {
            get => productShow;
            set { productShow = value; OnPropertyChanged(); }
        }
      
        public int RequestIdProduct { get; set; } = 0;
        private void ShowProduct(object sender, EventArgs e)
        {
            ProductShow = Products.Where(s => s.Id == RequestIdProduct).ToList();
        }
    }
}
