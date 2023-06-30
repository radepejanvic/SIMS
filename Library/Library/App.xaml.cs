using Autofac;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Library.Configuration;
using Library.Model;
using Library.Service.FarmaceuticalService;
using Library.Service.PhysicalAssetService.Interface;
using Library.Service.TehnicalService;
using Library.Service.TehnicalService.Interface;

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

            IRenovationService renovationService;
            IRoomService roomService;
            IEquipmentService equipmentService;
            IDrugWarehouseService drugWarehouseService;
            ICustomNotificationService customNotificationService;
            using (var scope = container.BeginLifetimeScope())
            {
                loginService =  scope.Resolve<ILoginService>();

                var dataGenerator = scope.Resolve<IDataGenerator>();

                //dataGenerator.GenerateRandomHospitalRefferal(10);
             
                equipmentService =  scope.Resolve<IEquipmentService>();
                roomService = scope.Resolve<IRoomService>();
                renovationService = scope.Resolve<IRenovationService>();
                drugWarehouseService = scope.Resolve<IDrugWarehouseService>();
                customNotificationService = scope.Resolve<ICustomNotificationService>();
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
        async Task PeriodicTaskAsync(IEquipmentService equipmentService, IDrugWarehouseService drugWarehouseService, ICustomNotificationService customNotificationService)
        {
            while (true)
            {
                ThreadService.CallAllThread(equipmentService, drugWarehouseService, customNotificationService);
                await Task.Delay(60000);
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }

    }
}
