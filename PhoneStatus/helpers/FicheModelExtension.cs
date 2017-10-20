using PhoneStatus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneStatus.helpers
{
    public static class FicheModelExtension
    {
        public static string Description(this FicheModel model)
        {
            return "text";
        }
    }
}