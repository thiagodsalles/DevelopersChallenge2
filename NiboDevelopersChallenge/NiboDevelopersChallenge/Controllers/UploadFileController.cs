using NiboDevelopersChallenge.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NiboDevelopersChallenge.Controllers
{
    public class UploadFileController : Controller
    {
        // GET: UploadFile
        public ActionResult Index()
        {
            return View();
        }

        //POST: UploadFile
        /* 
         * This controller get multiple OFX files and save then on /Content/ofx;
         * Open each file and read line by line;
         * Create an object called Transaction, filter each data and save then;
         * Beautify <DTPOSTED> content by a function;
         * Add to transaction list;
         * Redirect to Transaction Controller passing the list;
        */
        [HttpPost]
        public ActionResult Index(UploadFile archives)
        {
            try
            {
                List<Transaction> transactions = new List<Transaction>();

                foreach (var ofx in archives.UploadFiles)
                {
                    if (ofx.ContentLength > 0)
                    {
                        var ArchiveFileName = Path.GetFileName(ofx.FileName);
                        var ArchivePath = Path.Combine(Server.MapPath("~/Content/ofx"), ArchiveFileName);
                        ofx.SaveAs(ArchivePath);

                        var lines = System.IO.File.ReadAllLines(ArchivePath);
                        var i = 0;
                        while (i < lines.Length)
                        {

                            if (lines[i].Contains("<TRNTYPE>"))
                            {
                                var trans = new Transaction();

                                trans.TransType = lines[i].Remove(0, 9);
                                trans.TransDate = trans.TransformToDateFormat(lines[i + 1]);
                                trans.TransValue = lines[i + 2].Remove(0, 8);
                                trans.TransDescription = lines[i + 3].Remove(0, 6);

                                transactions.Add(trans);

                                i += 4;
                            }
                            else
                            {
                                i += 1;
                            }
                        }
                    }
                }
                TempData["transactions"] = transactions;

                return RedirectToAction("Index", "Transaction");
            }
            catch
            {
                return View();
            }
        }
    }
}