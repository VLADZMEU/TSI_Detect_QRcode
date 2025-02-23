using GroupDocs.Parser;
using GroupDocs.Parser.Data;
using System.Collections.Generic;

public class QRCodeService
{
    public IEnumerable<PageBarcodeArea> ReadQRCode(string? imagePath)
    {
        using (Parser parser = new Parser(imagePath))
        {
            return parser.GetBarcodes();
        }
    }
}