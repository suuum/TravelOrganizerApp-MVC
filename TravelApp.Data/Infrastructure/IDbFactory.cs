namespace TravelApp.Data.Infrastructure
{
    public interface IDbFactory
    {
        DataContext Init();
    }
}