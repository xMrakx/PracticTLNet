using CDShopApp.Domain;
namespace CDShopApp.Dto;

public static class CDPurchaseCountExtensions
{
    public static CDPurchaseCount ConvertToCDPC(this CDPurchaseCountDTo cDPCDto)
    {
        return new CDPurchaseCount(
            cDPCDto.Name,
            cDPCDto.Count
            );
    }

    public static CDPurchaseCountDTo ConvertToCDPCDto(this CDPurchaseCount cDPCDto)
    {
        return new CDPurchaseCountDTo
        {
            Name = cDPCDto.Name,
            Count = cDPCDto.Count
        };
    }

}