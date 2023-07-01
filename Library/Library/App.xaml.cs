using Autofac;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Library.Configuration;
using Library.Core.TehnicalService.Interface;
using Library.GUI.Helpers.Generator;

namespace Library
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            
        }

   
        protected override void OnStartup(StartupEventArgs e)
        {
            // Maybe exctract to separate method 
            var container = ContainerConfiguration.Configure();
            ILoginService loginService;

           
            using (var scope = container.BeginLifetimeScope())
            {
                loginService =  scope.Resolve<ILoginService>();

                //var userGenerator = scope.Resolve<IUserGenerator>();
                //userGenerator.GenerateUsers(5, 10);

            }

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(loginService)
            };
            MainWindow.Show();
            //ThreadService.ProcessRoomRenovation(renovationService, roomService);
            //PeriodicTaskAsync(equipmentService, drugWarehouseService, customNotificationService);
            base.OnStartup(e);
        }

        //async Task PeriodicTaskAsync(IEquipmentService equipmentService, IDrugWarehouseService drugWarehouseService, ICustomNotificationService customNotificationService)
        //{
        //    while (true)
        //    {
        //        ThreadService.CallAllThread(equipmentService, drugWarehouseService, customNotificationService);
        //        await Task.Delay(60000);
        //    }
        //}

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }

    }
}
