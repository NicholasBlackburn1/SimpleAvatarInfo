using MelonLoader;
using System;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace SimpleAvatarInfo.ripper
{
    class DownloadRipper
    {
        static WebClient wc = new WebClient
        {
            Headers =
                {
                    ["User-Agent"] =
                        "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:87.0) Gecko/20100101 Firefox/87.0"
                }
        };
        public void downloadRipper()
        {
            MelonLogger.Msg(ConsoleColor.Magenta, "OwO Downloading ripper console....");
            string fileName = "AssetRipperConsole_win64";
      
            try
            {

                // Downolads ripper

                // Specify a progress notification handler here ...
                wc.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCallback2);


                // Downolads ripper

                wc.DownloadFileAsync(new Uri("https://github.com/ds5678/AssetRipper/releases/download/0.1.8.1/AssetRipperConsole_win64.zip"), AppDomain.CurrentDomain.BaseDirectory + @"\" + $"{fileName}.zip");
            } catch(Exception e)
            {
                MelonLogger.Msg(ConsoleColor.Red, e.Message);
            }

        }
        // triggers the extraction
        private static void DownloadFileCallback2(object sender, AsyncCompletedEventArgs e)
        {
            string fileName = "AssetRipperConsole_win64";

           
                if (e.Cancelled)
                {
                wc.Dispose();
                MelonLogger.Msg("File download cancelled.");
                }

                if (e.Error != null)
                {
                wc.Dispose();
                MelonLogger.Msg(e.Error.ToString());
                }
                else
                {
                try
                    {
                        wc.Dispose();
                        MelonLogger.Msg("Done downloading ripper OwO, time to extract it ");

                        ZipFile.ExtractToDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\" + $"{fileName}.zip", AppDomain.CurrentDomain.BaseDirectory + @"\Mods\" + $"{fileName}" + @"\");
                        MelonLogger.Msg(ConsoleColor.Green, "OwO Extracted ripper to" + " " + AppDomain.CurrentDomain.BaseDirectory + @"\Mods\" + $"{fileName}");


                    }
                    catch (Exception e3)
                    {
                        MelonLogger.Msg(ConsoleColor.Red, e3.Message);
                    }
            }
               

        }




    

    // this will be ran when the user downloads the vrca file 
    public void runRipper(string filenames, string aviname)
        {

            MelonLogger.Msg(ConsoleColor.DarkMagenta, "Starting to run Ripper Command");
            var baseCommand = AppDomain.CurrentDomain.BaseDirectory + @"\Mods\AssetRipperConsole_win64\"+"AssetRipperConsole.exe" + " "+ $"{filenames}" + " " + "--output" +" "+ $"{aviname}";

            MelonLogger.Msg("command thats going to be ran is" + $"{baseCommand}");

                // this will only run if the ripper is there 
                if(Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Mods\\" + "AssetRipperConsole_win64"))
                {

                    MelonLogger.Warning("Ripping avatar files from" + $"{filenames}");
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
            
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

                    startInfo.RedirectStandardOutput = true;
                    
                    process.Start();
                    MelonLogger.Msg("[RIPPER]"+$"{process.StandardOutput.ReadToEnd()}");


            }
            else
            {
                downloadRipper();
                MelonLogger.Msg("Time to Return back to the menu");
                return;
            }
                



        }
        private static void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)

        {

            // Displays the operation identifier, and the transfer progress.

            MelonLogger.Msg("{0}    downloaded {1} of {2} bytes. {3} % complete...",

                (string)e.UserState,

                e.BytesReceived,

                e.TotalBytesToReceive,

                e.ProgressPercentage);
        }

    }
}
