using NHibernate;

namespace AdventureMVC.Data.NHibernate
{
    public class RepositoryBase
    {
        protected readonly ISessionBuilder _sessionBuilder;

        public RepositoryBase(ISessionBuilder sessionFactory)
        {
            
            _sessionBuilder = sessionFactory;
        }

        protected ISession getSession()
        {
            var session = _sessionBuilder.GetSession();
            return session;
        }

        public void Flush()
        {
            getSession().Flush();
        }

    }
}