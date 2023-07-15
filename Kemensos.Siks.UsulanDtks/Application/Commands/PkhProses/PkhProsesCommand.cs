using Kemensos.Siks.UsulanDtks.Domain.Individu;
using Kemensos.Siks.UsulanDtks.Domain.Pkh;

namespace Kemensos.Siks.UsulanDtks.Application.Commands.PkhProses;

public class PkhProsesCommand
{
  private IPkhRepository _pkhRepository;

  public PkhProsesCommand(IPkhRepository pkhRepository)
  {
    _pkhRepository = pkhRepository;
  }

  public bool IsValidCategory(string category)
  {
    // Lakukan validasi kategori dengan data statis di domain atau sumber lainnya
    return _pkhRepository.IsValidCategory(category);
  }

  public bool DetermineEligibility(decimal income, int dependents)
  {
    // Lakukan penentuan kelayakan berdasarkan aturan bisnis yang diterapkan
    // Misalnya, sesuai dengan batasan pendapatan dan jumlah tanggungan tertentu
    // Anda dapat menambahkan logika bisnis yang lebih kompleks di sini
    return income < 1000 && dependents <= 3;
  }

  public decimal CalculateAssistanceAmount(string category, bool eligibility)
  {
    // Lakukan perhitungan nominal uang bantuan berdasarkan kategori dan kelayakan
    // Anda dapat menambahkan logika bisnis yang lebih kompleks di sini
    return eligibility ? _pkhRepository.GetAssistanceAmount(category) : 0;
  }

  public Pkh Handle(PkhProsesRequest request)
  {
    //TODO: authorization check
    //TODO: request parameter validation

    var noKk = new NoKk(request.NoKk);
    var nik = new Nik(request.Nik);

    //check individu apakah terdaftar di DTKS
    var individu = _pkhRepository.DtksGetByNik(nik);

    if (individu == null)
    {
      throw new Exception("NIK tidak terdaftar di DTKS.");
    }

    DateTime tanggalLahir;

    var tanggalLahirValid = DateTime.TryParseExact(request.TanggalLahir, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out tanggalLahir);

    if (!tanggalLahirValid)
    {
      throw new Exception("Format tanggal lahir tidak valid");
    }

    //buat objek individu

    var alamat = new Alamat(
            request.Jalan,
            request.Kota,
            request.Provinsi,
            request.KodePos
        );

    var jenisKelamin = new JenisKelamin(request.JenisKelamin);

    var pkhBaru = Pkh.Proses(
            noKk,
            nik,
            request.Nama,
            new TanggalLahir(tanggalLahir),
            jenisKelamin,
            alamat
        );

    //simpan pkh baru
    _pkhRepository.Save(pkhBaru);

    return pkhBaru;
  }
}