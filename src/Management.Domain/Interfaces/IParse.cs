namespace Management.Domain.Interfaces
{
    public interface IParse<TDomain, TDto>
    {
        TDto Parse(TDomain obj);
        TDomain Parse(TDto obj);
    }
}
