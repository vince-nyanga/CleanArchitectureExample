namespace Domain.UseCases
{
    internal interface IUseCase<out T>
    {
        T Execute(object data); 
    }
}
