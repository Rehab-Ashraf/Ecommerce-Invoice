using INVOICE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVOICE.Repository
{
    interface IINOICERepository
    {
        IEnumerable<InvoiceVM> GetAllInvoices();
        InvoiceVM GetInvoiceByID(int InvoiceID);
        int NewInvoice(InvoiceVM invoice);
        int UpdateInvoice(InvoiceVM invoice);
        void DeleteInvoice(int InvoiceID);
    }
}
