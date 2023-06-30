using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Service.FarmaceuticalService.Interface;

namespace Library.Service.FarmaceuticalService
{
    public class DrugWarehouseService : IDrugWarehouseService
    {
        private readonly IDrugService _drugService;
        private readonly IDrugOrderService _drugOrderService;

        public DrugWarehouseService(IDrugService drugService, IDrugOrderService drugOrderService)
        {
            _drugService = drugService;
            _drugOrderService = drugOrderService;
        }

        public void RestockAll()
        {
            var unfinishedDrugOrders = _drugOrderService.GetAllUnfinished(DateTime.Today).Values;
            unfinishedDrugOrders.ToList().ForEach(drugOrder => Restock(drugOrder));
        }

        public void CreateDrugOrder(KeyValuePair<int, int> order)
        {
            _drugOrderService.Add(new DrugOrder(order.Key, order.Value));
        }

        public void Restock(DrugOrder drugOrder)
        {
            var drug = _drugService.Get(drugOrder.DrugId);
            drug.Restock(drugOrder.OrderQuantity);
            _drugService.Update(drug);
            drugOrder.Finish();
            _drugOrderService.Update(drugOrder);
        }
    }
}
