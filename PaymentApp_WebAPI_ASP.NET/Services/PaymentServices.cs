using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Interface;
using WebAPI.Models;



namespace WebAPI.Services
{
    public class PaymentServices : IPayment

    {
        private PaymentDetailContext _context;

        public PaymentServices(PaymentDetailContext context)                            // Constructor that takes the param context in Startup.cs - `services.AddDbContext`
        {
            _context = context;
        }

        // GET
        public async Task<List<PaymentDetail>> GetAllPayments()
        {
            // returns a list of payment details from the database
            return await _context.PaymentDetails.ToListAsync();
        }
        // GET (by ID)
        public async Task<PaymentDetail> GetById(Guid id)
        {   
            // returns payment details for the provided ID
            return await _context.PaymentDetails.FindAsync(id); 

        }

        // POST 
        public async Task<PaymentDetail> Create(PaymentDetail paymentDetail)                 
        {   
            // add the provided payment details
            _context.PaymentDetails.Add(paymentDetail);
            await _context.SaveChangesAsync();

            return paymentDetail;
        }

        // PUT
        public async Task<PaymentDetail> Update(Guid id, PaymentDetail paymentDetail)
        {
            // update the provided payment details
            _context.PaymentDetails.Update(paymentDetail);
            await _context.SaveChangesAsync();

            return paymentDetail;
        }

        // DELETE 
        public async Task<PaymentDetail> Delete(Guid id)
        {
            // Find the entry by id
            var paymentDetail = await _context.PaymentDetails.FindAsync(id);

            // If no details are found
            if (paymentDetail == null)
            {
                throw new Exception("This payment detail doesn't exist.");
            }

            // otherwise, delete from database
            _context.PaymentDetails.Remove(paymentDetail);
            await _context.SaveChangesAsync();

            return paymentDetail;
        }
    }
}
