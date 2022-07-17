using CDShopApp.Domain;
namespace CDShopApp.Repositories;

public interface ICDRepository
{
    List<CD> GetAll();
    CD GetByName(string name);
    CD GetById(int id);
    List<CD> GetByArtist(string artist);
    List<CD> GetByReleaseDate(string releaseDate);
    List<CD> GetByPrice(int price);
    List<CDPurchaseCount> GetPurchaseCount();
    int Add(CD cD);
    void Update(CD cD);
    void Delete(CD cD);
}