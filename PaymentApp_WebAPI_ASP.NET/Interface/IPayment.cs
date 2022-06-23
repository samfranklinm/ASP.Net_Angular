using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Interface
{
    public interface IPayment
    {
        Task<List<PaymentDetail>> GetAllPayments();
        Task<PaymentDetail> GetById(int id);
        Task<PaymentDetail> Create(PaymentDetail paymentDetail);
        Task<PaymentDetail> Update(int id, PaymentDetail paymentDetail);
        Task<PaymentDetail> Delete(int id);
       
    }
}
