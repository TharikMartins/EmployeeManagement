namespace Management.Domain.Interfaces
{
    public interface IParse<Tin, Tout>
    {
        Tout Parse(Tin obj);
    }
}
