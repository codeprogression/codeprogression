using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace AdventureMVC.Data.FluentNHibernate
{
    public class RepositoryBase
    {
        protected static ISessionFactory _sessionFactory;
        private ISession _session;

        public ISessionFactory ConfigureSessionFactory()
        {
            var configuration = MsSqlConfiguration.MsSql2005.ConnectionString(
                c => c.FromConnectionStringWithKey(("AdventureWorks")));
            var mappings = Fluently.Configure().Database(
                configuration.ShowSql()).Mappings(
                m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()).ExportTo("."));
            return mappings.BuildSessionFactory();
        }
        public RepositoryBase()
        {

            _sessionFactory = ConfigureSessionFactory();
        }

        protected ISession GetSession()
        {
            if(_session==null || !_session.IsOpen)
                _session = _sessionFactory.OpenSession();
            return _session;
        }

        public void Flush()
        {
            GetSession().Flush();
        }

        public void Update<T>(T entity)
        {
            GetSession().Update(entity);
        }
        public ICriteria CreateCriteria<T>()
        {
            return GetSession().CreateCriteria(typeof (T));
        }
        public IQuery CreateQuery(string queryString)
        {
            var session = GetSession();
            return session.CreateQuery(queryString);
        }
    }

}