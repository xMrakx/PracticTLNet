using CDShopApp.Models;
namespace CDShopApp.Repositories;

public interface IWorkerRepository
{
    IReadOnlyList<Worker> GetAll();
    Worker GetById(int id);
    IReadOnlyList<Worker> GetByName(string name);
    IReadOnlyList<Worker> GetBySurname(string surname);
    IReadOnlyList<Worker> GetByBirthday(string birthday);
    Worker GetByPhoneNumber(string number);

    public void Update(Worker worker);
    public void Delete(Worker worker);
}