using Microsoft.eShopWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Controllers
{
    [Route("")]
    public class CatalogController : Controller
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService) => _catalogService = catalogService;

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Index(string keywords, int? brandFilterApplied, int? typesFilterApplied, int? page)
        {
            var telemetry = new Microsoft.ApplicationInsights.TelemetryClient();
            telemetry.TrackTrace("Microsoft.eShopWeb.Controllers CatalogController Index");

            var itemsPage = 9;
            var catalogModel = await _catalogService.SearchCatalogItems(keywords, brandFilterApplied, typesFilterApplied, page ?? 0, itemsPage);
            return View(catalogModel);
        }
    }
}
