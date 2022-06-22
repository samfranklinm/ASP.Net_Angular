using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Interface
{
    public interface IPayment
    {
        Task<List<PaymentDetail>> GetAllPayments();
        Task<PaymentDetail> GetById(Guid id);
        Task<PaymentDetail> Create(PaymentDetail paymentDetail);
        Task<PaymentDetail> Update(Guid id, PaymentDetail paymentDetail);
        Task<PaymentDetail> Delete(Guid id);
       
    }
}
