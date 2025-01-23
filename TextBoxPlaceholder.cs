using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calendar
{
    public static class TextBoxPlaceholder
    {
        public static void SetPlaceholder(System.Windows.Forms.TextBox textBox, string placeholderText)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text) || textBox.Text == placeholderText)
            {
                textBox.Text = placeholderText;
                textBox.ForeColor = Color.Gray;
            }
            else
            {
                textBox.ForeColor = SystemColors.WindowText;
            }

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

        public static void SetPlaceholder(System.Windows.Forms.RichTextBox richTextBox, string placeholderText)
        {
            if (string.IsNullOrWhiteSpace(richTextBox.Text) || richTextBox.Text == placeholderText)
            {
                richTextBox.Text = placeholderText;
                richTextBox.ForeColor = Color.Gray;
            }
            else
            {
                richTextBox.ForeColor = SystemColors.WindowText;
            }

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
