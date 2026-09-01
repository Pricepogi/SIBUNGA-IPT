using System.Text.Json;

namespace SibungaAPI.Models
{
    // Generic wrapper for the healthcare.gov index.json. We keep the raw JSON element
    // because the structure may change; components can inspect specific fields as needed.
    public class HealthcareIndex
    {
        public JsonElement Raw { get; set; }
    }
}
