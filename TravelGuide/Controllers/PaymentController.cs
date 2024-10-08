﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TravelGuide.Entiteis.Models;
using TravelGuide.Repositories.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace TravelGuide.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IBaseRepository<Payment> _payment;
        private readonly IBaseRepository<FlightBooking> _flightBooking;
        private readonly IBaseRepository<RoomBooking> _roomBooking;
        private readonly IBaseRepository<PackageBooking> _packageBooking;

        public PaymentController(IBaseRepository<Payment> payment, IBaseRepository<FlightBooking> flightBooking, IBaseRepository<RoomBooking> roomBooking, IBaseRepository<PackageBooking> packageBooking)
        {
            _payment = payment;
            _flightBooking = flightBooking;
            _roomBooking = roomBooking;
            _packageBooking = packageBooking;
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
            var payment =await _payment.GetById(id);
            return View("paymentDetails", payment);
        }

        // GET: PaymentController/Create
        public async Task<ActionResult> Create(string? type = null ,string? BookingId = null)
        {
            if (type != null && BookingId != null)
            {
                var payment = new Payment();
                payment.MethodsList = new List<string>{
                    "Credit Card",       // Traditional payment method
                    "Debit Card",        // Direct bank account payment
                    "PayPal",            // Online payment system
                    "Bank Transfer",     // Direct transfer between bank accounts
                    "Cryptocurrency",    // Digital currency payments
                    "Cash",              // Physical cash payment
                    "Check",             // Payment via written order
                    "Mobile Payment",    // Payments through mobile apps (e.g., Apple Pay, Google Pay)
                    "Invoice",           // Payment after receiving an invoice
                    "Buy Now, Pay Later" // Deferred payment option
                    };
                payment.CurrencyList = new List<string>
                    {
                        "USD", // United States Dollar
                        "EUR", // Euro
                        "JPY", // Japanese Yen
                        "GBP", // British Pound Sterling
                        "AUD", // Australian Dollar
                        "CAD", // Canadian Dollar
                        "CHF", // Swiss Franc
                        "CNY", // Chinese Yuan
                        "SEK", // Swedish Krona
                        "NZD"  // New Zealand Dollar
                    };
                if (type == "roomBooking")
                {
                    payment.RoomBooking = await _roomBooking.GetById( int.Parse(BookingId));
                    payment.RoomBookingId = int.Parse(BookingId);
                    return View("NewPayment",payment);
                }
                else if (type == "flightBooking")
                {
                    var flightBook = await _flightBooking.GetById(int.Parse(BookingId));
                    payment.FlightBooking = flightBook;
                    payment.FlightBookingId = int.Parse(BookingId);
                    return View("NewPayment", payment);
                }
                else if (type == "packageBooking")
                {
                    payment.PackageBooking = await _packageBooking.GetById(int.Parse(BookingId));
                    payment.PackageBookingId = int.Parse(BookingId);
                    return View("NewPayment", payment);
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: PaymentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Payment payment , string BookingId)
        {
            try
            {
                payment.PaymentDate = DateTime.Now;
                await _payment.AddItem(payment);
                if (payment.FlightBookingId != null)
                {
                    var booking =await _flightBooking.GetById(int.Parse(BookingId));
                    booking.BookingStatus = true;
                    await _flightBooking.UpdateItem(booking);
                }
                if (payment.RoomBookingId != null)
                {
                    var booking = await _roomBooking.GetById(int.Parse(BookingId));
                    booking.BookingStatus = true;
                    await _roomBooking.UpdateItem(booking);
                }
                if (payment.PackageBookingId != null)
                {
                    var booking = await _packageBooking.GetById(int.Parse(BookingId));
                    booking.BookingStatus = true;
                    await _packageBooking.UpdateItem(booking);
                }
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
            payment.MethodsList = new List<string>{
                    "Credit Card",       // Traditional payment method
                    "Debit Card",        // Direct bank account payment
                    "PayPal",            // Online payment system
                    "Bank Transfer",     // Direct transfer between bank accounts
                    "Cryptocurrency",    // Digital currency payments
                    "Cash",              // Physical cash payment
                    "Check",             // Payment via written order
                    "Mobile Payment",    // Payments through mobile apps (e.g., Apple Pay, Google Pay)
                    "Invoice",           // Payment after receiving an invoice
                    "Buy Now, Pay Later" // Deferred payment option
                    };
            payment.CurrencyList = new List<string>
                    {
                        "USD", // United States Dollar
                        "EUR", // Euro
                        "JPY", // Japanese Yen
                        "GBP", // British Pound Sterling
                        "AUD", // Australian Dollar
                        "CAD", // Canadian Dollar
                        "CHF", // Swiss Franc
                        "CNY", // Chinese Yuan
                        "SEK", // Swedish Krona
                        "NZD"  // New Zealand Dollar
                    };
            return View("EditPayment", payment);
        }

        // POST: PaymentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Payment payment)
        {
            try
            {
                var oldPayment = await _payment.GetById(payment.PaymentId);
                payment.PaymentDate = oldPayment.PaymentDate;
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
            payment.MethodsList = new List<string>{
                    "Credit Card",       // Traditional payment method
                    "Debit Card",        // Direct bank account payment
                    "PayPal",            // Online payment system
                    "Bank Transfer",     // Direct transfer between bank accounts
                    "Cryptocurrency",    // Digital currency payments
                    "Cash",              // Physical cash payment
                    "Check",             // Payment via written order
                    "Mobile Payment",    // Payments through mobile apps (e.g., Apple Pay, Google Pay)
                    "Invoice",           // Payment after receiving an invoice
                    "Buy Now, Pay Later" // Deferred payment option
                    };
            payment.CurrencyList = new List<string>
                    {
                        "USD", // United States Dollar
                        "EUR", // Euro
                        "JPY", // Japanese Yen
                        "GBP", // British Pound Sterling
                        "AUD", // Australian Dollar
                        "CAD", // Canadian Dollar
                        "CHF", // Swiss Franc
                        "CNY", // Chinese Yuan
                        "SEK", // Swedish Krona
                        "NZD"  // New Zealand Dollar
                    };
            return View("DeletePayment", payment);
        }

        // POST: PaymentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Payment item)
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
