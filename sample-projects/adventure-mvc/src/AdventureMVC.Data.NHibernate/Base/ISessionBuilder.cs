using NHibernate;
using NHibernate.Cfg;

namespace AdventureMVC.Data.NHibernate
{
    public interface ISessionBuilder
    {
        ISession GetSession();
        Configuration GetConfiguration();
        ISession GetExistingWebSession();
    }
}