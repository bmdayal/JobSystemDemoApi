using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JobSystemDemoApi.DBHelpers;
using JobSystemDemoApi.Domain;
using JobSystemDemoApi.Interface;
using JobSystemDemoApi.Model;
using System.Configuration;

namespace JobSystemDemoApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var aerospikeConfigurationOptions = new AerospikeConfigurationOptions();

            services.Configure<AerospikeConfigurationOptions>(Configuration.GetSection(AerospikeConfigurationOptions.ServerConfig));
            services.Configure<SqlServerConfigurationOptions>(Configuration.GetSection(SqlServerConfigurationOptions.ServerConfig));
            services.Configure<MySqlConfigurationOptions>(Configuration.GetSection(MySqlConfigurationOptions.ServerConfig));

            services.AddSingleton<IAccountsCalculatorModel, AccountsCalculatorModel>();

            //Uncomment the line below to enable Aerospike OR SqlServer Read/Write
            //services.AddSingleton<IDbLogHelper, AeroLogHelper>(); 
            //services.AddSingleton<IDbLogHelper, SqlLogHelper>();
            services.AddSingleton<IDbLogHelper, MySqlLogHelper>();


            services.AddSingleton<IAccountsService, AccountsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
