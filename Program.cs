using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Threading;
using GroupDocs.Parser;
using GroupDocs.Parser.Data;

class Program
{
    private static ResourceManager resourceManager;
    private static string currentLanguage = "en"; // Язык по умолчанию

    static void Main(string[] args)
    {
        // Инициализация ресурсов
        resourceManager = new ResourceManager("QrCodeDetect_1.Resources.Resources", typeof(Program).Assembly);

        // Выбор языка
        Console.WriteLine("1. English");
        Console.WriteLine("2. Русский");
        string languageChoice = Console.ReadLine();
        if (languageChoice == "2")
        {
            currentLanguage = "ru";
            ChangeLanguage("ru");
        }
        else
        {
            currentLanguage = "en";
            ChangeLanguage("en");
        }

        // Основной цикл программы
        while (true)
        {
            Console.WriteLine(resourceManager.GetString("EnterImagePath", CultureInfo.CurrentCulture));
            string imagePath = Console.ReadLine();
            if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
            {
                Console.WriteLine(resourceManager.GetString("FileNotFound", CultureInfo.CurrentCulture));
                continue;
            }

            // Распознавание QR-кода
            using (Parser parser = new Parser(imagePath))
            {
                IEnumerable<PageBarcodeArea> barcodes = parser.GetBarcodes();
                if (barcodes.Any())
                {
                    foreach (var barcode in barcodes)
                    {
                        Console.WriteLine($"{barcode.CodeTypeName}: {barcode.Value}");
                    }
                }
                else
                {
                    Console.WriteLine(resourceManager.GetString("QRCodeNotFound", CultureInfo.CurrentCulture));
                }
            }

            Console.WriteLine(resourceManager.GetString("TryAgain", CultureInfo.CurrentCulture));
            string tryAgain = Console.ReadLine();
            if (tryAgain?.ToLower() != "y")
                break;
        }
    }

    private static void ChangeLanguage(string languageTag)
    {
        CultureInfo culture = new CultureInfo(languageTag);
        Thread.CurrentThread.CurrentCulture = culture;
        Thread.CurrentThread.CurrentUICulture = culture;
    }
}