using challengeAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace challengeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunController : Controller
    {
        private readonly DataContext _dataContext;
        public UrunController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Urunler>>> GetAll()
        {
            return Ok(await _dataContext.Urunler.ToListAsync());
        }


        [HttpPost]
        public async Task<ActionResult<List<Urunler>>> CreateUrun(Urunler urun)
        {
            var firma = await _dataContext.Firmalar.FindAsync(urun.FirmaId);
            if (firma == null)
            {
                return BadRequest("Firma bulunamadi.");
            }
            _dataContext.Urunler.Add(urun);
            await _dataContext.SaveChangesAsync();

            return await _dataContext.Urunler.ToListAsync();
        }

        //[HttpPut]
        //public async Task<ActionResult<List<Urunler>>> UpdateUrun(Urunler urunInput)
        //{
        //    var urun = await _dataContext.Urunler.FindAsync(urunInput.Id);
        //    if (urun == null)
        //        return BadRequest("Urun bulunamadi.");

            //urun.FirmaId = urunInput.FirmaId;
            //urun.UrunAdi = urunInput.UrunAdi;
            //urun.Stok = urunInput.Stok;
            //urun.UrunFiyat = urunInput.UrunFiyat;
            

        //    await _dataContext.SaveChangesAsync();
        //    return Ok(await _dataContext.Urunler.ToListAsync());
        //}

        //[HttpDelete("id")]
        //public async Task<ActionResult<List<Urunler>>> DeleteUrun(int id)
        //{
        //    var urun = await _dataContext.Urunler.FindAsync(id);
        //    if (urun == null)
        //        return BadRequest("Urun bulunamadi.");
        //    _dataContext.Urunler.Remove(urun);
        //    await _dataContext.SaveChangesAsync();
        //    return Ok(await _dataContext.Urunler.ToListAsync());
        //}
    }
}
