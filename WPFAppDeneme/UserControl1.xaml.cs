using System.Windows.Controls;

namespace WPFAppDeneme
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        // TextBlock'un metnini değiştiren bir metot
        public void SetTextBlockText(string text)
        {
            MyTextBlock.Text = text;
        }
    }
}
