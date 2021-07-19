using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;

namespace Epam.XT.SchoolTestingSystem.WebPL.Models
{
    public static class NLogger
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();
    }
}