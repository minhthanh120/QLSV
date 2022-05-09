using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSV.Interface;
using QLSV.Data;
namespace QLSV.Service
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ActionFunction>());
            //container.Register(Component.For<IdbConnector>().ImplementedBy<dbConnector>());
            //container.Register(Component.For<IDataLoader>().ImplementedBy<DataLoader>());
            //container.Register(Component.For<IDataLoader>().ImplementedBy<hbnConnector>());
            container.Register(Component.For<IDataLoader>().ImplementedBy<dpConnector>());

        }
    }
}

