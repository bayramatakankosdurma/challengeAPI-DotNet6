using challengeAPI.Data;
using challengeAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace challengeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiparisController : Controller
    {

        private readonly DataContext _dataContext;
        public SiparisController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //[HttpPost]
        //public async Task CreateOrEdit(Siparis siparis)
        //{
        //    if (siparis.Id == 0)
        //    {
        //        await CreateSiparis(siparis);
        //    }
        //    else
        //    {
        //    }
        //}

        [HttpPost]
        public async Task<ActionResult<List<Siparis>>> CreateSiparis(Siparis siparis)
        {
            var firma = await _dataContext.Firmalar.FindAsync(siparis.FirmaId);
            if (firma == null) {
                return BadRequest("Firma bulunamadi.");
            }
            else
            {
                if (firma.OnayDurumu == false ) {
                    return BadRequest("Firma onayli degil.");
                }
                else if (!((DateTime.Compare(siparis.SiparisTarihi, firma.SiparisIzinBitisSaat) <0)  && (DateTime.Compare(firma.SiparisIzinBaslangic, siparis.SiparisTarihi) < 0)))
                {
                    return BadRequest("Firma siparis alma saatlerinde degil.");
                }
                _dataContext.Siparisler.Add(siparis);
                await _dataContext.SaveChangesAsync();

                return Ok(await _dataContext.Siparisler.ToListAsync());
            }          
        }
    }
}
