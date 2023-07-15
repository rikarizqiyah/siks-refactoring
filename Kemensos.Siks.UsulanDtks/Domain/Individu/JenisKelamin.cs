using System;
namespace Kemensos.Siks.UsulanDtks.Domain.Individu;

public class JenisKelamin
{
    private const string LAKI_LAKI = "L";
    private const string PEREMPUAN = "P";

    private const string LAKI_LAKI_LABEL = "Laki-laki";
    private const string PEREMPUAN_LABEL = "Perempuan";

    private string _value;

    public JenisKelamin(string value)
    {
        _value = value;
    }

    public override string ToString()
    {
        if (_value.Equals(LAKI_LAKI))
        {
            return LAKI_LAKI_LABEL;
        }
        else if (_value.Equals(PEREMPUAN))
        {
            return PEREMPUAN_LABEL;
        }

        throw new Exception("Invalid value");
    }
}

