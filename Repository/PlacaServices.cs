using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using placaappapi.Models;
using System.Numerics;

namespace placaappapi.Repository
{
    public class PlacaServices : IPlacaServices
    {

        private readonly DbContextClass _dbContext;
        private readonly
        IConfiguration _configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .Build();
        public PlacaServices(DbContextClass dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;

        }
        public async Task<List<EscalarValue>> BookNewPlacaDate(Placa placa)
        {
            try
            {
                var opcion = _configuration.GetSection("Options:CREATE").Value;
                var row = await Task.Run(() => _dbContext.escalarValues.FromSqlInterpolated($" exec SP_PLACA @Accion={opcion},@num_placa={placa.num_placa},@fecha_reserva={placa.fecha_reserva},@hora_reserva={placa.hora_reserva} ").ToListAsync());
                return row;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Placa>> ConsultPlacaDetail(Placa placa)
        {
            try
            {
                var opcion = _configuration.GetSection("Options:CONSULT").Value;
                var row = await Task.Run(() => _dbContext.placas.FromSqlInterpolated($" exec SP_PLACA @Accion={opcion},@num_placa={placa.num_placa} ").ToListAsync());
                return row;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CitaHora>> getHorasCita()
        {
            try
            {
                var row = await Task.Run(() => _dbContext.citaHoras.FromSqlInterpolated($" exec SP_LISTA_HORA ").ToListAsync());
                return row;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
