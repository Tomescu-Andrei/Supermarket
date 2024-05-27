using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3._1.Models.BusinessLogicLayer
{
    public class ReceiptBLL
    {
        private Supermarket2Entities context = new Supermarket2Entities();
        public ObservableCollection<Receipt> receipts { get; set; }
        public string ErrorMessage { get; set; }

        public ReceiptBLL()
        {
            receipts = new ObservableCollection<Receipt>();
        }

        public ObservableCollection<Receipt> GetAllReceipt()
        {
            List<Receipt> receipts = context.Receipts.ToList();
            ObservableCollection<Receipt> receip = new ObservableCollection<Receipt>();
            foreach (Receipt rec in receipts)
            {
                receip.Add(rec);
            }
            return receip;
        }

        public void AddMethod(object obj)
        {
            Receipt rct = obj as Receipt;
            if (rct.EmployeeID == 0)
                ErrorMessage = "Selecteaza un angajat din lista";
            else if (rct.Date == null)
                ErrorMessage = "Data trebuie precizat";
            else
            {
                context.Receipts.Add(rct);
                context.SaveChanges();
                rct.ReceiptID = context.Receipts.Max(item => item.ReceiptID);
                receipts.Add(rct);
                ErrorMessage = "";
            }
        }

        public void UpdateMethod(Receipt receipt)
        {
            var existingReceipt = receipts.LastOrDefault(r => r.ReceiptID == receipt.ReceiptID);
            if (existingReceipt != null)
            {
                existingReceipt.EmployeeID = receipt.EmployeeID;
                existingReceipt.Date = receipt.Date;
                existingReceipt.IsActive = receipt.IsActive;
                context.SaveChanges();
            }
        }

        
    }
}
