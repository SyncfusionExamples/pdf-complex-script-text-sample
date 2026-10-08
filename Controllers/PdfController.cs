using pdfcomplexscriptsample.Models;
using pdfcomplexscriptsample.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace pdfcomplexscriptsample.Controllers
{
    /// <summary>
    /// Serves the language-selection page and streams the generated PDF.
    /// </summary>
    public class PdfController : Controller
    {
        private readonly PdfGenerationService _pdfService;
        private readonly ILogger<PdfController> _logger;

        public PdfController(PdfGenerationService pdfService, ILogger<PdfController> logger)
        {
            _pdfService = pdfService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Languages = LanguageCatalog.Languages;
            return View(new PdfGenerationModel { SelectedLanguage = "hi" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(PdfGenerationModel model)
        {
            ViewBag.Languages = LanguageCatalog.Languages;

            if (!ModelState.IsValid)
                return View(model);

            LanguageInfo language = LanguageCatalog.Resolve(model.SelectedLanguage);

            try
            {
                byte[] pdfBytes = _pdfService.CreatePdf(language);

                // File name such as "Tamil-Sample-20261008-143022.pdf"
                string fileName = $"{language.DisplayName.Split('-')[0].Trim()}-Sample-" +
                                  $"{DateTime.Now:yyyyMMdd-HHmmss}.pdf";

                _logger.LogInformation("Generated PDF for {Language} ({Bytes} bytes).",
                    language.Code, pdfBytes.Length);

                //Content-Disposition: attachment  -> browser downloads it automatically.
                return File(pdfBytes, "application/pdf", fileName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PDF generation failed for {Language}.", language.Code);
                ModelState.AddModelError(string.Empty,
                    "There was a problem generating the PDF. Please try again.");
                return View(model);
            }
        }
    }
}