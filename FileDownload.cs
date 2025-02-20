namespace FileDownload;

class Program
{
    public class FileDownload
    {
        public FileDownload()
        {
            Console.WriteLine("Download started...");
        }
        ~FileDownload()
        {
            Console.WriteLine("Download Completed");
        }
    }

    static void StartOfProcces()
        {
            FileDownload file = new FileDownload();
        }

    static void Main(string[] args)
    {
        StartOfProcces();
        GC.Collect();   
        GC.WaitForPendingFinalizers();

    }
}
