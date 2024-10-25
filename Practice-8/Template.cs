using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_8
{
    public abstract class ReportGenerator
    {
        public void GenerateReport()
        {
            PrepareData();
            GenerateHeader();
            GenerateContent();
            GenerateFooter();
            SaveReport();
        }

        protected abstract void PrepareData();
        protected abstract void GenerateHeader();
        protected abstract void GenerateContent();
        protected abstract void GenerateFooter();
        protected virtual void SaveReport()
        {
            Console.WriteLine("Отчет сохранен!");
        }
    }
    public class PdfReport : ReportGenerator
    {
        protected override void PrepareData()
        {
            Console.WriteLine("Подготовка данных для PDF-отчета...");
        }

        protected override void GenerateHeader()
        {
            Console.WriteLine("Генерация заголовка PDF-отчета...");
        }

        protected override void GenerateContent()
        {
            Console.WriteLine("Генерация содержимого PDF-отчета...");
        }

        protected override void GenerateFooter()
        {
            Console.WriteLine("Генерация подвала PDF-отчета...");
        }

        protected override void SaveReport()
        {
            Console.WriteLine("Сохранение PDF-отчета...");
        }
    }
    public class ExcelReport : ReportGenerator
    {
        protected override void PrepareData()
        {
            Console.WriteLine("Подготовка данных для Excel-отчета...");
        }

        protected override void GenerateHeader()
        {
            Console.WriteLine("Генерация заголовка Excel-отчета...");
        }

        protected override void GenerateContent()
        {
            Console.WriteLine("Генерация содержимого Excel-отчета...");
        }

        protected override void GenerateFooter()
        {
            Console.WriteLine("Генерация подвала Excel-отчета...");
        }

        protected override void SaveReport()
        {
            Console.WriteLine("Сохранение Excel-отчета...");
        }
    }
    public class HtmlReport : ReportGenerator
    {
        protected override void PrepareData()
        {
            Console.WriteLine("Подготовка данных для HTML-отчета...");
        }

        protected override void GenerateHeader()
        {
            Console.WriteLine("Генерация заголовка HTML-отчета...");
        }

        protected override void GenerateContent()
        {
            Console.WriteLine("Генерация содержимого HTML-отчета...");
        }

        protected override void GenerateFooter()
        {
            Console.WriteLine("Генерация подвала HTML-отчета...");
        }
    }
    public class CsvReport : ReportGenerator
    {
        protected override void PrepareData()
        {
            Console.WriteLine("Подготовка данных для CSV-отчета...");
        }

        protected override void GenerateHeader()
        {
            Console.WriteLine("Генерация заголовка CSV-отчета...");
        }

        protected override void GenerateContent()
        {
            Console.WriteLine("Генерация содержимого CSV-отчета...");
        }

        protected override void GenerateFooter()
        {
            Console.WriteLine("Генерация подвала CSV-отчета...");
        }

        protected override void SaveReport()
        {
            Console.WriteLine("Сохранение CSV-отчета...");
        }
    }
    public class EmailReport : ReportGenerator
    {
        protected override void PrepareData()
        {
            Console.WriteLine("Подготовка данных для Email-отчета...");
        }

        protected override void GenerateHeader()
        {
            Console.WriteLine("Генерация заголовка Email-отчета...");
        }

        protected override void GenerateContent()
        {
            Console.WriteLine("Генерация содержимого Email-отчета...");
        }

        protected override void GenerateFooter()
        {
            Console.WriteLine("Генерация подвала Email-отчета...");
        }

        protected override void SaveReport()
        {
            Console.WriteLine("Отправка Email-отчета...");
        }
    }
    internal class Template
    {
    }
}
