

using System.Threading.Tasks;

namespace MauiAppProducts;

public partial class ProductList : ContentPage
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
    public ProductList(DBService dBService)
	{
		InitializeComponent();
        this.dBService = dBService;

        LoadList();
        BindingContext = this;
    }
    public async void LoadList()
    {
        categories = await dBService.LoadCategory();
        products = await dBService.LoadProduct();
    }
    protected async override void OnAppearing()
    {
        var allProducts = await dBService.GetAllProductsAsync();
        Products = allProducts.Where(s => s.CategoryId == 1).ToList();
        ListViewProduct.ItemsSource = Products;
    }
    public int DeleteId { get; set; } = 0;


    private async void EditProduct_click(object sender, EventArgs e)
    {
        if (Id==null)
        {
            return;
        }
        await Navigation.PushAsync(new AddProduct(dBService));
    }

    private async void DeleteProduct_click(object sender, EventArgs e)
    {

        dBService.DeleteProductAsync(DeleteId);
        LoadList();

    }

    private async void AddProduct_click(object sender, EventArgs e)
    {
        
        await Navigation.PushAsync(new AddProduct(dBService));
    }
}