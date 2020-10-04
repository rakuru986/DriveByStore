using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Common
{
    public abstract class BaseEntity
    {
        public static string Unspecified => "Unspecified";
        public static DateTime UnspecifiedValidFrom => DateTime.MinValue;
        public static DateTime UnspecifiedValidTo => DateTime.MaxValue;
        public static double UnspecifiedDouble => double.NaN;
    }
}
