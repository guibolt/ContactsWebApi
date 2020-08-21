using ContactsWebApi.Application_.Commands.RegisterUsuario;
using ContactsWebApi.Application_.Helpers;
using ContactsWebApi.Application_.Helpers.Interfaces;
using ContactsWebApi.Core.Entities;
using ContactsWebApi.Core.Repository;
using ContactsWebApi.Infrastructure;
using ContactsWebApi.Infrastructure.EntityContext;
using ContactsWebApi.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContactsWebApi.CrossCutting.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddMediatR(typeof(RegisterUsuarioCommand));

            //Sql
            services.AddDbContext<ContactsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("StringConexao")), ServiceLifetime.Singleton);

            //Helper
            services.AddScoped<ITokenValidationHelper, TokenValidationHelper>();
            //Repo
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IGenericRepository<Contato>, ContactsRepository>();
            services.AddTransient<IGenericRepository<ContatoEmail>, EmailsRepository>();
            services.AddTransient<IGenericRepository<ContatoTelefone>, TelefoneRepository>();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

        }

    }
}
