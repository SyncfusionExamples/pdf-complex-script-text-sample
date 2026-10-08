using System.ComponentModel.DataAnnotations;

namespace pdfcomplexscriptsample.Models
{
    /// <summary>
    /// View model bound to the language selection form.
    /// </summary>
    public class PdfGenerationModel
    {
        /// <summary>
        /// The language code selected by the user (e.g. "hi", "ta", "te").
        /// </summary>
        [Required(ErrorMessage = "Please select a language.")]
        public string SelectedLanguage { get; set; } = "hi";
    }
}