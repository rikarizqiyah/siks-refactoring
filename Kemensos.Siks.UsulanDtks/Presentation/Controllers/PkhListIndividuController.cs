using Microsoft.AspNetCore.Mvc;
using Kemensos.Siks.UsulanDtks.Application.Commands.PkhListIndividu;

namespace Kemensos.Siks.UsulanDtks.Presentation.Controllers;

[ApiController]
[Route("usulandtks/[controller]/[action]")]
public class PkhListIndividuController : ControllerBase
{
  private readonly ILogger<PkhListIndividuController> _logger;
  private readonly PkhListIndividuCommand _pkhListIndividuCommand;

  public PkhListIndividuController(ILogger<PkhListIndividuController> logger, PkhListIndividuCommand pkhListIndividuCommand)
  {
    _logger = logger;
    _pkhListIndividuCommand = pkhListIndividuCommand;
  }

  [HttpGet]
  public JsonResult ListIndividu()
  {
    var response = new AppResponseMessage();

    try
    {
      var persons = _pkhListIndividuCommand.GetAllPersons();

      response.data = persons;
    }
    catch (Exception e)
    {
      response.Fail();
      response.message = e.Message;
    }

    return new JsonResult(response);
  }
}

public class PkhListIndividuResponse
{
  public string id { get; set; }
  public string no_kk { get; set; }
  public string nik { get; set; }
  public string name { get; set; }
  public string age { get; set; }
  public string status { get; set; }
  public string kategori { get; set; }
}