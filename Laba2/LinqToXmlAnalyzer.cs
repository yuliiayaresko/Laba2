using System.Linq;
using System.Xml.Linq;

namespace laba2
{
    public class LinqToXmlAnalyzer : IXmlAnalyzer
    {
        public string Analyze(string keyword)
        {
            var result = new System.Text.StringBuilder();
            XDocument doc = XDocument.Load("C:\\Users\\yulia\\source\\repos\\Laba2\\Laba2\\data.xml");

            var professors = doc.Descendants("professor")
                .Where(e => e.Attributes().Any(attr => attr.Value.Contains(keyword, StringComparison.OrdinalIgnoreCase)) ||
                            e.Elements().Any(child => child.Attributes().Any(attr => attr.Value.Contains(keyword, StringComparison.OrdinalIgnoreCase))));

            foreach (var professor in professors)
            {
                foreach (var attribute in professor.Attributes())
                {
                    result.AppendLine($"{attribute.Name}: {attribute.Value}");
                }

                foreach (var element in professor.Elements())
                {
                    foreach (var attribute in element.Attributes())
                    {
                        result.AppendLine($"{attribute.Name}: {attribute.Value}");
                    }
                }

                result.AppendLine("---------");
            }

            return result.Length > 0 ? result.ToString() : "No matching records found.";
        }
    }


}
