using CodeZoneTest.Data.Models;
using CodeZoneTest.Interfaces;
using CodeZoneTest.Data.Repositories;
using CodeZoneTest.Services;
namespace CodeZoneTest.Helper
{
    public static class ServicesRegister
    {
        public static IServiceCollection RgisterAppServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Store>, Repository<Store>>();
            services.AddScoped<IRepository<Item>, Repository<Item>>();
            services.AddScoped<IRepository<StoreItems>, Repository<StoreItems>>();
            services.AddScoped<IStoreServices, StoreServices>();
            services.AddScoped<IItemServices, ItemServices>();
            services.AddScoped<IStoreItemsServices, StoreItemsServices>();
            return services;
        }
    }
}
