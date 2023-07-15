using Kemensos.Siks.UsulanDtks.Domain.Individu;
namespace Kemensos.Siks.UsulanDtks.Domain.Pkh;

public class Pkh
{
  private const bool STATUS_AKTIF_DEFAULT = true;

  public PkhId Id { get; }
  public NoKk NoKk { get; }
  public Nik Nik { get; }
  public string Nama { get; }
  public TanggalLahir TanggalLahir { get; }
  public JenisKelamin JenisKelamin { get; }
  public Alamat Alamat { get; }
  public bool Aktif { get; private set; }

  public Pkh (
      PkhId id,
      NoKk noKk,
      Nik nik,
      string nama,
      TanggalLahir tanggalLahir,
      JenisKelamin jenisKelamin,
      Alamat alamat,
      bool aktif)
  {
    //TODO: validate input parameter
    if (string.IsNullOrEmpty(nama))
    {
      throw new Exception("Nama tidak boleh kosong");
    }

    this.Id = id;
    this.NoKk = noKk;
    this.Nik = nik;
    this.Nama = nama;
    this.TanggalLahir = tanggalLahir;
    this.JenisKelamin = jenisKelamin;
    this.Alamat = alamat;
    this.Aktif = aktif;
  }

  //factory method
  public static Pkh Proses (
      NoKk noKk,
      Nik nik,
      string nama,
      TanggalLahir tanggalLahir,
      JenisKelamin jenisKelamin,
      Alamat alamat)
  {
    var id = new PkhId(Guid.NewGuid());

    return new Pkh (
            id,
            noKk,
            nik,
            nama,
            tanggalLahir,
            jenisKelamin,
            alamat,
            STATUS_AKTIF_DEFAULT
        );
  }
}