using Repo.Model;
using Repo.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Repository.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {

    }
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(Contex contex) : base(contex)
        {

        }
    }
}
