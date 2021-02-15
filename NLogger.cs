
using System;


namespace A4___Movie_Library_Assignment_LINZ
{
    class NLogger
    {

        public void nLog(string actionType)
        {
            string path = "nlog.config";
            var logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();
            logger.Info(actionType);
        }
    }
}