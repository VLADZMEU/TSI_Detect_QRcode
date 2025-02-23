# TPS_QR_Reader
This project includes a console application for recognizing QR codes in images using the GroupDocs.Parser library.

## Download
1) Clone the repository:

```
git clone https://github.com/ваш-username/QRCodeReader.git
cd QRCodeReader
```
2) Install dependencies:

Ensure the GroupDocs.Parser library is installed via NuGet:
```bash
dotnet add package GroupDocs.Parser
```
## Usage
1) Run the application:
```bash
dotnet run
```
2) Enter the path to the image with the QR code (e.g., `C:\images\qrcode.png`).

3) The application will output the type of the QR code and its value to the console.

Example Output:
```
QR Code Value: https://example.com
```
## Code Example
```bash
using GroupDocs.Parser;
using GroupDocs.Parser.Data;

Console.WriteLine("Enter the path to the image with the QR code (PNG, JPEG, BMP):");
string imagePath = Console.ReadLine();

if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
{
    Console.WriteLine("File not found or path not specified.");
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
```
# The new version adds English and Russian languages
