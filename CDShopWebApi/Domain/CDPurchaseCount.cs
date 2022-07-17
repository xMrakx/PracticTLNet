namespace CDShopApp.Domain;
public class CDPurchaseCount
{
    public string Name { get; private set; }
    public int Count { get; private set; }

    public CDPurchaseCount(string name, int count)
    {
        Name = name;
        Count = count;
    }
}
