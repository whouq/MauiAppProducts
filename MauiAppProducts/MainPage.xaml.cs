



using System.Threading.Tasks;

namespace MauiAppProducts
{
    public partial class MainPage : ContentPage
    {
        
        private readonly DBService dBService = new DBService ();



        public MainPage()
        {
            InitializeComponent();
            dBService.LoadId();
        }

        
        
        protected override async void OnAppearing()
        {
            LoadList();
 
        }

      private async void LoadList()
        {
            ListViewCategory.ItemsSource = await dBService.GetAllCategoriesAsync();

        }


        private async void  AddCategory_click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCategory(dBService));
          
        }

        public Category CategoryHere { get; set; } = new Category();
        private async void EditCategory_click(object sender, EventArgs e)
        {
           await dBService.UpdateCategoryAsync(DeleteId, CategoryHere);
            await Navigation.PushAsync(new AddCategory(dBService));
            LoadList();
        }

        public int DeleteId { get; set; } = 0;
      
        private async void DeleteCategory_click(object sender, EventArgs e)
        {
            if (SelectedCategoryId<=0) return;
            try
            {
                await dBService.DeleteCategoryAsync(SelectedCategoryId);
                LoadList();
            }
            catch (Exception ex) 
            {
                return;
            }
       
        }
        private int SelectedCategoryId;
        private  async void OnCategorySelected(Category category)
        {
   
            if (category != null)
            {
                SelectedCategoryId = category.Id;
                CategoryHere = category;
            }
            await Navigation.PushAsync(new ProductList(dBService));
        }

        private async void OnBorderTapped(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new ProductList(dBService));
        }
    }
}
