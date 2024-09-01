using System;

namespace WPFAppDeneme
{
    internal class XLWorkbook : IDisposable
    {
        public object Worksheets { get; internal set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        internal void SaveAs(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}