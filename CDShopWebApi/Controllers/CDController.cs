using Microsoft.AspNetCore.Mvc;
using CDShopApp.Dto;
using CDShopApp.Services;
namespace CDShopApp.Controllers;

[ApiController]
[Route("rest/{controller}")]
public class CDController : ControllerBase
{
    private readonly ICDService _cdService;

    public CDController(ICDService cdService)
    {
        _cdService = cdService;
    }

    [HttpGet]
    public IActionResult GetCDs()
    {
        try
        {
            return Ok(_cdService.GetAll()
                .ConvertAll(t => t.ConvertToCDDto()));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("get/id/{cdId}")]
    public IActionResult GetCD(int cdId)
    {
        try
        {
            return Ok(_cdService.GetByID(cdId).ConvertToCDDto());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("get/name/{cdName}")]
    public IActionResult GetCDByName(string cdName)
    {
        try
        {
            return Ok(_cdService.GetByName(cdName).ConvertToCDDto());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("purchaseCount")]
    public IActionResult GetPurchaseCount()
    {
        try
        {
            return Ok(_cdService.GetPurchaseCount()
                .ConvertAll(t => t.ConvertToCDPCDto()));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("add")]
    public IActionResult AddCD([FromBody] CDDto cD)
    {
        try
        {
            return Ok(_cdService.Add(cD));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("cdId")]
    public IActionResult UpdateCD([FromBody] CDDto cD)
    {
        try
        {
            _cdService.Update(cD);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("{cdId}/delete")]
    public IActionResult DeleteCD(int cdId)
    {
        try 
        {
            _cdService.Delete(cdId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}