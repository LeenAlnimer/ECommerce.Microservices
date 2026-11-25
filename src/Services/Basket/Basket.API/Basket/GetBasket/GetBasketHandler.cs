

namespace Basket.API.Basket.GetBasket;

    public  record GetBasketQuery(string UserName):IQuery<GetBasketResult>;
    public record  GetBasketResult(ShoppingCart Cart);


    public class GetBasketQueyHandler:IQueryHandler<GetBasketQuery,GetBasketResult>
    {
    public  async Task <GetBasketResult> Handle(GetBasketQuery query , CancellationToken cancellationToken)
        {

        // we  will get  the  basket  from datat base  using  repository 
        return new GetBasketResult(new ShoppingCart("swn"));

         }
    }

