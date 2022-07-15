using CDShopApp.Models;
namespace CDShopApp.Repositories;

public interface ICDRepository
{
    IReadOnlyList<CD> GetAll();
    CD GetByName(string name);
    CD GetById(int id);
    IReadOnlyList<CD> GetByArtist(string artist);
    IReadOnlyList<CD> GetByReleaseDate(string releaseDate);
    IReadOnlyList<CD> GetByPrice(int price);
    void Update(CD cD);
    void Delete(CD cD);
}