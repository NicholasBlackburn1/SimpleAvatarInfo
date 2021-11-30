using MelonLoader;
using System;
using System.IO;
using System.Net;

namespace SimpleAvatarInfo.ripper
{
    class downloadripper
    {

        public void downloadRipper()
        {
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
                MelonLogger.Warning($"Couldn't find {fileName}.dll on disk. Saving latest version from GitHub. to the locaton " + AppDomain.CurrentDomain.BaseDirectory + "\\" + $"{fileName}.zip");
                bytes = latestBytes;
                File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "\\Mods\\" + $"{fileName}.zip", bytes);

                FileStream compressedFileStream = File.Open(AppDomain.CurrentDomain.BaseDirectory + "\\" + $"{fileName}.zip", FileMode.Open);
                FileStream outputFileStream = File.Create(AppDomain.CurrentDomain.BaseDirectory + "\\" + $"{fileName});
                var decompressor = new GZipStream(compressedFileStream, CompressionMode.Decompress);
                decompressor.CopyTo(outputFileStream);
            }

        }

    }
}
