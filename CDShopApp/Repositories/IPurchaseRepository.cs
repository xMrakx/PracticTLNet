using CDShopApp.Models;
namespace CDShopApp.Repositories;

public interface IPurchaseRepository
{
    IReadOnlyList<Purchase> GetAll();
    Purchase GetById(int id);
    IReadOnlyList<Purchase> GetByDate(string date);
    void Delete(Purchase purchase);
}