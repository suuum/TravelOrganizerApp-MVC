namespace TravelApp.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}