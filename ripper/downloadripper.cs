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


            byte[] bytes = null;
            byte[] latestBytes = null;

            // Downolads ripper

            try
            {
                latestBytes = wc.DownloadData($"https://github.com/ds5678/AssetRipper/releases/download/0.1.8.1/AssetRipperConsole_win64.zip");
            }
            catch (WebException e)
            {
                MelonLogger.Error($"Unable to download latest version of AssetRipper: {e}");
            }

            if (bytes == null)
            {
                if (latestBytes == null)
                {
                    MelonLogger.Error($"No local file exists and unable to download latest version from GitHub. {fileName} will not load!");
                    return;
                }
                MelonLogger.Warning($"Couldn't find {fileName}.zip on disk. Saving latest version from GitHub. to the locaton " + AppDomain.CurrentDomain.BaseDirectory + "\\" + $"{fileName}.zip");
                bytes = latestBytes;
                File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "\\" + $"{fileName}.zip", bytes);

                FileStream compressedFileStream = File.Open(AppDomain.CurrentDomain.BaseDirectory + "\\" + $"{fileName}.zip", FileMode.Open);
                FileStream outputFileStream = File.Create(AppDomain.CurrentDomain.BaseDirectory + "\\Mods\\" + $"{fileName}");

                var decompressor = new GZipStream(compressedFileStream, CompressionMode.Decompress);
                decompressor.CopyTo(outputFileStream);

                MelonLogger.Msg(ConsoleColor.Green, "OwO Extracted ripper to" + " " + AppDomain.CurrentDomain.BaseDirectory + "\\Mods\\" + $"{fileName}");


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

    }
}
