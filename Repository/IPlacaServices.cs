using placaappapi.Models;

namespace placaappapi.Repository
{
    public interface IPlacaServices
    {
        public Task<List<Placa>> ConsultPlacaDetail (Placa placa);  
        public Task<List<EscalarValue>> BookNewPlacaDate (Placa placa);
        public Task<List<CitaHora>> getHorasCita ();
    }
}
