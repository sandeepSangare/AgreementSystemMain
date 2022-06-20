using System;
using AgreementSystem.Areas.Identity.Data;
using AgreementSystem.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AgreementSystem.Areas.Identity.IdentityHostingStartup))]
namespace AgreementSystem.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<AgreementSystemContext>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("AgreementSystemContextConnection")));

            //    services.AddDefaultIdentity<AgreementSystemUser>(options => options.SignIn.RequireConfirmedAccount = false)
            //        .AddEntityFrameworkStores<AgreementSystemContext>();
            //});
        }
    }
}