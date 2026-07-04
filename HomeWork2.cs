using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;

namespace ThreadingConsoleApp3;

// Main HomeWork
//class Program
//{
//    static async Task Main()
//    {
//        const string ulr1 = "https://uk.wikipedia.org/wiki/M1_Abrams";
//        const string ulr2 = "https://uk.wikipedia.org/wiki/M2_Bradley";
//        const string ulr3 = "https://uk.wikipedia.org/wiki/Rheinmetall_Rh-120";

//        const string file1 = "Content1.txt";
//        const string file2 = "Content2.txt";
//        const string file3 = "Content3.txt";

//        //await DownloadFromUrl(ulr1, file1);

//        using CancellationTokenSource cts = new CancellationTokenSource();

//        Task.Run(() => DownloadFromUrl(ulr1,file1,cts.Token));
//        Task.Run(() => DownloadFromUrl(ulr2, file2, cts.Token));
//        Task.Run(() => DownloadFromUrl(ulr3, file3, cts.Token));

//        Console.WriteLine("Press enter to cancel operation");
//        Console.Read();
//        cts.Cancel();
//        Console.WriteLine("Cancelled operation");
//    }

//    static readonly HttpClient client = new HttpClient()
//    {
//        DefaultRequestHeaders = { { "User-Agent", "ConsoleWikiDownloader/1.0 (MyEducationalProject)" } }
//    };
//    static async Task DownloadFromUrl(string url, string fileName, CancellationToken cancellationToken)
//    {
//        Console.WriteLine("Started Downloading");
//        Thread.Sleep(1000);
//        cancellationToken.ThrowIfCancellationRequested();

//        using (var response = await client.GetStreamAsync(url, cancellationToken))
//        using (FileStream fileStream = File.Create($"C:\\Users\\User\\source\\repos\\SQLConsoleApp2\\ThreadingConsoleApp3\\{fileName}"))
//        {
//            await response.CopyToAsync(fileStream, cancellationToken);
//        }
//        Console.WriteLine("Finished Downloading");
//    }
//}
// Additional HomeWork

// # 1
//class Program
//{
//    static void Main()
//    {
//        Depositor depositor1 = new Depositor { Name = "guy1", Deposit = 29000, Id = 1 };
//        Depositor depositor2 = new Depositor { Name = "guy2", Deposit = 10500, Id = 2 };
//        Depositor depositor3 = new Depositor { Name = "guy2", Deposit = 40002, Id = 3 };

//        Task<int> data1 = Task.Run(() => CalculateDepositPack(depositor1));
//        Task<int> data2 = Task.Run(() => CalculateDepositPack(depositor2));
//        Task<int> data3 = Task.Run(() => CalculateDepositPack(depositor3));
//        Task.WaitAll();
//        Console.WriteLine($"{depositor1} got {data1.Result} packs of 10000");
//        Console.WriteLine($"{depositor2} got {data2.Result} packs of 10000");
//        Console.WriteLine($"{depositor3} got {data3.Result} packs of 10000");
//    }
//    static int CalculateDepositPack(Depositor depositor)
//    {
//        return (int)(depositor.Deposit / 10000);
//    }

//    Console.Read();

//}

//public class Depositor
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public decimal Deposit { get; set; }
//}

// # 2
//class Program
//{
//    static void Main()
//    {
//        List<int> numberList = new List<int>
//        {
//            1,2,3,4,5,6,7,8,9,10
//        };

//        Task<int> data = Task.Run(() => GoThroughListAndReturn(numberList));


//        Console.WriteLine("Result - {0}", data.Result);

//        Console.Read();


//    }

//    static int GoThroughListAndReturn(List<int> list)
//    {
//        int value = 0;
//        List<Task> data = new List<Task>();
//        foreach (var item in list)
//        {
//            data.Add(Task.Run(() => AddValue(ref value, item)));
//        }

//        Task.WaitAll(data);

//        return value;
//    }

//    static void AddValue(ref int value, int adddedValue)
//    {
//        value += adddedValue;
//    }
//}

// # 3
//class Program
//{
//    static void Main()
//    {
//        List<int> numberList = new List<int>();

//        for (int i = 0; i < 100; i++)
//        {
//            numberList.Add(Random.Shared.Next(1, 11));
//        }

//        Task<List<int>> task1 = new Task<List<int>>(() => DeleteDuplicates(numberList));

//        Task<List<int>> task2 = task1.ContinueWith(e => BubbleSort(e.Result));

//        task1.Start();

//        Task<int?> task3 = task2.ContinueWith(e => BinarySearch(e.Result, 3));

//        task3.Wait();

