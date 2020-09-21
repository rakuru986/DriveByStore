using System;

namespace Core
{
    public class Products
    {
        public static CoreProductData Club = new CoreProductData
        (
            Guid.NewGuid().ToString(), "Auto", 23000, "jpg", 12, "Sõiduvahend", "Olemas", "Väga heas korras"
        );

        //public static List<CoreProductData> Product =>
        //    new List<CoreProductData>()
        //    {
        //        new CoreProductData( "1.0","Auto", 23000, "jpg", 12, "Sõiduvahend", "Olemas", "Väga hea auto")
        //    };
    }
}