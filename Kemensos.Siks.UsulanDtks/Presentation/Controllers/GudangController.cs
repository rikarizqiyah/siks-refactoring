using Kemensos.Siks.UsulanDtks.Application.Commands.TambahkanGudang;
using Kemensos.Siks.UsulanDtks.Infrastructure.Persistence.InMemory;
using Microsoft.AspNetCore.Mvc;

namespace Kemensos.Siks.UsulanDtks.Presentation.Controllers;

[ApiController]
[Route("usulandtks/[controller]/[action]")]
public class GudangController : ControllerBase
{
  private readonly ILogger<GudangController> _logger;

  public GudangController(ILogger<GudangController> logger)
  {
    _logger = logger;
  }

  [HttpPost]
  public JsonResult Add([FromForm] AddRequest appRequest)
  {

    var response = new AppResponseMessage();

    var repo = new GudangRepository();
    var command = new TambahkanGudangCommand(repo);

    try
    {
      var request = new TambahkanGudangRequest(
              appRequest.nama
          );

      var result = command.Handle(request);

      var responseData = new AddResponse
      {
        id = result.Id.Id.ToString(),
        nama = result.Nama
      };


      response.data = responseData;
    }
    catch (Exception e)
    {
      response.Fail();
      response.message = e.Message;
    }

    return new JsonResult(response);
  }
}

public class AddRequest
{
  public string nama { get; set; }
}

public class AddResponse
{
  public string id { get; set; }
  public string nama { get; set; }
}