using HHCoApps.Services.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using WareHouseApps.Helper;

namespace WareHouseApps
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StandardKernel standardKernel = new StandardKernel();
            standardKernel.Load(Assembly.GetExecutingAssembly());
            log4net.Config.XmlConfigurator.Configure();
            new MapperInit().Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#if DEBUG
            Application.Run(
                new MainMenu(
                    standardKernel.Get<ISupplierServices>(),
                    standardKernel.Get<ICategoryServices>(),
                    standardKernel.Get<IProductServices>()
                    ));
#else
            Application.Run(new Login(standardKernel.Get<IUserServices>()));
#endif
        }
    }
}
