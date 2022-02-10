using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WSCADCodeChallange.Business.File;
using WSCADCodeChallange.Business.Shape;
using WSCADCodeChallange.DataService;
using WSCADCodeChallange.Model.Factory;

namespace WSCADCodeChallange
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IFileBusiness,FileBusiness>();
            services.AddScoped<IFileDataService,FileDataService>();
            services.AddScoped<IShapeFactory, ShapeFactory>();

            services.AddTransient(typeof(MainWindow));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder();

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }


    }
}
