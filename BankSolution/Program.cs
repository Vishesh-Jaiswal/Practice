using BankSolution.Contexts;
using BankSolution.Interfaces;
using BankSolution.Models;
using BankSolution.Services;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BankSolution
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                     {
                           new OpenApiSecurityScheme
                             {
                                 Reference = new OpenApiReference
                                 {
                                     Type = ReferenceType.SecurityScheme,
                                     Id = "Bearer"
                                 }
                             },
                             new string[] {}

                     }
                 });
            });

            builder.Services.AddDbContext<BankSolutionContext>(options =>
                    {
                        options.UseSqlite("Data Source=mydatabase.db");
                    });


            #region REPOSITORIES
            builder.Services.AddScoped<IRepository<int, User>, UserRepository>();
            builder.Services.AddScoped<IRepository<int, Account>, AccountRepository>();
            builder.Services.AddScoped<IAccountNumberGenerator, RandomAccountNumberGenerator>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            // Scoped services
            builder.Services.AddScoped<BankAccountService>();
            builder.Services.AddScoped<AccountTransferService>();
            builder.Services.AddScoped<ChangeBalanceService>();
            builder.Services.AddScoped<CheckAccountTypeService>();
            // Transient or scoped service depending on their implementations
            builder.Services.AddScoped<IAccountOperationsService, BankAccountService>();
            builder.Services.AddScoped<IAccountTransferService, AccountTransferService>();

            #endregion

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.MapControllers();
            app.UseAuthorization();
            app.Run();
        }
    }
}