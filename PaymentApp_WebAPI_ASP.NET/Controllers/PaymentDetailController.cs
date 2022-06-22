using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Interface;
using WebAPI.Models;
 // CRUD Operations
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private IPayment _paymentServices;

        public PaymentDetailController(IPayment paymentServices)                                // Constructor that takes the param context in Startup.cs - `services.AddDbContext`
        {
            _paymentServices = paymentServices;
        }

        // GET: api/PaymentDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetails()         // returns the details for DB Table    
        {
            return await _paymentServices.GetAllPayments();
        }

        // GET: api/PaymentDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetail>> GetPaymentDetail(int id)
        {

            return await _paymentServices.GetById(id);
        }

        // PUT: api/PaymentDetail/5                     
        [HttpPut("{id}")]
        public async Task<ActionResult<PaymentDetail>> PutPaymentDetail(int id, PaymentDetail paymentDetail)     // for `id` use URI, for `paymentDetail` use "boarding"
        {
            return await _paymentServices.Update(id, paymentDetail);
        }

        // POST: api/PaymentDetail
        [HttpPost]
        public async Task<ActionResult<PaymentDetail>> PostPaymentDetail(PaymentDetail paymentDetail)
        {
            return await _paymentServices.Create(paymentDetail);
        }

        // DELETE: api/PaymentDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentDetail>> DeletePaymentDetail(int id)
        {

            return await _paymentServices.Delete(id);
        }
    }
}
