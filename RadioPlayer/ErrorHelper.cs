using System;

namespace RadioPlayer;

public class ErrorHelper
{
    public static void ShowError(string message)
    {
        MessageBox.Show($"{message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}