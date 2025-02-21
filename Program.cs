using GroupDocs.Parser;
using GroupDocs.Parser.Data;

Console.WriteLine("Введите путь к изображению с QR-кодом (PNG, JPEG, BMP):");
string imagePath = Console.ReadLine();

if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
{
    Console.WriteLine("Файл не найден или путь не указан.");
    return;
}

using (Parser parser = new Parser(imagePath))
{
    // Извлеките все QR-коды.
    IEnumerable<PageBarcodeArea> barcodes = parser.GetBarcodes();

    // Итерация
    foreach (PageBarcodeArea barcode in barcodes)
    {
        // Распечатайте значения идентифицированного QR-кода
        Console.WriteLine(barcode.CodeTypeName + " Code Value: " + barcode.Value);
    }
}    