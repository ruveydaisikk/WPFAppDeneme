using ClosedXML.Excel;
using System;

namespace WPFAppDeneme
{
    internal class XLWorkbook : IDisposable
    {
        private string logFilePath;

        public XLWorkbook()
        {
        }

        public XLWorkbook(string logFilePath)
        {
            this.logFilePath = logFilePath;
        }

        public object Worksheets { get; internal set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        internal void SaveAs(string filePath)
        {
            throw new NotImplementedException();
        }

        internal IXLWorksheet Worksheet(int v)
        {
            throw new NotImplementedException();
        }

        internal object Worksheet(string v)
        {
            throw new NotImplementedException();
        }
    }
}