using NHibernate;
using NHibernate.Cfg;

namespace QLSV
{
    public class NhibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            configuration.Configure(@"D:\QLSVnew\QLSV\Models\hibernate.cfg.xml");
            configuration.AddFile(@"D:\QLSVnew\QLSV\Mappings\Models.hbn.xml");
            configuration.AddFile(@"D:\QLSVnew\QLSV\Mappings\DTO.hbn.xml");
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
