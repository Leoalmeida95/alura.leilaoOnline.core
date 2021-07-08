using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnline.WebApp.Dados;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.LeilaoOnline.WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration cfg)
        {
            Configuration = cfg;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var cnxString = Configuration.GetConnectionString("LeiloesDB");
            services.AddDbContext<LeiloesContext>(options =>
            {
                options.UseSqlServer(cnxString);
            });
            services.AddTransient<IModalidadeAvaliacao, MaiorValor>();
            services.AddTransient<IRepositorio<Leilao>, RepositorioLeilao>();
            services.AddTransient<IRepositorio<Interessada>, RepositorioInteressada>();
            services.AddTransient<IRepositorio<Usuario>, RepositorioUsuario>();
            services.AddSession();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSession();

            app.UseMvcWithDefaultRoute();
        }
    }
}
