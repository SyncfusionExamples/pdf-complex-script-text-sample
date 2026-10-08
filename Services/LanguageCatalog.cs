namespace pdfcomplexscriptsample.Services
{
    /// <summary>
    /// Describes a language supported by the PDF generator.
    /// </summary>
    public class LanguageInfo
    {
        /// <summary>Stable code used as the form value.</summary>
        public string Code { get; }

        /// <summary>Display name shown in the dropdown.</summary>
        public string DisplayName { get; }

        /// <summary>Bundled Unicode TTF font in wwwroot/fonts used to render
        /// this language's text.</summary>
        public string FontFile { get; }

        /// <summary>A short greeting rendered as the PDF heading.</summary>
        public string Greeting { get; }

        /// <summary>A short paragraph rendered in the PDF.</summary>
        public string Paragraph { get; }

        public LanguageInfo(string code, string displayName, string fontFile,
            string greeting, string paragraph)
        {
            Code = code;
            DisplayName = displayName;
            FontFile = fontFile;
            Greeting = greeting;
            Paragraph = paragraph;
        }
    }

    /// <summary>
    /// Catalog of the six supported Indian languages with friendly,
    /// user-facing paragraphs that will be rendered into the generated PDF.
    /// All fonts live in wwwroot/fonts.
    /// </summary>
    public static class LanguageCatalog
    {
        /// <summary>
        /// Name of the project printed in the PDF header. Change this
        /// to match your brand.
        /// </summary>
        public const string ProjectName = "Multilingual Document Creator";
        public const string ProjectVersion = "Powered by Syncfusion .NET PDF Library";

        public static readonly IReadOnlyList<LanguageInfo> Languages = new List<LanguageInfo>
        {
            new("hi", "Hindi - हिन्दी", "NotoSansDevanagari-Regular.ttf",
                "नमस्ते दुनिया!",
                "बहुभाषी दस्तावेज़ निर्माता में आपका स्वागत है। यह नमूना दस्तावेज़ सिद्ध करता है कि आपका वेब अनुप्रयोग " +
                "किसी भी समय सही ढंग से बनी यूनिकोड PDF फ़ाइल तैयार कर सकता है। ऊपर दिया गया शीर्षक और यह " +
                "अनुच्छेद Syncfusion .NET PDF Library द्वारा एम्बेड किए गए यूनिकोड फ़ॉन्ट का उपयोग करके बनाया " +
                "गया है। चाहें तो इस नमूना वाक्य की जगह चालान, पत्र, पाठ्यक्रम या सरकारी अधिसूचना जैसी व्यावसायिक " +
                "सामग्री डालकर आप अपना अनुप्रयोग और विस्तारित कर सकते हैं।"),

            new("sa", "Sanskrit - संस्कृतम्", "NotoSansDevanagari-Regular.ttf",
                "नमस्ते जगत्!",
                "बहुभाषिकलेख्यनिर्मातृमध्ये भवदीयं स्वागतम्। एतत् नमूनालेख्यं प्रमाणयति यत् भवतः जालप्रयोगः कदाचित् " +
                "अपि सम्यक् रूपेण निर्मितं यूनिकोड PDF सञ्चिकां रचयितुं शक्नोति। उपरिस्थितं शीर्षकम् एतत् अनुच्छेदं " +
                "च Syncfusion .NET PDF Library इत्यनेन एम्बेडकृतस्य यूनिकोड अक्षरसमूहस्य उपयोगेन आलेखितम्। " +
                "इच्छा एषा नमूनावाक्यस्य स्थाने युवकपत्रिका, पत्रम्, पाठ्यक्रमः अथवा शासकीयसूचना इत्यादिविषयं " +
                "स्थापयित्वा स्वस्य प्रयोगं विस्तारयितुं शक्नुवन्ति।"),

            new("ta", "Tamil - தமிழ்", "NotoSansTamil-Regular.ttf",
                "வணக்கம் உலகம்!",
                "பன்மொழி ஆவணப் படைப்பானுக்கு உங்களை வரவேற்கிறோம். இந்த மாதிரி ஆவணம், உங்கள் இணையப் " +
                "பயன்பாடு எந்த நேரத்திலும் சரியாக உருவாக்கப்பட்ட யுனிகோடு PDF கோப்பை உருவாக்க முடியும் " +
                "என்பதை நிரூபிக்கிறது. மேலுள்ள தலைப்பும் இந்த பத்தியும் Syncfusion .NET PDF Library " +
                "உட்பொருந்தச் செய்த யுனிகோடு எழுத்துருவைப் பயன்படுத்தி வரையப்பட்டன. விலைப்பட்டியல், " +
                "கடிதம், பாடநெறி அல்லது அரசுறுதி போன்ற வணிகத் தகவலை இந்த மாதிரி வாக்கியத்திற்குப் " +
                "பதிலாக இட்டு உங்கள் பயன்பாட்டை விரிவாக்கலாம்."),

            new("te", "Telugu - తెలుగు", "NotoSansTelugu-Regular.ttf",
                "నమస్కారం, ప్రపంచము!",
                "బహుభాషా పత్ర సృష్టికర్తకు స్వాగతం. ఈ నమూనా పత్రం, మీ వెబ్ అనువర్తనం ఏ సమయంలోనైనా సరిగ్గా " +
                "నిర్మించబడిన యూనికోడ్ PDF ఫైలును సృష్టించగలదని రుజువు చేస్తుంది. పై శీర్షిక మరియు ఈ " +
                "పేరా Syncfusion .NET PDF Library చే ఎంబెడ్ చేయబడిన యూనికోడ్ ఫాంటును ఉపయోగించి " +
                "చిత్రించబడింది. కోరుకుంటే ఈ నమూనా వాక్యం స్థానంలో బిల్లు, లేఖ, పాఠ్యక్రమము లేదా ప్రభుత్వ " +
                "ప్రకటన వంటి వ్యాపార సమాచారమును ఇచ్చి మీ అనువర్తనాన్ని విస్తరించవచ్చు."),

            new("kn", "Kannada - ಕನ್ನಡ", "NotoSansKannada-Regular.ttf",
                "ನಮಸ್ಕಾರ, ಜಗತ್ತೇ!",
                "ಬಹುಭಾಷಾ ದಸ್ತಾವೇಜು ಸೃಷ್ಟಿಕಾರಕ್ಕೆ ಸ್ವಾಗತ. ಈ ಮಾದರಿ ದಸ್ತಾವೇಜು ನಿಮ್ಮ ವೆಬ್ ಅಪ್ಲಿಕೇಶನ್ ಯಾವುದೇ " +
                "ಸಮಯದಲ್ಲಿ ಸರಿಯಾಗಿ ರೂಪುಗೊಂಡ ಯೂನಿಕೋಡ್ PDF ಫೈಲನ್ನು ರಚಿಸಬಲ್ಲದು ಎಂಬುದನ್ನು ಸಾಬೀತುಪಡಿಸುತ್ತದೆ. ಮೇಲಿನ " +
                "ಶೀರ್ಷಿಕೆ ಮತ್ತು ಈ ಪ್ಯಾರಾಗ್ರಾಫ್ ಅನ್ನು Syncfusion .NET PDF Library ಎಂಬೆಡ್ ಮಾಡಿದ ಯೂನಿಕೋಡ್ ಫಾಂಟ್ " +
                "ಬಳಸಿ ಬಿಡಿಸಲಾಗಿದೆ. ರವಾನೆ ಪತ್ರ, ಪತ್ರವ್ಯವಹಾರ, ಪಠ್ಯ ಅಥವಾ ಸರ್ಕಾರದ ಪ್ರಕಟಣೆಯಂತಹ ವ್ಯಾಪಾರಿ ವಿಷಯವನ್ನು " +
                "ಈ ಮಾದರಿ ವಾಕ್ಯದ ಬದಲು ನೀಡಿ ನಿಮ್ಮ ಅಪ್ಲಿಕೇಶನ್ ಅನ್ನು ವಿಸ್ತರಿಸಲು ಸಾಧ್ಯವಿದೆ."),
            new("ml", "Malayalam - മലയാളം", "NotoSansMalayalam-Regular.ttf",
                "ഹലോ ലോകം!",
                "ബഹുഭാഷാ രേഖ സൃഷ്ടിക്കാരനിലേക്ക് സ്വാഗതം. ഈ മാതൃക രേഖ നിങ്ങളുടെ വെബ് ആപ്ലിക്കേഷന് " +
                "ഏത് സമയത്തും ശരിയായി രൂപപ്പെടുത്തിയ യൂണിക്കോഡ് PDF ഫയൽ സൃഷ്ടിക്കാൻ കഴിയുമെന്ന് " +
                "തെളിയിക്കുന്നു. മുകളിലെ തലക്കെട്ടും ഇതേ ഖണ്ഡികയും Syncfusion .NET PDF Library എംബഡ് " +
                "ചെയ്ത യൂണിക്കോഡ് ഫോണ്ട് ഉപയോഗിച്ചാണ് വരച്ചിരിക്കുന്നത്. ചെലവ് പട്ടിക, കത്ത്, പാഠപുസ്തകം " +
                "അല്ലെങ്കിൽ സർക്കാർ അറിയിപ്പ് പോലുള്ള ബിസിനസ് ഉള്ളടക്കം ഈ മാതൃക വാചകത്തിന് പകരം ഉപയോഗിച്ച് " +
                "നിങ്ങൾക്ക് ആപ്ലിക്കേഷൻ വിപുലീകരിക്കാം."),
        };

        /// <summary>Look up a language by its code; defaults to Hindi.</summary>
        public static LanguageInfo Resolve(string? code) =>
            Languages.FirstOrDefault(l => l.Code == code) ?? Languages[0];
    }
}