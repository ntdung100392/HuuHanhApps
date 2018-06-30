using HHCoApps.Services.Implementation;
using HHCoApps.Services.Interfaces;
using Ninject.Modules;

namespace HHCoApps.Services
{
    public class NinjectBindingServices : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserServices>().To<UserServices>();
            Bind<IProductServices>().To<ProductServices>();
            Bind<ISupplierServices>().To<SupplierServices>();
            Bind<ICategoryServices>().To<CategoryServices>();
        }
    }
}
