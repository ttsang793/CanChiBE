namespace server.Models;

public class Data
{
    public string Chi { get; set; }

    public string DongVat { get; set; }

    public Data(string chi, string dongVat)
    {
        Chi = chi;
        DongVat = dongVat;
    }
}
