using challengeAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace challengeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public FirmaController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Firma>>> GetAll()
        {
            return Ok(await _dataContext.Firmalar.ToListAsync());
        }
        [HttpGet("GetById")]
        public async Task<ActionResult<Firma>> Get(int id)
        {
            var firma = await _dataContext.Firmalar.FindAsync(id);
            if (firma == null)
                return BadRequest("Firma bulunamadi.");
            return Ok(firma);
        }

        [HttpPost]
        public async Task<ActionResult<List<Firma>>> CreateFirma(Firma firma)
        {
            _dataContext.Firmalar.Add(firma);
            await _dataContext.SaveChangesAsync();

            return await _dataContext.Firmalar.ToListAsync();
        }

        [HttpPut]
        public async Task<ActionResult<List<Firma>>> UpdateFirma(Firma firmaInput)
        {
            var firma = await _dataContext.Firmalar.FindAsync(firmaInput.Id);
            if (firma == null)
                return BadRequest("Firma bulunamadi.");
            
            firma.FirmaAdi = firmaInput.FirmaAdi;
            firma.OnayDurumu = firmaInput.OnayDurumu;
            firma.SiparisIzinBitisSaat = firmaInput.SiparisIzinBitisSaat;
            firma.SiparisIzinBaslangic = firmaInput.SiparisIzinBaslangic;

            await _dataContext.SaveChangesAsync();
            return await _dataContext.Firmalar.ToListAsync();
        }

        [HttpDelete("id")]
        public async Task<ActionResult<List<Firma>>> DeleteFirma(int id)
        {
            var firma = await _dataContext.Firmalar.FindAsync(id);
            if (firma == null)
                return BadRequest("Firma bulunamadi.");
            _dataContext.Firmalar.Remove(firma);
            await _dataContext.SaveChangesAsync();  
            return Ok(await _dataContext.Firmalar.ToListAsync());
        }
    }
}
