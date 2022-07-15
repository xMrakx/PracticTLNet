using CDShopApp.Models;
namespace CDShopApp.Repositories;

public interface ICDPurchaseCountRequest
{
    IReadOnlyList<CDPurchaseCount> GetAll();
}