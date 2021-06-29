using System;
using Newtonsoft.Json;

namespace Jlw.Utilities.Data
{
    public class StartEndDateTime
    {
        [JsonConverter(typeof(JlwJsonConverter<DateTime?>))]
        public DateTime? StartDate { get; set; }
        [JsonConverter(typeof(JlwJsonConverter<DateTime?>))]
        public DateTime? EndDate { get; set; }

        public bool IsInWindow(DateTime dt)
        {
            return StartDate <= dt && EndDate >= dt;
        }
    }
}