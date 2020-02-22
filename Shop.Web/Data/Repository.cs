using Shop.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data
{
	public class Repository : IRepository
	{
		private readonly DataContext context;

		public Repository(DataContext context)
		{
			this.context = context;
		}

		public IEnumerable<Product> GetProducts()
		{
			//retorna una lista de prodcutos ordenados
			return this.context.Products.OrderBy(p => p.Name);
		}

		public Product GetProduct(int id)
		{
			//devuelve todos los productos
			return this.context.Products.Find(id);
		}

		public void AddProduct(Product product)
		{
			//agregar productos
			this.context.Products.Add(product);
		}

		public void UpdateProduct(Product product)
		{
			//actualizar producto
			this.context.Update(product);
		}

		public void RemoveProduct(Product product)
		{
			//eliminar producto
			this.context.Products.Remove(product);
		}

		public async Task<bool> SaveAllAsync()
		{
			return await this.context.SaveChangesAsync() > 0;
		}

		public bool ProductExists(int id)
		{
			//conprueba que el prodcuto existe
			return this.context.Products.Any(p => p.Id == id);
		}

	}
}
