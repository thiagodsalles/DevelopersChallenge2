using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NiboDevelopersChallenge.Models
{
    public class Transaction
    {

        public Transaction()
        {
        }

        public string TransType { get; set; }
        public string TransDate { get; set; }
        public string TransValue { get; set; }
        public string TransDescription { get; set; }

        //Beautify <DTPOSTED> content
        public string TransformToDateFormat(string date)
        {
            return date.Remove(0, 10).Remove(14, 1).Remove(21, 1).Insert(4, "/").Insert(7, "/").Insert(10, " ").Insert(13, ":").Insert(16, ":").Insert(19, " ");
        }
    }
}