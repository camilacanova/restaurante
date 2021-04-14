using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PedidoAPI.Data;
using PedidoAPI.Data.Repositories;
using PedidoAPI.Model;
using PedidoAPI.Services;
using PedidoAPI.Strategies;

namespace PedidoAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var ConnectionString = Configuration.GetConnectionString("PedidoDB");

            services.AddControllers();

            services.AddEntityFrameworkNpgsql()
             .AddDbContext<PedidoContext>(options => options.UseNpgsql(ConnectionString));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Pedido Service API",
                    Version = "v2",
                    Description = "Serviços para operações de pedido e pagamento de um restaurante",
                });
            });

            //repositories
            services.AddTransient<IRepository<Pedido>, AbstractRepository<Pedido>>();
            services.AddTransient<AbstractRepository<Pedido>, PedidoRepository>();

            services.AddTransient<IRepository<ItemPedido>, AbstractRepository<ItemPedido>>();
            services.AddTransient<AbstractRepository<ItemPedido>, ItemPedidoRepository>();

            services.AddTransient<IRepository<Pagamento>, AbstractRepository<Pagamento>>();
            services.AddTransient<AbstractRepository<Pagamento>, PagamentoRepository>();

            services.AddTransient<ITypeRepository<Mesa>, AbstractTypeRepository<Mesa>>();
            services.AddTransient<AbstractTypeRepository<Mesa>, MesaRepository>();

            //services
            services.AddTransient<IService<Pedido>, PedidoService>();
            services.AddTransient<IService<ItemPedido>, ItemPedidoService>();
            services.AddTransient<IService<Pagamento>, PagamentoService>();
            services.AddTransient<ITypeService<Mesa>, MesaService>();

            //strategies
            services.AddTransient<IGetProdutoStrategy, GetProdutoStrategy>();

            services.AddTransient<IGetItemPedido, GetItemPedido>();
            services.AddTransient<IPatchItemPedido, PatchItemPedido>();
            services.AddTransient<IPostItemPedido, PostItemPedido>();
            
            services.AddTransient<IPatchPedido, PatchPedido>();
            services.AddTransient<IPostPedido, PostPedido>();

            services.AddTransient<IPostPagamento, PostPagamento>();

            services.AddHttpClient();
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            services.AddControllers().AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "Pedido Service v2"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors("MyPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
