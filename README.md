# Generate Multi-Language Indic PDF Documents in ASP.NET Core Using Syncfusion® .NET PDF Library

A lightweight ASP.NET Core sample that demonstrates how to generate PDF documents in multiple Indic languages using the **Syncfusion .NET PDF Library**. The application lets users pick a language from a dropdown, click **Generate PDF**, and instantly download a sample document with a greeting and a full paragraph rendered correctly using an embedded Unicode TrueType font and complex-script shaping.

## Pages

| Page | Route | Description |
| --- | --- | --- |
| **PDF Generator** | `/` (PDF/Index) | Select a language, click **Generate PDF**, and the sample PDF downloads automatically. |

## Supported languages

| Language | Sample heading | Bundled font (`wwwroot/fonts`) |
| --- | --- | --- |
| Hindi | नमस्ते दुनिया! | `NotoSansDevanagari-Regular.ttf` |
| Sanskrit | नमस्ते जगत्! | `NotoSansDevanagari-Regular.ttf` |
| Tamil | வணக்கம் உலகம்! | `NotoSansTamil-Regular.ttf` |
| Telugu | నమస్కారం ప్రపంచము! | `NotoSansTelugu-Regular.ttf` |
| Kannada | ನಮಸ್ಕಾರ ಜಗತ್ತೇ! | `NotoSansKannada-Regular.ttf` |
| Malayalam | ഹലോ ലോകം! | `NotoSansMalayalam-Regular.ttf` |

## Features

* Language dropdown with six Indic languages
* One-click **Generate PDF** button — the PDF downloads automatically
* Unicode TrueType (`.ttf`) fonts bundled in `wwwroot/fonts` and embedded into the PDF
* Complex-script shaping enabled via `PdfStringFormat.ComplexScript = true`
* Text rendered with `graphics.DrawString()` on an A4 page
* Styled PDF: gradient header band, divider, paragraph block, and footer
* Friendly one-paragraph sample text for every supported language

## Key code

```csharp
//Create a new PDF font instance (Unicode TTF bundled in wwwroot/fonts)
PdfFont pdfFont = CreateFont(language, 12f);

//Set the format for string
PdfStringFormat format = new PdfStringFormat();

//Set the format as complex script layout type
format.ComplexScript = true;

//Draw the text
graphics.DrawString(language.Paragraph, pdfFont, PdfBrushes.Black,
    paragraphRect, format);
```

## Project structure

```
pdfcomplexscriptsample
├── Controllers
│   ├── HomeController.cs
│   └── PdfController.cs
├── Models
│   ├── PdfGenerationModel.cs
│   └── ErrorViewModel.cs
├── Services
│   ├── PdfGenerationService.cs
│   └── LanguageCatalog.cs
├── Views
│   ├── Pdf
│   │   └── Index.cshtml
│   └── Shared
│       ├── _Layout.cshtml
│       └── Error.cshtml
├── wwwroot
│   ├── css
│   │   └── site.css
│   └── fonts
│       ├── NotoSansDevanagari-Regular.ttf
│       ├── NotoSansKannada-Regular.ttf
│       ├── NotoSansMalayalam-Regular.ttf
│       ├── NotoSansTamil-Regular.ttf
│       └── NotoSansTelugu-Regular.ttf
├── Properties
│   └── launchSettings.json
├── Program.cs
├── appsettings.json
└── pdfcomplexscriptsample.csproj
```

## Run

```powershell
cd pdfcomplexscriptsample
dotnet restore
dotnet run
```

Then open <https://localhost:7223> (or <http://localhost:5207>).

## Syncfusion license

Set your Syncfusion license key via:

* Environment variable `SYNCFUSION_LICENSE_KEY`, **or**
* The `SyncfusionLicenseProvider.RegisterLicense(...)` call in `Services/PdfGenerationService.cs`.

A free community license is available at
<https://www.syncfusion.com/products/communitylicense>.

## Fonts

The app ships **Noto Sans** Unicode fonts for Devanagari, Tamil, Telugu,
Kannada, and Malayalam in `wwwroot/fonts`. To render additional languages,
drop the matching *Noto Sans `<Script>`-Regular.ttf* into that folder and add
a new entry to the `LanguageCatalog` class in `Services/LanguageCatalog.cs`.
Fonts are provided under the SIL Open Font License — see
<https://fonts.google.com/noto> for details.
