namespace CDShopApp.Models;

public class Purchase
{
    public int Id { get; private set; }
    public int IdCD { get; private set; }
    public int IdWorker { get; private set; }
    public string Date { get; private set; }

    public Purchase(int id, int idCD, int idWorker, string date)
    {
        Id = id;
        IdCD = idCD;
        IdWorker = idWorker;
        Date = date;
    }
}