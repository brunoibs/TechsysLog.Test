using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TechsysLog.App.IServices;
using TechsysLog.App.Services;
using TechsysLog.Data;
using TechsysLog.Data.Interface;
using TechsysLog.Data.Repository;

namespace TechsysLog.DI
{
    public static class ResolveInject
    {
        public static void RegisterServices(IServiceCollection services, string strConnectMice)
        {

            services.AddDbContext<Contexto>(
                options => options.UseSqlServer(strConnectMice));

            #region Repositorio

            services.AddTransient<IEntregaRepository, EntregaRepository>();
            services.AddTransient<IPedidosRepository, PedidosRepository>();
            services.AddTransient<IStatuspedidoRepository, StatuspedidoRepository>();
            services.AddTransient<IUsuariosRepository, UsuariosRepository>();


            #endregion

            #region Services

            services.AddTransient<IEntregaService, EntregaService>();
            services.AddTransient<IPedidosService, PedidosService>();
            services.AddTransient<IStatuspedidoService, StatuspedidoService>();
            services.AddTransient<IUsuariosService, UsuariosService>();

            #endregion


        }
    }
}