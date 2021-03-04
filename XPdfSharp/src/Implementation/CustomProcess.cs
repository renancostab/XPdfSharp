using System.Diagnostics;
using System.Threading.Tasks;

namespace XPdfSharp.Implementation
{
    public static class CustomProcess
    {
        public static Task<int> RunProcessAsync(string fileName, string arguments, string workingDirectory)
        {
            var tcs = new TaskCompletionSource<int>();
            var process = CreateNewProcess(fileName, arguments, workingDirectory);

            process.Exited += (sender, args) =>
            {
                tcs.SetResult(process.ExitCode);
                process.Dispose();
            };

            process.Start();
            return tcs.Task;
        }        
        
        private static Process CreateNewProcess(string fileName, string arguments, string workingDirectory)
        {
            return new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = arguments,
                    UseShellExecute = false,
                    WorkingDirectory = workingDirectory,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                },
                EnableRaisingEvents = true
            };               
        }
    }
}