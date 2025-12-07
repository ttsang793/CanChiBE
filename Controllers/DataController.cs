namespace server.Controllers;

using Microsoft.AspNetCore.Mvc;
using server.Models;

[ApiController]
[Route("api/[controller]")]
public class DataController : ControllerBase
{
    private readonly ILogger<DataController> _logger;

    private readonly List<Data> ConGiap = new List<Data>()
    {
        new Data("Tí", "Chuột"), new Data("Sửu", "Trâu"), new Data("Dần", "Hổ"),
        new Data("Mão", "Mèo"), new Data("Thìn", "Rồng"), new Data("Tỵ", "Rắn"),
        new Data("Ngọ", "Ngựa"), new Data("Mùi", "Dê"), new Data("Thân", "Khỉ"),
        new Data("Dậu", "Gà"), new Data("Tuất", "Chó"), new Data("Hợi", "Heo")
    };

    public DataController(ILogger<DataController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public List<Data> GetDatas()
    {
        return ConGiap;
    }
}
