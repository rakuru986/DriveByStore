namespace Util
{
    public static class Constants
    {
        public static string Unspecified => "Unspecified";
        public static string ADD => "ADD";
        public static string REDUCE => "REDUCE";
        public static string OrderConfirmationEmailProductHtml => @"<tr><td width=""75%"" align=""left"" style=""font-family: Open Sans, Helvetica, Arial, sans-serif; font-size: 16px; font-weight: 400; line-height: 24px; padding: 5px 10px;"">[product-name] x [product-quantity] </td>
            <td width = ""25%"" align=""left"" style=""font-family: Open Sans, Helvetica, Arial, sans-serif; font-size: 16px; font-weight: 400; line-height: 24px; padding: 5px 10px;""> [product-price]€ </td></tr>";

        public static string OrderConfirmationEmailSubject => "Uus tellimus ülilahedalt DriveByStore lehelt";

    }
}
