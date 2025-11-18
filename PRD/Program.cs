using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;
using PRD.Components;
using PRD.Data;
using PRD.Intefaces;
using PRD.Services;

namespace PRD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddMudServices(config =>
            {

                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;
                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = true;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 3000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;

            });
            builder.Services.AddServerSideBlazor()
    .AddHubOptions(options =>
    {
        options.MaximumReceiveMessageSize = 1024 * 1024 * 100; // 100 MB
    });



            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            // 
            builder.Services.AddMudServices();
            //
            //builder.Services.AddTransient<SeedDb>();
            //builder.Services.AddSweetAlert2();


            //builder.Services.AddScoped<LoginService>();
            //builder.Services.AddScoped<UserStateService>();
            // builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            // Registra o serviço para CDNome
            // builder.Services.AddScoped<CDNomeService>();
            // Registra o serviço para Departamento
            //  builder.Services.AddScoped<DepService>();

            //para filtar filial logado
            //  builder.Services.AddScoped<IUserContext, UserContext>();

            //  builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IProdutoService, ProdutoServiceBulk>();

            builder.Services.AddScoped<IBaseLNcsService, BaseLNcsService>();
            builder.Services.AddScoped<IBaseFiscalDocaService, BaseFiscalDocaService>();
            builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name =LocalConnection"));
            var app = builder.Build();

            //  SeedData(app);

         


            //static void SeedData(WebApplication app)
            //{
            //    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();
            //    using IServiceScope scope = scopedFactory!.CreateScope();
            //    SeedDb? service = scope.ServiceProvider.GetService<SeedDb>();
            //    service!.SeedAsync().Wait();

            //}
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run(); ;
        }
    }
}
