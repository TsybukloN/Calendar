using System.Drawing;
using System.Windows.Forms;

public static class RichTextBoxPlaceholder
{
    public static void SetPlaceholder(RichTextBox richTextBox, string placeholderText)
    {
        richTextBox.Text = placeholderText;
        richTextBox.ForeColor = Color.Gray;

        richTextBox.Enter += (sender, e) =>
        {
            if (richTextBox.Text == placeholderText && richTextBox.ForeColor == Color.Gray)
            {
                richTextBox.Text = "";
                richTextBox.ForeColor = SystemColors.WindowText; // Стандартный цвет текста
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
