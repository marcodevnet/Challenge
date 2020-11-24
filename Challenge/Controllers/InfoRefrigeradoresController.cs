using Challenge.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Challenge.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/InfoRefrigeradores")]
    [ApiController]
    public class InfoRefrigeradoresController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<RefrigeradoresEntity>>> Get()
        {
            var listUsers = await GetListRefrigeradores();

            if (listUsers.Count < 0)
                return NotFound();

            return listUsers;
        }

        //Data Base

        private async Task<List<RefrigeradoresEntity>> GetListRefrigeradores()
        {
            var listDatosRefrigeradores = new List<RefrigeradoresEntity>()
            {
                new RefrigeradoresEntity() {Id = 1, Temperatura = "5", ConsumoInterno = "250", EspacioInterno = "500", EstadoLuces = "Bueno"  },
                new RefrigeradoresEntity() {Id = 2, Temperatura = "10", ConsumoInterno = "125", EspacioInterno = "250", EstadoLuces = "Bueno"  },
                new RefrigeradoresEntity() {Id = 3, Temperatura = "8", ConsumoInterno = "219", EspacioInterno = "190", EstadoLuces = "Regular"  },
                new RefrigeradoresEntity() {Id = 4, Temperatura = "1", ConsumoInterno = "350", EspacioInterno = "560", EstadoLuces = "Bueno"  },
                new RefrigeradoresEntity() {Id = 5, Temperatura = "3", ConsumoInterno = "154", EspacioInterno = "610", EstadoLuces = "Malo"  },
                new RefrigeradoresEntity() {Id = 6, Temperatura = "5", ConsumoInterno = "29", EspacioInterno = "154", EstadoLuces = "Bueno"  },
                new RefrigeradoresEntity() {Id = 7, Temperatura = "4", ConsumoInterno = "297", EspacioInterno = "310", EstadoLuces = "Regular"  },
                new RefrigeradoresEntity() {Id = 8, Temperatura = "10", ConsumoInterno = "316", EspacioInterno = "209", EstadoLuces = "Bueno"  },
            };
            return listDatosRefrigeradores;
        }

        [HttpPost]
        public async Task<List<RefrigeradoresEntity>> Post(RefrigeradoresEntity refrigeradoresEntity)
        {
            var listDatosRefrigeradores = await GetListRefrigeradores();

            listDatosRefrigeradores.Add(new RefrigeradoresEntity()
            {
                Id = listDatosRefrigeradores.Count + 1,
                Temperatura = refrigeradoresEntity.Temperatura,
                ConsumoInterno = refrigeradoresEntity.ConsumoInterno,
                EspacioInterno = refrigeradoresEntity.EspacioInterno,
                EstadoLuces = refrigeradoresEntity.EstadoLuces
            });
            return listDatosRefrigeradores;
        }

        [HttpPut]
        public async Task<ActionResult<List<RefrigeradoresEntity>>> Put(RefrigeradoresEntity refrigeradoresEntity)
        {
            var listDatosRefrigeradores = await GetListRefrigeradores();

            var DatosRefrigeradoresUpdate = listDatosRefrigeradores.Find(u => u.Id == refrigeradoresEntity.Id);

            if (DatosRefrigeradoresUpdate == null)
                return NotFound();

            listDatosRefrigeradores.First(u => u.Id == DatosRefrigeradoresUpdate.Id).Temperatura = refrigeradoresEntity.Temperatura;
            listDatosRefrigeradores.First(u => u.Id == DatosRefrigeradoresUpdate.Id).ConsumoInterno = refrigeradoresEntity.ConsumoInterno;
            listDatosRefrigeradores.First(u => u.Id == DatosRefrigeradoresUpdate.Id).EspacioInterno = refrigeradoresEntity.EspacioInterno;
            listDatosRefrigeradores.First(u => u.Id == DatosRefrigeradoresUpdate.Id).EstadoLuces = refrigeradoresEntity.EstadoLuces;

            return listDatosRefrigeradores;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<RefrigeradoresEntity>>> Delete(int id)
        {
            var listDatosRefrigeradores = await GetListRefrigeradores();

            var DatosRefrigeradoresDelete = listDatosRefrigeradores.Find(u => u.Id == id);

            if (DatosRefrigeradoresDelete == null)
                return NotFound();

            listDatosRefrigeradores.Remove(DatosRefrigeradoresDelete);

            return listDatosRefrigeradores;
        }
    }
}
