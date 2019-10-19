using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NiboDevelopersChallenge.Models
{
    public class UploadFile
    {
        public IEnumerable<HttpPostedFileBase> UploadFiles { get; set; }
    }
}