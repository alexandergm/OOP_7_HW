using System.Text;

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
Console.InputEncoding = Encoding.GetEncoding(1251);
Console.OutputEncoding = Encoding.GetEncoding(1251);
Homework7.App app = new Homework7.App();
app.Work();