using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Licensing;

namespace pdfcomplexscriptsample.Services
{
    /// <summary>
    /// Generates a sample PDF for the requested language using the
    /// Syncfusion .NET PDF Library with an embedded Unicode font.
    /// </summary>
    public class PdfGenerationService
    {
        private readonly ILogger<PdfGenerationService> _logger;
        private readonly IWebHostEnvironment _environment;

        public PdfGenerationService(ILogger<PdfGenerationService> logger,
            IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;

            // Register the Syncfusion community license. If you have a paid
            // license, replace SYNCFUSION_LICENSE_KEY with your key or an env var.
            string? licenseKey = Environment.GetEnvironmentVariable("SYNCFUSION_LICENSE_KEY");
            SyncfusionLicenseProvider.RegisterLicense(licenseKey ??
                "ENTER_YOUR_TRIAL_OR_COMMUNITY_LICENSE_KEY_HERE");
        }

        /// <summary>
        /// Builds the PDF for the given language and returns it as a byte array.
        /// </summary>
        public byte[] CreatePdf(LanguageInfo language)
        {
            using MemoryStream stream = new();

            using (PdfDocument document = new())
            {
                document.PageSettings.Size = PdfPageSize.A4;
                PdfPage page = document.Pages.Add();
                SizeF clientSize = page.GetClientSize();

                //Create a new PDF font instance
                PdfFont pdfFont = CreateFont(language, 12f);
                PdfFont titleFont = CreateFont(language, 22f, bold: true);

                //Graphics object used to draw the text
                PdfGraphics graphics = page.Graphics;

                //Set the format for string
                PdfStringFormat format = new PdfStringFormat();

                //Set the format as complex script layout type
                format.ComplexScript = true;

                //Set the format as plain (Latin) layout for header/footer text
                PdfStringFormat plainFormat = new PdfStringFormat();

                // --- Decorative header band -------------------------------------
                RectangleF headerRect = new(0, 0, clientSize.Width, 70f);
                graphics.DrawRectangle(new PdfLinearGradientBrush(
                    headerRect, new PdfColor(70, 79, 235), new PdfColor(28, 35, 128), 0f), headerRect);

                PdfFont latinTitleFont = new PdfStandardFont(PdfFontFamily.Helvetica, 18, PdfFontStyle.Bold);
                PdfFont latinSmallFont = new PdfStandardFont(PdfFontFamily.Helvetica, 9);
                graphics.DrawString(LanguageCatalog.ProjectName, latinTitleFont,
                    PdfBrushes.White, new RectangleF(10, 12, clientSize.Width - 20, 28),
                    plainFormat);
                graphics.DrawString(LanguageCatalog.ProjectVersion + "  |  Language: " + language.DisplayName,
                    latinSmallFont, PdfBrushes.White,
                    new RectangleF(10, 42, clientSize.Width - 20, 16), plainFormat);

                float y = 100f;

                //Draw the text (greeting) with complex script layout
                graphics.DrawString(language.Greeting, titleFont,
                    new PdfSolidBrush(new PdfColor(28, 35, 128)),
                    new RectangleF(0, y, clientSize.Width - 40, 60), format);
                y += 70f;

                // --- Thin divider line -------------------------------------------
                graphics.DrawRectangle(
                    new PdfSolidBrush(new PdfColor(70, 79, 235)),
                    new RectangleF(10, y, clientSize.Width - 20, 2f));
                y += 20f;

                // --- Paragraph ---------------------------------------------------
                RectangleF paragraphRect = new(10f, y, clientSize.Width - 20, 220);

                //Draw the text (paragraph) with complex script layout
                graphics.DrawString(language.Paragraph, pdfFont,
                    PdfBrushes.Black, paragraphRect, format);

                y += paragraphRect.Height + 30f;

                // --- Footer ------------------------------------------------------
                RectangleF footerRect = new(0, clientSize.Height - 30, clientSize.Width, 30f);
                graphics.DrawRectangle(new PdfSolidBrush(new PdfColor(245, 245, 245)), footerRect);
                graphics.DrawString(
                    "This PDF was generated automatically.  Page 1 of 1",
                    new PdfStandardFont(PdfFontFamily.Helvetica, 8),
                    new PdfSolidBrush(new PdfColor(120, 120, 120)),
                    new RectangleF(10, clientSize.Height - 22, clientSize.Width - 20, 14),
                    plainFormat);

                document.Save(stream);
            }

            return stream.ToArray();
        }

        /// <summary>
        /// Resolves the Unicode font bundled with the app in wwwroot/fonts for
        /// the requested language. Throws a clear error when the font file is
        /// missing so the problem is obvious instead of silently rendering
        /// unreadable text.
        /// </summary>
        private PdfFont CreateFont(LanguageInfo language, float size, bool bold = false)
        {
            PdfFontStyle style = bold ? PdfFontStyle.Bold : PdfFontStyle.Regular;

            string bundled = Path.Combine(_environment.WebRootPath ?? "wwwroot",
                "fonts", language.FontFile);

            if (!File.Exists(bundled))
            {
                _logger.LogError("Bundled font {Font} was not found in wwwroot/fonts.",
                    language.FontFile);
                throw new FileNotFoundException(
                    $"Font '{language.FontFile}' was not found in wwwroot/fonts. " +
                    "Please copy the font file into that folder.", bundled);
            }

            return new PdfTrueTypeFont(bundled, size, style);
        }
    }
}