using Microsoft.Extensions.Logging;
using CRUD_PRODUCTS.Storage;
using CRUD_PRODUCTS.Models;
using ZstdSharp.Unsafe;
using Mysqlx.Crud;

namespace CRUD_PRODUCTS.service
{
    
    public class Service
    {      

        private readonly StorageProduct storage;
        private readonly ILogger<Service> _logger;

        public Service(ILogger<Service> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            storage = new StorageProduct();
        }
  
            
        

        public int Create(Product product)
        {   
            int ret = -1;
            _logger.LogDebug("[Service] - Trying to create Product.");
            try
            {
                ret  = storage.CreateProduct(product);
                if (ret == 0)
                {
                    _logger.LogWarning("[Service] - Product creation failed, no ID returned.");                   
                };
                
                _logger.LogInformation("[Service] - Product creation was a success. ID : {Product.Id}", ret);
                
            }
            catch (Exception e)
            {
                _logger.LogError(e, "[Service] - Exception during product creation. Error: {Exception}", e.Message);
            }
            return ret;
        }


         public Product? GetById(int id)
        {
            _logger.LogDebug("[Service] - Trying Get Product by ID.");
            var ret = new Product();
            try
            {
                _logger.LogInformation("[Service] - Product Get Success.");
                ret = storage.GetProduct(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e , "[Service] - Error to Get a Product. Error : {Exception}", e.Message);
            }
            return ret;
        }

        public void Update(Product product)
        {
            _logger.LogDebug("[Service] - Trying to Update a Product.");
            try
            {
                var ret = storage.UpdateProduct(product);
                if (ret == true)
                {
                    _logger.LogInformation("[Service] - Product update a success");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e ,"[Service] - Exception during update a product. Error : {Exception}", e.Message);
            }
        }
    }; 


       
};