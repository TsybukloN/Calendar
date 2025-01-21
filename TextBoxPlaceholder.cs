using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public static class TextBoxPlaceholder
{
    private const int EM_SETCUEBANNER = 0x1501;

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
    private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, string lParam);

    public static void SetPlaceholder(TextBox textBox, string placeholderText)
    {
        SendMessage(textBox.Handle, EM_SETCUEBANNER, (IntPtr)1, placeholderText);
    }
}
