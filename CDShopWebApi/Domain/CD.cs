namespace CDShopApp.Domain;

public class CD
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Artist { get; private set; }
    public string ReleaseDate { get; private set; }
    public int Price { get; private set; }

    public CD(int id, string name, string artist, string releaseDate, int price)
    {
        Id = id;
        Name = name;
        Artist = artist;
        ReleaseDate = releaseDate;
        Price = price;
    }

    public void UpdatePrice(int price)
    {
        Price = price;
    }
}
