using System.Xml;
using System;
using System.IO;

namespace laba2
{
    public class DOMAnalyzer : IXmlAnalyzer
    {
        public string Analyze(string keyword)
        {
            var result = new System.Text.StringBuilder();
            XmlDocument doc = new XmlDocument();
            doc.Load("data.xml");

            XmlNodeList nodes = doc.GetElementsByTagName("professor");

            foreach (XmlNode node in nodes)
            {
                bool matchFound = false;
                string professorInfo = "";

                // Перевірка атрибутів професора
                foreach (XmlAttribute attribute in node.Attributes)
                {
                    if (attribute.Value.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    {
                        matchFound = true;
                    }
                    professorInfo += $"{attribute.Name}: {attribute.Value}\n";
                }

                // Перевірка дочірніх елементів, таких як <faculty>, <department>, <education>
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if (childNode.HasAttributes)
                    {
                        foreach (XmlAttribute attr in childNode.Attributes)
                        {
                            if (attr.Value.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                            {
                                matchFound = true;
                            }
                            professorInfo += $"{childNode.Name} {attr.Name}: {attr.Value}\n";
                        }
                    }
                }

                if (matchFound)
                {
                    result.AppendLine(professorInfo);
                    result.AppendLine("---------");
                }
            }

            return result.Length > 0 ? result.ToString() : "No matching records found.";
        }
    }



}
