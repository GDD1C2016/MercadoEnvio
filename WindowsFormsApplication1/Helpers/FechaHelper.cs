﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoEnvio.Helpers
{
    public class FechaHelper
    {
        public DateTime GetSystemDate()
        {
            DateTime systemDate = DateTime.Parse(ConfigurationManager.AppSettings["systemTime"]);
            return systemDate;
        }

        public bool ConfigDateIsValid()
        {
            DateTime resultParse;
            bool res = DateTime.TryParse(ConfigurationManager.AppSettings["systemTime"], out resultParse);
            return res;
        }
    }
}
