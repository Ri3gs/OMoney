using System.Reflection;
using Ninject;
using Ninject.Modules;
using OMoney.Data.Repositories;
using OMoney.Data.Repositories.Accounts;
using OMoney.Data.Repositories.Categories;
using OMoney.Data.Repositories.Currencies;
using OMoney.Data.Repositories.Plans;
using OMoney.Data.Repositories.Purchases;
using OMoney.Data.Repositories.Users;
using OMoney.Domain.Services.Accounts;
using OMoney.Domain.Services.Categories;
using OMoney.Domain.Services.Currencies;
using OMoney.Domain.Services.Notifications;
using OMoney.Domain.Services.Plans;
using OMoney.Domain.Services.Purchases;
using OMoney.Domain.Services.Users;
using OMoney.Web.Api.Context;

namespace OMoney.Web.Api
{
    public class NinjectWebCommon
    {
        public static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }
    }

    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IAccountService>().To<AccountService>();
            Bind<IAccountRepository>().To<AccountRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<INotificationService>().To<NotificationService>();
            Bind<IPlanService>().To<PlanService>();
            Bind<IPlanRepository>().To<PlanRepository>();
            Bind<ICategoryRepository>().To<CategoryRepository>();
            Bind<ICategoryService>().To<CategoryService>();
            Bind<IPurchaseRepository>().To<PurchaseRepository>();
            Bind<IPurchaseService>().To<PurchaseService>();
            Bind<ICurrencyRepository>().To<CurrencyRepository>();
            Bind<ICurrencyService>().To<CurrencyService>();
            Bind<ICurrentUser>().To<CurrentUser>();
        }
    }
}