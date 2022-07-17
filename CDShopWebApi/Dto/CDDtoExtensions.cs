using CDShopApp.Domain;
namespace CDShopApp.Dto;

public static class CDDtoExtensions
{
    public static CD ConvertToCD(this CDDto cDDto)
    {
        return new CD(
            cDDto.Id,
            cDDto.Name,
            cDDto.Artist,
            cDDto.ReleaseDate,
            cDDto.Price
            );
    }

    public static CDDto ConvertToCDDto(this CD cDDto)
    {
        return new CDDto
        { 
            Id = cDDto.Id,
            Name = cDDto.Name,
            Artist = cDDto.Artist,
            ReleaseDate = cDDto.ReleaseDate,
            Price = cDDto.Price
        };

    }


}