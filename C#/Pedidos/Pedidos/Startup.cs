using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pedidos.Dados;
using Pedidos.Dados.Interface;
using Pedidos.UseCase.Orders;
using Pedidos.UseCase.Orders.Interfaces;
using Pedidos.UseCase.Products;
using Pedidos.UseCase.Products.Interfaces;
using System;

namespace Pedidos
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
            services.AddCors();
            services.AddControllers();

            //Inje��o de dependencia de UseCases
            services.AddTransient<ICriarPedidoUseCase, CriarPedidoUseCase>();
            services.AddTransient<IConsultarPedidosUseCase, ConsultarPedidosUseCase>();
            services.AddTransient<IIntegrarProdutoUseCase, IntegrarProdutoUseCase>();
            services.AddTransient<IEnviarMensagemRabbitUseCase, EnviarMensagemRabbitUseCase>();
            services.AddTransient<IChangeOrderStatusUseCase, ChangeOrderStatusUseCase>();

            //Inje��o de dependencia de UseCases products

            services.AddTransient<ICreateProductUseCase, CreateProductUseCase>();
            services.AddTransient<IGetProductsUseCase, GetProductsUseCase>();
            services.AddTransient<IUpdateProductUseCase, UpdateProductUseCase>();
            services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
            
            //Inje��o de dependencia de DAO
            services.AddTransient<IOrderDAO, OrderDAO>();
            services.AddTransient<IOrderStatusDAO, OrderStatusDAO>();
            services.AddTransient<IProductDAO, ProductDAO>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FastOrd", Version = "v1" });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fast Order");
            });

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
