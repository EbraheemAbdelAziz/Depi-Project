using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelGuide.Entiteis.Models;
using TravelGuide.Repositories.Interfaces;

namespace TravelGuide.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IBaseRepository<Payment> _payment;

        public PaymentController(IBaseRepository<Payment> payment)
        {
            _payment = payment;
        }

        // GET: PaymentController

        public async Task<ActionResult> Index()
        {
            var payments = await _payment.GetAll();
            return View("PaymentsList",payments);
        }

        // GET: PaymentController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var payment = _payment.GetById(id);
            return View("paymentDetails", payment);
        }

        // GET: PaymentController/Create
        public async Task<ActionResult> Create()
        {
            return View("NewPayment");
        }

        // POST: PaymentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Payment payment)
        {
            try
            {
                await _payment.AddItem(payment);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
				return View("NewPayment");
			}
        }

        // GET: PaymentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var payment = await _payment.GetById(id);
            if (payment == null)
            {
				return RedirectToAction(nameof(Index));
			}
            return View("EditPayment", payment);
        }

        // POST: PaymentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Payment payment)
        {
            try
            {
                await _payment.UpdateItem(payment);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
				return View("EditPayment", payment);
			}
        }

        // GET: PaymentController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
			var payment = await _payment.GetById(id);
			if (payment == null)
			{
				return RedirectToAction(nameof(Index));
			}
			return View("DeletePayment", payment);
        }

        // POST: PaymentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _payment.DeleteItem(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("DeletePayment");

			}
        }
    }
}
