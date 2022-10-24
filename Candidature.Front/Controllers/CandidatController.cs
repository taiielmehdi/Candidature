using Candidature.Business.Interfaces;
using Candidature.Module.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Candidature.Front.Controllers
{
    public class CandidatController : Controller
    {
        private ICandidat _candidat;
        private IRef _ref;
        public CandidatController(ICandidat candidat, IRef @ref)
        {
            _candidat = candidat;
            _ref = @ref;
        }


        [HttpGet]
        public async Task<IActionResult> Index(string Keyword)
        {
            var result = await _candidat.Get(Keyword);
            return View(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var RefNiveauEtude = await _ref.RefNiveauEtude();

            ViewBag.RefNiveauEtude = new SelectList(RefNiveauEtude.Data, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CandidatModule model)
        {
            var result = await _candidat.Add(model);
            if (result.Success)
                return RedirectToAction("Index");

            return View();
        }

        public async Task<IActionResult> Delete(CandidatModule model)
        {
            var result = await _candidat.Delete(model);
            return Ok(result);
        }

    }
}
