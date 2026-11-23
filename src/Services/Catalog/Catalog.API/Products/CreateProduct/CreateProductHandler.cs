
namespace Catalog.API.Products.CreateProduct;
public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)

: ICommand<CreateProductResult>;


public record  CreateProductResult(Guid  Id);
//using  fluent  validation  to  validate  the  command  object  before  processing it in the handler.
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{//Abstract Validator  it is  a  class to  make validation  from  fluent  validation  
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}
internal class CreateProductHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {

        

        // create  product  entity from command  object  


        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price

        };
        // you  write  c# object and  marten will handle the mapping to the database table and columns automatically based on the Product class definition as  json document in the database.
        //save to database
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);
        //return result   of  create product  result  
        return new CreateProductResult(product.Id);



    }
}

