using Microsoft.AspNetCore.Mvc;
using placaappapi.Models;
using placaappapi.Repository;

namespace placaappapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlacaController
    {
        IPlacaServices placaServices;
        public PlacaController(IPlacaServices placaServices)
        {
            this.placaServices = placaServices;
        }
        [HttpPost("GetPlacaDetail")]
        public async Task<List<Placa>> ConsultPlacaDetail(Placa placa)
        {
            return  await placaServices.ConsultPlacaDetail(placa);
        }

        [HttpGet("getHorasCita")]
        public async Task<List<CitaHora>> getHorasCita()
        {
            return await placaServices.getHorasCita();
        }

        [HttpPost("BookNewPlacaDate")]
        public async Task<List<EscalarValue>> BookNewPlacaDate(Placa placa)
        {
            return await placaServices.BookNewPlacaDate(placa);
        }


        
    }
}
