using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Inventory.Application
{
    public class RequestValidationException : Exception
    {
        public Dictionary<string, string[]> ValidationErrors { get; }

        private RequestValidationException()
        {
        }

        public RequestValidationException(IEnumerable<ValidationResult> validationResults)
        {
            var temp = new Dictionary<string,List<string>>();
            var resultsToAdd = validationResults.Where(x => x != null);
            foreach (var result in resultsToAdd)
            {
                var containsKey = temp.ContainsKey(result.ErrorMessage);
                if (containsKey)
                {
                    temp[result.ErrorMessage].AddRange(result.MemberNames);
                } else
                {
                    temp[result.ErrorMessage] = new List<string>(result.MemberNames);
                }
            }

            ValidationErrors = temp.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToArray());
        }
    }
}