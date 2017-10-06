using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace NorthServices
{
    [ServiceContract]
    public interface INorthService
    {
        [OperationContract]
        IEnumerable<Category> GetCategories();

        [OperationContract]
        Category GetCategory(int categoryID);

        [OperationContract]
        IEnumerable<Product> GetProducts();

        [OperationContract]
        Product GetProduct(int productID);

        [OperationContract]
        IEnumerable<Product> GetProductsByCategory(int categoryID);
    }
}
