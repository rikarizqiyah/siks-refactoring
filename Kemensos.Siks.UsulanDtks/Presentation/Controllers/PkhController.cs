using Kemensos.Siks.UsulanDtks.Application.Commands.PkhProses;
using Microsoft.AspNetCore.Mvc;
using Kemensos.Siks.UsulanDtks.Domain.Pkh;

namespace Kemensos.Siks.UsulanDtks.Presentation.Controllers;

[ApiController]
[Route("usulandtks/[controller]/[action]")]
public class PkhController : ControllerBase
{
  private readonly ILogger<PkhController> _logger;
  private readonly PkhProsesCommand _pkhProsesCommand;
  public PkhController(ILogger<PkhController> logger, PkhProsesCommand pkhProsesCommand)
  {
    _logger = logger;
    _pkhProsesCommand = pkhProsesCommand;
  }

  [HttpPost]
  public JsonResult Pkh([FromForm] PkhRequest appRequest)
  {
    var response = new AppResponseMessage();

    //var repo = new PkhRepository();
    //var command = new RegistrasiIndividuCommand(repo);

    try
    {
      var request = new PkhProsesRequest(
              appRequest.nama,
              appRequest.no_kk,
              appRequest.nik,
              appRequest.tanggal_lahir,
              appRequest.jenis_kelamin,
              appRequest.jalan,
              appRequest.kota,
              appRequest.provinsi,
              appRequest.kodepos,
              appRequest.pendapatan,
              appRequest.jumlah_tanggungan
          );

      var eligibility = _pkhProsesCommand.DetermineEligibility(request.Pendapatan, request.JumlahTanggungan);
      var amount = _pkhProsesCommand.CalculateAssistanceAmount("Kategori1", eligibility);
      var result = _pkhProsesCommand.Handle(request);

      var responseData = new PkhResponse
      {
        id = result.Id.Id.ToString(),
        nama = result.Nama,
        no_kk = result.Nik.GetValue(),
        nik = result.Nik.GetValue(),
        tanggal_lahir = result.TanggalLahir.ToString(),
        jenis_kelamin = result.JenisKelamin.ToString(),
        jalan = result.Alamat.Jalan,
        kota = result.Alamat.Kota,
        provinsi = result.Alamat.Provinsi,
        kodepos = result.Alamat.KodePos,
        aktif = result.Aktif,
        status_kelayakan = eligibility,
        nominal_bantuan = amount
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

public class PkhRequest
{
  public string nama { get; set; }
  public string no_kk { get; set; }
  public string nik { get; set; }
  public string tanggal_lahir { get; set; }
  public string jenis_kelamin { get; set; }
  public string jalan { get; set; }
  public string kota { get; set; }
  public string provinsi { get; set; }
  public string kodepos { get; set; }
  public decimal pendapatan { get; set; }
  public int jumlah_tanggungan { get; set; }
}

public class PkhResponse
{
  public string id { get; set; }
  public string nama { get; set; }
  public string no_kk { get; set; }
  public string nik { get; set; }
  public string tanggal_lahir { get; set; }
  public string jenis_kelamin { get; set; }
  public string jalan { get; set; }
  public string kota { get; set; }
  public string provinsi { get; set; }
  public string kodepos { get; set; }
  public bool aktif { get; set; }
  public bool status_kelayakan { get; set;}
  public decimal nominal_bantuan { get; set;}
}