using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Evaluation.Areas.Identity.IdentityHostingStartup))]
namespace Evaluation.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}