namespace Kemensos.Siks.UsulanDtks.Domain.Pkh;

public class NoKk
{
  private const int PANJANG_KK = 16;

  private string _value;

  public NoKk(string value)
  {
    if (value.Length != PANJANG_KK)
    {
      throw new Exception("Panjang KK tidak valid");
    }

    _value = value;
  }

  public string GetValue()
  {
    return _value;
  }

  public bool IsValid()
  {
    return true;
  }

  public override string ToString()
  {
    return _value;
  }
}