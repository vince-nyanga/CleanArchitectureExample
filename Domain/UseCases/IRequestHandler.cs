namespace Domain.UseCases
{
    internal interface IRequestHandler<in TRequest, out TResponse>
    {
       TResponse Handle(TRequest data); 
    }
}
