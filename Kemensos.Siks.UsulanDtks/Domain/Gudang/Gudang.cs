namespace Kemensos.Siks.UsulanDtks.Domain.Gudang;

public class Gudang
{
  private const bool STATUS_HIDUP_DEFAULT = true;
  private const bool STATUS_AKTIF_DEFAULT = true;

  public GudangId Id { get; }
  public string Nama { get; }

  public Gudang(
      GudangId id,
      string nama
    )
  {
    //TODO: validate input parameter
    if (string.IsNullOrEmpty(nama))
    {
      throw new Exception("Nama tidak boleh kosong");
    }

    this.Id = id;
    this.Nama = nama;
  }

  //factory method
  public static Gudang Add(
      string nama
    )
  {
    var id = new GudangId(Guid.NewGuid());

    return new Gudang(
            id,
            nama
        );
  }

}