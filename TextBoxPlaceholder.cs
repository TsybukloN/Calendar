using System.Drawing;
using System.Windows.Forms;
namespace Calendar
{
    public static class TextBoxPlaceholder
    {
        public static void SetPlaceholder(TextBox textBox, string placeholderText)
        {
            textBox.Text = placeholderText;
            textBox.ForeColor = Color.Gray;

            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholderText && textBox.ForeColor == Color.Gray)
                {
                    textBox.Text = "";
                    textBox.ForeColor = SystemColors.WindowText;
                }
            };

            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholderText;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        public static void SetPlaceholder(RichTextBox richTextBox, string placeholderText)
        {
            richTextBox.Text = placeholderText;
            richTextBox.ForeColor = Color.Gray;

            richTextBox.Enter += (sender, e) =>
            {
                if (richTextBox.Text == placeholderText && richTextBox.ForeColor == Color.Gray)
                {
                    richTextBox.Text = "";
                    richTextBox.ForeColor = SystemColors.WindowText;
                }
            };

            richTextBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(richTextBox.Text))
                {
                    richTextBox.Text = placeholderText;
                    richTextBox.ForeColor = Color.Gray;
                }
            };
        }
    }
}
