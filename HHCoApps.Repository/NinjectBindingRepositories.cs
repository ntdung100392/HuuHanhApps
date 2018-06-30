using HHCoApps.Repository.Implementations;
using Ninject.Modules;

namespace HHCoApps.Repository
{
    public class NinjectBindingRepositories : NinjectModule
    {
        public override void Load()
        {
            Bind<ISupplierRepository>().To<SupplierRepository>();
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<ICategoryRepository>().To<CategoryRepository>();
        }
    }
}
