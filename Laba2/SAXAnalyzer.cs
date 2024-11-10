using System.Xml;

namespace laba2
{
    public class SAXAnalyzer : IXmlAnalyzer
    {
        public string Analyze(string keyword)
        {
            var result = new System.Text.StringBuilder();

            using (XmlReader reader = XmlReader.Create("data.xml"))
            {
                bool matchFound = false;
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "professor")
                    {
                        string professorInfo = "";

                        // Читання атрибутів елемента <professor>
                        while (reader.MoveToNextAttribute())
                        {
                            if (reader.Value.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                            {
                                matchFound = true;
                            }
                            professorInfo += $"{reader.Name}: {reader.Value}\n";
                        }

                        // Читання дочірніх елементів (факультет, департамент, освіта)
                        reader.MoveToElement(); // Повертаємося до елемента <professor>
                        if (reader.ReadToDescendant("education"))
                        {
                            do
                            {
                                if (reader.HasAttributes)
                                {
                                    for (int i = 0; i < reader.AttributeCount; i++)
                                    {
                                        reader.MoveToAttribute(i);
                                        if (reader.Value.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                                        {
                                            matchFound = true;
                                        }
                                        professorInfo += $"{reader.Name}: {reader.Value}\n";
                                    }
                                }
                            } while (reader.ReadToNextSibling("education"));
                        }

                        if (matchFound)
                        {
                            result.AppendLine(professorInfo);
                            result.AppendLine("---------");
                        }
                    }
                }
            }
            return result.Length > 0 ? result.ToString() : "No matching records found.";
        }
    }



}

