using MelonLoader;
using System;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace SimpleAvatarInfo.ripper
{
    class DownloadRipper
    {

        public void downloadRipper()
        {
            MelonLogger.Msg(ConsoleColor.Magenta, "OwO Downloading ripper console....");
            string fileName = "AssetRipperConsole_win64";
            var wc = new WebClient
            {
                Headers =
                {
                    ["User-Agent"] =
                        "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:87.0) Gecko/20100101 Firefox/87.0"
                }
            };


            // Downolads ripper

            try
            {
                wc.DownloadDataAsync(new Uri($"https://github.com/ds5678/AssetRipper/releases/download/0.1.8.1/AssetRipperConsole_win64.zip"), AppDomain.CurrentDomain.BaseDirectory + "\\" + $"{fileName}.zip");
                MelonLogger.Msg("Done downloading ripper OwO, time to extract it ");

                ZipFile.ExtractToDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\" + $"{fileName}.zip", AppDomain.CurrentDomain.BaseDirectory + @"\Mods\" + $"{fileName}"+@"\");
                MelonLogger.Msg(ConsoleColor.Green, "OwO Extracted ripper to" + " " + AppDomain.CurrentDomain.BaseDirectory + @"\Mods\" + $"{fileName}");


            }
            catch (WebException e)
            {
                MelonLogger.Error($"Unable to download latest version of AssetRipper: {e}");
            }
        
    
        }
            
            // this will be ran when the user downloads the vrca file 
        public void runRipper(string filenames, string outputdir)
        {

            MelonLogger.Msg(ConsoleColor.DarkMagenta, "Starting to run Ripper Command");
            var baseCommand = ".\\AssetRipperConsole.exe" + $"{filenames}" + " " + "--output" + $"{outputdir}" + $"{filenames}";

            MelonLogger.Msg("command thats going to be ran is" + $"{baseCommand}");

                // this will only run if the ripper is there 
                if(Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Mods\\" + "AssetRipperConsole_win64"))
                {

                    MelonLogger.Warning("Ripping avatar files from" + $"{filenames}");
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
            
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

                    startInfo.RedirectStandardOutput = true;


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
