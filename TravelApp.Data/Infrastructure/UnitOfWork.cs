namespace TravelApp.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private DataContext _dbContext;
        
        public UnitOfWork(IDbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
        }

        public DataContext DbContext
        {
            get { return _dbContext ?? (_dbContext = _dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}