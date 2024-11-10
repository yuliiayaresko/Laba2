
using System;
using Microsoft.Maui.Controls;
using System.Xml.Linq;
using System.Xml;
using System.Linq;

namespace laba2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnAnalyzeButtonClicked(object sender, EventArgs e)
        {
            string keyword = KeywordEntry.Text;
            string strategy = StrategyPicker.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(keyword) || string.IsNullOrEmpty(strategy))
            {
                ResultLabel.Text = "Please enter a keyword and select a strategy.";
                return;
            }

            IXmlAnalyzer analyzer = strategy switch
            {
                "SAX" => new SAXAnalyzer(),
                "DOM" => new DOMAnalyzer(),
                "LINQ to XML" => new LinqToXmlAnalyzer(),
                _ => throw new NotSupportedException("Unknown strategy")
            };

            // Показуємо повідомлення про обробку
            ResultLabel.Text = "Analyzing...";

            try
            {
                // Виконуємо аналіз у фоновому потоці
                string result = await Task.Run(() => analyzer.Analyze(keyword));

                // Відображаємо результат після завершення аналізу
                ResultLabel.Text = result;
            }
            catch (Exception ex)
            {
                // Обробка помилки, якщо щось пішло не так
                ResultLabel.Text = $"Error: {ex.Message}";
            }
        }



        private void OnClearButtonClicked(object sender, EventArgs e)
        {
            KeywordEntry.Text = string.Empty;
            ResultLabel.Text = "Results will appear here";
        }
    }

    public interface IParsingStrategy
    {
        string Parse(string keyword);
    }

    public class SaxParsingStrategy : IParsingStrategy
    {
        public string Parse(string keyword)
        {
            // Implement SAX parsing logic
            return "SAX Parsing Result for keyword: " + keyword;
        }
    }

    public class DomParsingStrategy : IParsingStrategy
    {
        public string Parse(string keyword)
        {
            // Implement DOM parsing logic
            return "DOM Parsing Result for keyword: " + keyword;
        }
    }

    public class LinqToXmlParsingStrategy : IParsingStrategy
    {
        public string Parse(string keyword)
        {
            // Implement LINQ to XML parsing logic
            return "LINQ to XML Parsing Result for keyword: " + keyword;
        }
    }
}


