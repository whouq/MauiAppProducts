namespace MauiAppProducts;

public partial class AddProduct : ContentPage
{
	private DBService _dbService;
	public string ProductName { get; set; }
	public string ProductDescription { get; set; }
	public int ProductPrice { get; set; }
	private Category Category { get; set; }
	private List<Product> products =new List<Product>();
	public Product ProductHere { get; set; } = new Product();
	public List<Product> Products
	{
		get => products;
		set { products = value;OnPropertyChanged(); }
	}
	public int DeleteId { get; set; } = 0;
	private List<Category> categories = new List<Category>();
	public List<Category> Categories
	{
		get => categories;
		set { categories= value; OnPropertyChanged(); }
	}
	public AddProduct(DBService dbService, int categoryId)
	{
		InitializeComponent();
		dbService = _dbService;
		BindingContext = this;
		LoadList();
	
	
	}
	public DBService dbService {  get; set; } = new DBService();

	public async void LoadList()
	{
		categories = await _dbService.LoadCategory();
		products = await _dbService.LoadProduct();
	}
	public async void Save_click (object sender, EventArgs e)
	{
		_dbService.AddProductAsync(ProductHere);
		LoadList();
       

    }

    private async void Close_click(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
	private void Update (object sender, EventArgs e)
	{
		dbService.UpdateProductAsync(DeleteId, ProductHere);
		LoadList();
	}

   
}