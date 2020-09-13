using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text;
using System.Drawing;
using System.Data;

namespace CertificadosSESAB
{
    public class Documento
    {
        public static byte[] Gerar(string nome, string arquivo, int x, int y)
        {
            PdfReader reader = new PdfReader(arquivo);
            iTextSharp.text.Rectangle size = reader.GetPageSizeWithRotation(1);
            using (MemoryStream outStream = new MemoryStream())
            {
                Document document = new Document(size);
                PdfWriter writer = PdfWriter.GetInstance(document, outStream);
                document.Open();
                try
                {
                    PdfContentByte cb = writer.DirectContent;

                    PdfImportedPage page = writer.GetImportedPage(reader, 1);
                    cb.AddTemplate(page, 0, 0);

                    cb.BeginText();
                    try
                    {
                        cb.SetFontAndSize(BaseFont.CreateFont(), 18);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, nome, x, y, 0);
                    }
                    finally
                    {
                        cb.EndText();
                    }

                }
                finally
                {
                    document.Close();
                    writer.Close();
                    reader.Close();
                }
                return outStream.ToArray();
            }
        }
    }
}