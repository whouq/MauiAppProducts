

using System.Threading.Tasks;

namespace MauiAppProducts;

public partial class ProductList : ContentPage
{
    private readonly DBService dBService = new DBService();
  
    public Product SelectedProduct { get; set; }

    public ProductList(DBService dBService)
	{
		InitializeComponent();
        this.dBService = dBService;
        LoadList();
        BindingContext = this;

    }
    public async void LoadList()
    {
        ListViewProduct.ItemsSource = await dBService.GetAllProductsAsync();
    }

    protected async override void OnAppearing()
    {
        LoadList();
    }




    public int DeleteId { get; set; } = 0;
    public Product ProductHere { get; set; } = new Product();

    private async void EditProduct_click(object sender, EventArgs e)
    {
        await dBService.UpdateProductAsync(DeleteId, ProductHere);
        await Navigation.PushAsync(new AddProduct(dBService));
        LoadList();
    }




    private async void DeleteProduct_click(object sender, EventArgs e)
    {
        if (SelectedProduct == null) return;
        try
        {
         await dBService.DeleteProductAsync(SelectedProduct.Id);
         LoadList();

        }
        catch 
        {
            return;
        }
        
        

    }

    private async void AddProduct_click(object sender, EventArgs e)
    {
        
        await Navigation.PushAsync(new AddProduct(dBService));
    }


    private async void Back_click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    
}