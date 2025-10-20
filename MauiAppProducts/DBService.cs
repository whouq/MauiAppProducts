using MauiAppProducts;
using System.Text.Json;

public class DBService
{

    private readonly string _categoriesFile;
    private readonly string _productsFile;

    public List<Category> _categories = new();
    public List<Product> _products = new();

    private int _nextProductId = 1;
    private int _nextCategoriesId = 1;

    public DBService()
    {
        InitializeData();

    }
    private void InitializeData()
    {
        _categories = new List<Category>
        {
            new Category { Id = _nextCategoriesId++, Name = "Мясо", Description = "Описание" },
            new Category { Id = _nextCategoriesId++, Name = "Молочные продукты", Description = "Описание" },
            new Category { Id = _nextCategoriesId++, Name = "Овощи/Фрукты", Description = "Описание" },
            new Category { Id = _nextCategoriesId++, Name = "Снеки", Description = "Описание" }
        };
        _products = new List<Product>
        {
            new Product {Id = _nextProductId++, Name="Куриная грудка", Description="Свежая куриная грудка", CategoryId=1, Price=350,},
            new Product {Id = _nextProductId++, Name="Помидоры", Description="Свежие помидоры", CategoryId=2, Price=200,},
            new Product {Id = _nextProductId++, Name="Молоко", Description="Коровье молоко", CategoryId=3, Price=120,},
            new Product {Id = _nextProductId++, Name="Чипсы", Description="Картофельные чипсы", CategoryId=4, Price=150,}
        };
    }
    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return _categories.ToList();
    }


    public async Task<Category> AddCategoryAsync(Category category)
    {
        await Task.Delay(500);
        var existing = _categories.FirstOrDefault(c => c.Id == category.Id);
        if (existing!=null)
        {
            existing.Name = category.Name;
            existing.Description = category.Description;

        }
        return existing;
    }

    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        await Task.Delay(500);
        var existing = _categories.FirstOrDefault(c => c.Id == category.Id);
        {
            if (existing!=null)
            {
                existing.Name = category.Name;
                existing.Description = category.Description;
            }
            return existing;
        }
    }
    public async Task<bool> DeleteCategoryAsync(int id)
    {
        await Task.Delay(500);
        var existing = _categories.FirstOrDefault(c => c.Id ==id);
        if (_categories != null)
        {
            var hasProducts = _products.Any(p => p.CategoryId == id);
            if (hasProducts)
            {
                throw new InvalidOperationException("Нельзя удалить категорию к которой привязаны продукты");
            }
            return true;
        }
        return false;
    }
    public async Task<List<Product>> GetAllProductsAsync()
    {
       
        return _products.ToList();
    }
    public async Task<Product> AddProductAsync(Product product)
    {
        await Task.Delay(500);
        var existing = _products.FirstOrDefault(c => c.Id == product.Id);
        if (existing != null)
        {
            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Price = product.Price;



        }
        return existing;
    }
    public async Task<Product> UpdateProductAsync(Product product)
    {
        await Task.Delay(500);
        var existing = _products.FirstOrDefault(c => c.Id == product.Id);
        {
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Description = product.Description;
                existing.Price = product.Price;

            }
            return existing;
        }
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        await Task.Delay(500);
        var existing = _products.FirstOrDefault(p => p.Id == id);
        if (existing != null)
        {
            _products.Remove(existing);
            return true;
        }
        return false;
    }
    public async Task <List<Category>> GetCategoriesAsync()
    {
        await Task.Delay(500);
        return _categories.ToList();
    }

    private async Task Save()
    {

       string _categoriesFile = Path.Combine(FileSystem.Current.AppDataDirectory, "_categoriesFile");
       string _productsFile = Path.Combine(FileSystem.Current.AppDataDirectory, "_productsFile");

        string json = JsonSerializer.Serialize(_categories);
        File.WriteAllText(@"_categoriesFile", json);

        string json1 = JsonSerializer.Serialize(_products);
        File.WriteAllText(@"_productsFile", json);

    }
}