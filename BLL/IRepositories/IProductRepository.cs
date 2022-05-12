using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IRepositories
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<Product> GetFullList(); // получение всех объектов
    }
}
