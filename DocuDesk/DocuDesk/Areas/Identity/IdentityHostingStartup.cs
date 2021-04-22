using System;
using DocuDesk.Areas.Identity.Data;
using DocuDesk.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(DocuDesk.Areas.Identity.IdentityHostingStartup))]
namespace DocuDesk.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DocuDeskDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DocuDeskDBContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<DocuDeskDBContext>();
            });
        }
    }
}