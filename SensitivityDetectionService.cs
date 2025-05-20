
using System.Collections.Generic;
using System.Linq;

namespace JusticeSecSensitivityChecker.Services
{
    public class SensitivityDetectionService
    {
        private readonly List<string> sensitiveKeywords = new()
        {
            "badge", "informant", "case", "safehouse", "witness", "confidential"
        };

        public Dictionary<string, string> AnalyzeFields(Dictionary<string, string> inputs)
        {
            var result = new Dictionary<string, string>();
            foreach (var field in inputs)
            {
                string value = field.Value.ToLower();
                bool isSensitive = sensitiveKeywords.Any(keyword => value.Contains(keyword));
                result[field.Key] = isSensitive ? "Sensitive" : "Safe";
            }
            return result;
        }
    }
}
