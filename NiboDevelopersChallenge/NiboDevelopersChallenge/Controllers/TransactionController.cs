using NiboDevelopersChallenge.Models;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NiboDevelopersChallenge.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        /* 
         * Get the list passed and filter duplicated transactions;
         * The user can,t access this action direct;
        */
        public ActionResult Index()
        {
            try
            {
                List<Transaction> transactions = new List<Transaction>();
                transactions = (List<Transaction>)TempData["transactions"];

                var resultquery = transactions.GroupBy(transaction => new { transaction.TransDescription, transaction.TransDate, transaction.TransValue, transaction.TransType }).Select(transaction => transaction.First());
                return View(resultquery);
            }
            catch
            {
                return RedirectToAction("Index", "UploadFile");
            }
        }
    }
}