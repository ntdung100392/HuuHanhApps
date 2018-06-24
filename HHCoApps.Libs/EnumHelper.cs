using System.ComponentModel;

namespace HHCoApps.Libs
{
    public enum Sex
    {
        [Description("Nam")]
        Nam = 0,
        [Description("Nữ")]
        Nữ = 1
    }

    public enum ProductStatus
    {
        [Description("Còn Hàng")]
        InStock = 0,
        [Description("Hết Hàng")]
        OutOfStock = 1,
        [Description("Trả Hàng")]
        Returned = 2,
        [Description("Bảo Hành")]
        InReserved = 3
    }
}
