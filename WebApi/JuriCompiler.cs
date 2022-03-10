namespace WebApi
{
    public class JuriCompiler
    {
        public string Inhalt { get; set; } = String.Empty;
    }

    public class JuriOutput
    {
        public string Standard { get; set; }
        public string Error { get; set; }

        public string Meta { get; set; }

    }
}
