using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace OpenStreetMap.Infrastructure
{
    /// <summary>
    /// Extension metoda pro získání stringu z typu double s tečkou v oddělovači desetinných míst.
    /// </summary>
    /// 

    public static class DoubleExtensions
    {
        public static string ToStringWithADot(this double value)
        {
            return value.ToString(CultureInfo.GetCultureInfo("en-GB"));
        }
    }
}