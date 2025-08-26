using System.Collections.Generic;
using KSP.Localization;
using UnityEngine;


namespace Caviation
{
    public static class StringUtils
    {
        static readonly Dictionary<string, string> localizedStrings = new Dictionary<string, string>(); // Cache localized strings so that they don't need to be repeatedly localized.

        public static string Localize(string template)
        {
            if (!localizedStrings.TryGetValue(template, out string result))
            {
                result = Localizer.Format(template);
                localizedStrings[template] = result;
            }
            return result;
        }
    }
}
