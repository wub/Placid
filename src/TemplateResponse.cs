using System;

namespace Placid
{
    public class TemplateResponse
    {
        public int Id { get; set; }

        public string? Status { get; set; } // queued, finished, error

        public Uri? PollingUrl { get; set; }
    }
}
