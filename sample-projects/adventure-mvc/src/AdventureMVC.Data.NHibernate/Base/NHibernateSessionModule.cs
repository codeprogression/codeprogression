using System.Web;
using NHibernate;

namespace AdventureMVC.Data.NHibernate
{
    public class NHibernateSessionModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.EndRequest += context_EndRequest;
        }

        void context_EndRequest(object sender, System.EventArgs e)
        {
            ISessionBuilder builder = new SessionBuilder();
            ISession session = builder.GetExistingWebSession();
            if (session != null)
            {
//                Log.Debug(this, "Disposing of ISession " + session.GetHashCode());
                session.Dispose();
            }
        }

        public void Dispose()
        {

        }
    }

    public class HttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            new NHibernateSessionModule().Init(context);
        }

        public void Dispose()
        {
        }
    }
}