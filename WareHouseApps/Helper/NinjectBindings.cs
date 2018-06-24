using HHCoApps.Services.Implementation;
using HHCoApps.Services.Interfaces;
using Ninject.Modules;
namespace WareHouseApps.Helper
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserServices>().To<UserServices>();
            Bind<IProductServices>().To<ProductServices>();
            Bind<ISupplierServices>().To<SupplierServices>();
            Bind<ICategoryServices>().To<ProductServices>();
        }
    }
}
