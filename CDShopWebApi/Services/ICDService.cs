using CDShopApp.Domain;
using CDShopApp.Dto;

namespace CDShopApp.Services;

public interface ICDService
{
    List<CD> GetAll();
    CD GetByID(int id);
    CD GetByName(string name);
    List<CDPurchaseCount> GetPurchaseCount();
    int Add(CDDto cd);
    void Update(CDDto cd);
    void Delete(int id);
}

