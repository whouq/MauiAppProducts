namespace MauiAppProducts;

public partial class AddCategory : ContentPage
{
    private DBService _dbService;
    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }
    
    private Category Category { get; set; }
    private List<Category> categories = new List<Category>();
    public Category CategoryHere { get; set; } = new Category();
    public List<Category> Categories
    {
        get => categories;
        set { categories = value; OnPropertyChanged(); }
    }
    public int DeleteId { get; set; } = 0;
   
    public AddCategory(DBService dbService)
    {
        InitializeComponent();
        _dbService = dbService;
        BindingContext = this;
        LoadList();


    }
    public DBService dbService { get; set; } = new DBService();
    private List<Product> products = new List<Product>();
    public List<Product> Products
    {
        get => products;
        set { products = value; OnPropertyChanged(); }
    }
    public async void LoadList()
    {
        categories = await dbService.LoadCategory();
        products = await dbService.LoadProduct();

    }
    
    public async void Save_click(object sender, EventArgs e)
    {
        await dbService.AddCategoryAsync(CategoryHere);
        await Navigation.PopAsync(); 
        LoadList();


    }

    private async void Close_click(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
 

}