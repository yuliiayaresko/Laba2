namespace laba2
{
    public class XmlProcessor
    {
        private IXmlAnalyzer _analyzer;

        public XmlProcessor(IXmlAnalyzer analyzer)
        {
            _analyzer = analyzer;
        }

        public void SetAnalyzer(IXmlAnalyzer analyzer)
        {
            _analyzer = analyzer;
        }

        public void AnalyzeXml(string keyword)
        {
            _analyzer.Analyze(keyword);
        }

        public void ConvertXmlToHtml(string xmlPath, string xslPath, string outputHtmlPath)
        {
            var xslt = new System.Xml.Xsl.XslCompiledTransform();
            xslt.Load(xslPath);
            xslt.Transform(xmlPath, outputHtmlPath);
        }
    }
}
