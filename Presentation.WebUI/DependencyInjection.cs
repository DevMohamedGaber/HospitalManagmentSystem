using Microsoft.AspNetCore.Identity;

namespace Presentation.WebUI
{
    public static class DependencyInjection
    {
        public static void ConfigureWebUI(this IServiceCollection services)
        {
            services.AddCascadingAuthenticationState();

            services.AddAuthentication();

            services.AddAuthorization();
        }
    }
}
