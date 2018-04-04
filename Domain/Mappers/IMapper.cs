namespace Domain.Mappers
{
    public  interface IMapper<in T, out TO>
    {
        TO MapFrom(T input);
    }
}
