using CDShopApp.Domain;
using CDShopApp.Dto;
using CDShopApp.Repositories;

namespace CDShopApp.Services;

public class CDService : ICDService
{
    private readonly ICDRepository _cdRepository;

    public CDService(ICDRepository cdRepository)
    {
        _cdRepository = cdRepository;
    }

    public List<CD> GetAll()
    {
        return _cdRepository.GetAll();  
    }

    public CD GetByID(int id)
    {
        CD cD = _cdRepository.GetById(id);
        if (cD == null)
        {
            throw new Exception($"{nameof(CD)} not found, #Id - {id}");
        }
        return cD;
    }

    public CD GetByName(string name)
    {
        CD cD = _cdRepository.GetByName(name);
        if (cD == null)
        {
            throw new Exception($"{nameof(CD)} not found, #Name - {name}");
        }
        return cD;
    }

    public List<CDPurchaseCount> GetPurchaseCount()
    {
        List<CDPurchaseCount> count = _cdRepository.GetPurchaseCount();
        if (count.Count == 0)
        {
            throw new Exception($"{nameof(CDPurchaseCount)} not found");
        }
        return count;
    }

    public int Add(CDDto cd)
    {
        if (cd == null)
        {
            throw new Exception($"{nameof(CD)} not found");
        }

        CD cDEntity = cd.ConvertToCD();

        return _cdRepository.Add(cDEntity);
    }
        
    public void Update(CDDto cd)
    {

        if (cd == null)
        {
            throw new Exception($"{nameof(CD)} not found, #Id - {cd.Id}");
        }
        CD cDEntity = cd.ConvertToCD();
        _cdRepository.Update(cDEntity);

    }

    public void Delete(int id)
    {
        CD cD = _cdRepository.GetById(id);
        if (cD == null)
        {
            throw new Exception($"{nameof(CD)} not found, #Id - {id}");
        }
        _cdRepository.Delete(cD);
    }
}