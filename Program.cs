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

    IEnumerable<PageBarcodeArea> barcodes = parser.GetBarcodes();

    foreach (PageBarcodeArea barcode in barcodes)
    {

        Console.WriteLine(barcode.CodeTypeName + " Code Value: " + barcode.Value);
    }
}    