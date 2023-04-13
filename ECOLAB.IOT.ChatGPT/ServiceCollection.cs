namespace ECOLAB.IOT.ChatGPT
{
    using ECOLAB.IOT.ChatGPT.Provider;
    using ECOLAB.IOT.ChatGPT.Repository;
    using ECOLAB.IOT.ChatGPT.Service;

    public static class ServiceCollection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            if (services == null)
                return null;

            services.AddScoped<IELinkService, ELinkService>();
            services.AddScoped<IChatGPTService, ChatGPTService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            if (services == null)
                return null;

            services.AddScoped<IELinkRepository, ELinkRepository>();
            return services;
        }

        public static IServiceCollection AddProviders(this IServiceCollection services)
        {
            if (services == null)
                return null;

            services.AddScoped<IElinkChatGPTProvider, ElinkChatGPTProvider>();
            return services;
        }
    }
}
