using System;
namespace Kemensos.Siks.UsulanDtks.Domain.Individu;

public class Nik
{
    private const int PANJANG_NIK = 16;

    private string _value;

    public Nik(string value)
    {
        if (value.Length != PANJANG_NIK) {
            throw new Exception("Panjang NIK tidak valid");
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

