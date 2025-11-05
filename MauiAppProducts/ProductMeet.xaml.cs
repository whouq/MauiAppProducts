
using System.Threading.Tasks;

namespace MauiAppProducts;

public partial class ProductMeet : ContentPage
{
    private readonly DBService dBService;
    private List<Category> categories = new List<Category>();
    public List<Category> Categories
    {
        get => categories;
        set { categories = value; OnPropertyChanged(); }
    }
    public Product ProductHere { get; set; } = new Product();
    private List<Product> products = new List<Product>();
    public DBService dBService1 {  get; set; } = new DBService();

    public List<Product> Products
    {
        get => products;
        set { products = value; OnPropertyChanged(); } 
    }
    public ProductMeet(DBService dBService)
	{
		InitializeComponent();
        DBService = dBService;
        LoadList();
        BindingContext = this;
    }

    protected async override void OnAppearing()
    {
        var allProducts = await dBService.GetAllProductsAsync();
        Products = allProducts.Where(s => s.CategoryId == 1).ToList();
        ListViewProduct.ItemsSource = Products;
    }

  

    private async void EditProduct_click(object sender, EventArgs e)
    {
       var button = sender as Button;
        var item = button?.BindingContext;
    }

    private async void DeleteProduct_click(object sender, EventArgs e)
    {
      
      
        
    }

    private async void AddProduct_click(object sender, EventArgs e)
    {
        AddProduct addProduct = new AddProduct(dBService1); 
        await Navigation.PushAsync(AddProduct());
    }
}