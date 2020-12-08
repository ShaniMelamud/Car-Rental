using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental
{
    public static class ErrorHelper
    {
        public static List<string> ExtractErrors(ModelStateDictionary modelState)
        {
            List<string> errors = new List<string>();
            foreach (KeyValuePair<string, ModelStateEntry> entry in modelState)
            {
                foreach (ModelError err in entry.Value.Errors)
                {
                    errors.Add(err.ErrorMessage);
                }
            }
            return errors;
        }
    }
}
