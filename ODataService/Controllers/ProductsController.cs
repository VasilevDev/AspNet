using Microsoft.AspNet.OData;
using ODataService.Modes;
using System.Collections.Generic;

namespace ODataService.Controllers
{
	public class ProductsController : ODataController
	{
		private readonly List<Product> products;

		public ProductsController()
		{
			products = new List<Product>();

			products.Add(new Product(1, "Bread"));
			products.Add(new Product(2, "Tomato"));
			products.Add(new Product(3, "Potato"));
			products.Add(new Product(4, "Cucumber"));
		}

		[EnableQuery]
		public List<Product> Get()
		{
			return products;
		}

	}
}