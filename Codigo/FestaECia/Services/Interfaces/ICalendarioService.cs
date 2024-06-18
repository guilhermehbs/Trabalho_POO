namespace FestaECia.Services.Interfaces
{
    public interface ICalendarioService
    {
        DateTime MarcarData();
        DateTime MarcarData(DateTime dataAtual);
        bool DataNaoEValida(DateTime date);
        DateTime UltimaDataMarcada();
    }
}