//        Console.WriteLine($"Result: {task3.Result}");

//        Console.Read();
//    }

//    static List<int> DeleteDuplicates(List<int> list)
//    {
//        List<int> newList = new List<int>();

//        for (int i = 0; i < list.Count; i++)
//        {
//            if (!newList.Contains(list[i]))
//            {
//                newList.Add(list[i]);
//            }
//            else
//            {
//                list.RemoveAt(i);
//            }
//        }

//        return newList;
//    }

//    static List<int> BubbleSort(List<int> list)
//    {
//        bool swapOperation = false;
//        for (int i = 0; i < list.Count; i++)
//        {
//            for (int j = 0; j < list.Count - 1; j++)
//            {
//                if (list[j] > list[j + 1])
//                {
//                    (list[j], list[j + 1]) = (list[j + 1], list[j]);
//                    swapOperation = true;
//                }
//            }
//            if (!swapOperation)
//            {
//                break;
//            }
//        }
//        return list;
//    }

//    static int? BinarySearch(List<int> list, int number)
//    {
//        int searchedIndex = list.Count() / 2;
//        for (int i = 0; i < list.Count() / 2 + 1; i++)
//        {
//            if (list[searchedIndex] == number)
//            {
//                return list[searchedIndex];
//            }
//            else if (list[searchedIndex] < number)
//            {
//                searchedIndex = searchedIndex + searchedIndex / 2;
//            }
//            else
//            {
//                searchedIndex = searchedIndex - searchedIndex / 2;
//            }
//        }
//        return null;
//    }
//}

// # 4

//class Program

//{
//    [DllImport("user32.dll", CharSet = CharSet.Auto)]
//    public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

//    private const uint MB_YESNOCANCEL = 0x00000003;
//    private const uint MB_YESNO = 0x00000004;
//    private const uint MB_OKCANCEL = 0x00000001;

//    public static async Task<string> ShowDialog(string text, string caption)
//    {
//        string command = $"[void][System.Reflection.Assembly]::LoadWithPartialName('Microsoft.VisualBasic'); " +
//                         $"$res = [Microsoft.VisualBasic.Interaction]::InputBox('{text}', '{caption}'); " +
//                         $"Write-Output $res";

//        ProcessStartInfo startInfo = new ProcessStartInfo
//        {
//            FileName = "powershell.exe",
//            Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{command}\"",
//            RedirectStandardOutput = true,
//            UseShellExecute = false,
//            CreateNoWindow = true
//        };

//        return await Task.Run(() =>
//        {
//            try
//            {
//                using (Process process = Process.Start(startInfo))
//                {
//                    if (process != null)
//                    {
//                        string result = process.StandardOutput.ReadToEnd().Trim();
//                        process.WaitForExit();
//                        return result;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error: {ex.Message}");
//            }
//            return "";
//        });
//    }


//    static async Task Main()
//    {
//        string result = await ShowDialog("Enter Your Text (ReadLine аналог):", "Readline Window");


//        int amountOfSentences = result.Count(e => e == '.' || e == '?' || e == '!');
//        int amountOfSymbols = result.Length;
//        int amountOfWords = result.Split('.', '!', '?', ' ').Count();
//        int amountOfQuestionSentences = result.Count(e => e == '?');
//        int amountOfExclamationSentences = result.Count(e => e == '!');

//        MessageBox(IntPtr.Zero, "You Entered: " + result, "Result", 0);
//;

//        switch (MessageBox(IntPtr.Zero, "yes - save stats, no - show stats via window", "Window", MB_YESNO))
//        {
//            case 6:
//                string path = $"C:\\Users\\User\\source\\repos\\SQLConsoleApp2\\ThreadingConsoleApp3\\Stats.txt";
//                string stats = $"""              
//                Amount of sentences - {amountOfSentences} 
//                Amount of Symbols - {amountOfSymbols}
//                Amount of words - {amountOfWords}
//                Amount of question sentences - {amountOfQuestionSentences}
//                Amount of exclamation sentences - {amountOfExclamationSentences}
//                """;
//                await File.WriteAllTextAsync(path, stats, Encoding.UTF8);
//                break;
//            case 7:
//                MessageBox(IntPtr.Zero, $"""
//                Amount of sentences - {amountOfSentences}
//                Amount of Symbols - {amountOfSymbols}
//                Amount of words - {amountOfWords}
//                Amount of question sentences - {amountOfQuestionSentences}
//                Amount of exclamation sentences - {amountOfExclamationSentences}
//                yes - save, no - show via window
//                """, "Result", 0);
//                break;
//            default:
//                break;
//        }

//    }
//}