namespace CDShopApp.Models;

public class Worker
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Birthday { get; private set; }
    public string PhoneNumber { get; private set; }

    public Worker(int id, string name, string surname, string birthDay, string phoneNumber)
    {
        Id = id;
        Name = name;  
        Surname = surname;
        Birthday = birthDay;
        PhoneNumber = phoneNumber;
    }

    public void UpdateAll(string name, string surname, string phoneNumber)
    {
        Name = name;
        Surname = surname;
        PhoneNumber = phoneNumber;
    }
}