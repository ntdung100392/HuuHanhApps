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
        [Description("Nhập Kho/Tồn Kho")]
        InStock = 0,
        [Description("Hết Hàng")]
        OutOfStock = 1,
        [Description("Hết Hạn Bảo Hành")]
        Expired = 2,
        [Description("Ký Gửi")]
        ForTrade = 3,
        [Description("Dự Trữ Bảo Hành")]
        InReserved = 4
    }
}
