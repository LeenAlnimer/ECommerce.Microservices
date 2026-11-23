namespace Catalog.API.Exceptions
 
{
    public class ProductNotFoundException: NotFoundException
    {
       public ProductNotFoundException(Guid Id)
            : base("Product",Id)
        {
        }
    }
    //we  use  id  to specify which  product exactly  that  we  do  not  find  
}
