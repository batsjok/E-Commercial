namespace WebApp.web.Models
{
    public class ProductRepository
	{
		private static List<Product> _products = new List<Product>()
		{
			new() { Id = 1, Name = "Sedan Araç", Price = 100, Stock = 200 },
			new () { Id = 2, Name = "Ticari Araç", Price = 200, Stock = 500 },
			new () { Id = 3, Name = "Minibüs", Price = 300, Stock = 700 }
		};

        public List<Product> GetAll() => _products; // create

		public void Add(Product newProduct) => _products.Add(newProduct); //  add

		public bool Remove(int id) // delete
		{
			var hasProduct = _products.FirstOrDefault(x => x.Id == id); // id kontrolü

			if(hasProduct!=null)
			{
				_products.Remove(hasProduct);
				return true;
			}

			return false;

		
		}

		public void Update(Product updateProduct) // update
		{
			var hasProduct = _products.FirstOrDefault(x => x.Id == updateProduct.Id); //id kontrolü
			if (hasProduct == null)
			{
				throw new Exception ($"Bu id'ye sahip ürün bulunmamaktadır");
            }
			hasProduct.Name = updateProduct.Name;
			hasProduct.Price = updateProduct.Price; // güncelleme işlemleri
			hasProduct.Stock = updateProduct.Stock;

			var index = _products.FindIndex(x => x.Id == updateProduct.Id); // update edilecek datanın indexini bulmak

			_products[index] = hasProduct; // bulunan datanın güncelleme işlemi
				
		}
 			
	}
}

