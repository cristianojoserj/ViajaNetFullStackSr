using System;

namespace ViajaNetFullStackSr.Domain
{
    public class Log
    {
        public Guid Id { get; set; }
        public string Ip { get; set; }
        public string PageName { get; set; }
        public string BrowserName { get; set; }
        public string Parameters { get; set; }
    }
}
