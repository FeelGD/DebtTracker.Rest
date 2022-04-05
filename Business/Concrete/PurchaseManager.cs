using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PurchaseManager:IPurchaseService
    {
        private IPurchaseService _purchaseService;
        public PurchaseManager(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }
    }
}
