using System.Windows.Forms;

try
{
    Console.WriteLine("Application is starting...");
    Console.ReadKey();
    throw new IOException("Cannot find a log file.");
}
catch (Exception ex)
{
    MessageBox.Show(ex.Message);
}
finally
{
    Console.WriteLine("Application is exiting...");
}
