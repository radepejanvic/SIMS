using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Library.Model;
using Library.Service.FarmaceuticalService;
using Library.Service.PhysicalAssetService.Interface;
using Library.Service.TehnicalService.Interface;

namespace Library.Service.TehnicalService
{
    public static class ThreadService
    {
        public static void CallAllThread(IEquipmentService equipmentService, IDrugWarehouseService drugWarehouseService, ICustomNotificationService customNotificationService)
        {
            //ProcessDynamicEquipmentRequestThread(equipmentService);
            ProcessDrugOrdersThread(drugWarehouseService);
        }
        private static void ProcessDynamicEquipmentRequestThread(IEquipmentService equipmentService)
        {
            List<DynamicalEquipmentRequest> _dynamicalEquipmentRequests = equipmentService.GetUnfinishedDynamicalEquipmentRequests();
            _dynamicalEquipmentRequests.ForEach(x => equipmentService.UpdateDynamicalEquipmentBook(x));
            equipmentService.UpdateCompletedEquipmentRequests(_dynamicalEquipmentRequests);
        }

        private static void ProcessDrugOrdersThread(IDrugWarehouseService drugWarehouseService)
        {
            drugWarehouseService.RestockAll();
        }
       public static void ProcessRoomRenovation(IRenovationService renovationService,IRoomService roomService)
        {
            renovationService.ProcessRoomRenovation(roomService);
            renovationService.ProcessRoomDefusingRenovation(roomService);
            renovationService.ProcessRoomFusingRenovation(roomService);
            
        }

    }
}
