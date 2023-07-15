using Kemensos.Siks.UsulanDtks.Application.Commands.AktifkanIndividu;
using Kemensos.Siks.UsulanDtks.Application.Commands.RegistrasiIndividu;
using Kemensos.Siks.UsulanDtks.Infrastructure.Persistence.InMemory;
using Microsoft.AspNetCore.Mvc;

namespace Kemensos.Siks.UsulanDtks.Presentation.Controllers;

[ApiController]
[Route("usulandtks/[controller]/[action]")]
public class IndividuController : ControllerBase
{
    private readonly ILogger<IndividuController> _logger;

    public IndividuController(ILogger<IndividuController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public JsonResult Aktifkan([FromForm] string id)
    {
        var response = new AppResponseMessage();

        if (string.IsNullOrEmpty(id))
        {
            response.Fail();
            return new JsonResult(response);
        }

        var repo = new IndividuRepository();
        var command = new AktifkanIndividuCommand(repo);

        try
        {
            var individuId = Guid.Parse(id);
            var request = new AktifkanIndividuRequest(individuId);

            command.Handle(request);

            response.Success();
        }
        catch (Exception e)
        {
            response.Fail();
            response.message = e.ToString();
        }

        return new JsonResult(response);
    }

    [HttpPost]
    public JsonResult Register([FromForm] RegisterRequest appRequest) {

        var response = new AppResponseMessage();

        var repo = new IndividuRepository();
        var command = new RegistrasiIndividuCommand(repo);

        try
        {
            var request = new RegistrasiIndividuRequest(
                    appRequest.nama,
                    appRequest.nik,
                    appRequest.tanggal_lahir,
                    appRequest.jenis_kelamin,
                    appRequest.jalan,
                    appRequest.kota,
                    appRequest.provinsi,
                    appRequest.kodepos
                );

            var result = command.Handle(request);
          
            var responseData = new RegisterResponse {
                 id=result.Id.Id.ToString(),
                 nama=result.Nama,
                 nik=result.Nik.GetValue(),
                 tanggal_lahir=result.TanggalLahir.ToString(),
                 jenis_kelamin=result.JenisKelamin.ToString(),
                 jalan=result.Alamat.Jalan,
                 kota=result.Alamat.Kota,
                 provinsi=result.Alamat.Provinsi,
                 kodepos=result.Alamat.KodePos,
                 aktif=result.Aktif,
                 status_hidup=result.StatusHidup.Value
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

public class RegisterRequest
{
    public string nama { get; set; }
    public string nik { get; set; }
    public string tanggal_lahir { get; set; }
    public string jenis_kelamin { get; set; }
    public string jalan { get; set; }
    public string kota { get; set; }
    public string provinsi { get; set; }
    public string kodepos { get; set; }
}

public class RegisterResponse
{
    public string id { get; set; }
    public string nama { get; set; }
    public string nik { get; set; }
    public string tanggal_lahir { get; set; }
    public string jenis_kelamin { get; set; }
    public string jalan { get; set; }
    public string kota { get; set; }
    public string provinsi { get; set; }
    public string kodepos { get; set; }
    public bool aktif { get; set; }
    public bool status_hidup { get; set; }
}

public class AppResponseMessage
{
    public bool status { set; get; }
    public string remark { set; get; }
    public object data { set; get; }
    public object error { set; get; }
    public int? page { set; get; }
    public int total_page { set; get; }
    public int total_data { set; get; }
    public string message { get; set; }

    /// <summary>
    /// Set success response
    /// </summary>
    public void Success()
    {
        status = true;
        remark = "success";
    }

    /// <summary>
    /// Set failed response
    /// </summary>
    public void Fail()
    {
        status = false;
        remark = "failed";
    }
}

