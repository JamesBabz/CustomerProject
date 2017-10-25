namespace DAL
{
    public interface IDALFacade
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
