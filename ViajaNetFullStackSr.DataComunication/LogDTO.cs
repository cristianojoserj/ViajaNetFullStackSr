using System;

namespace ViajaNetFullStackSr.DataComunication
{
    public class LogDTO
    {
        public Guid Id { get; set; }
        public string Ip { get; set; }
        public string PageName { get; set; }
        public string BrowserName { get; set; }
        public string Parameters { get; set; }
    }
}
