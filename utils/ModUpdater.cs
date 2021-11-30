using Il2CppSystem.Reflection;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
/**
 * this class is for handling downloading vrchat mods to update everything owo
 */
namespace SimpleAvatarInfo.utils
{
    class ModUpdater
    {

        internal static class GitHubInfo
        {
            public const string Author = "NicholasBlackburn1";
            public const string Repository = "SimpleAvatarInfo";
            public const string Version = "latest";
        }

        // downloads and updated the mod from gethub
        public void DownloadFromGitHub(string fileName)
        {

            MelonLogger.Warning("Path for Updated Mod is at"+AppDomain.CurrentDomain.BaseDirectory + "\\Mods\\" + $"{fileName}.dll");
             var sha256 = SHA256.Create();

            byte[] bytes = null;
            if (File.Exists($"{fileName}.dll"))
            {
                bytes = File.ReadAllBytes($"{fileName}.dll");
            }

             var wc = new WebClient
            {
                Headers =
                {
                    ["User-Agent"] =
                        "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:87.0) Gecko/20100101 Firefox/87.0"
                }
            };

            byte[] latestBytes = null;
            try
            {
                latestBytes = wc.DownloadData($"https://github.com/{GitHubInfo.Author}/{GitHubInfo.Repository}/releases/{GitHubInfo.Version}/download/{fileName}.dll");
            }
            catch (WebException e)
            {
                MelonLogger.Error($"Unable to download latest version of SimpleAvatarInfo: {e}");
            }

            if (bytes == null)
            {
                if (latestBytes == null)
                {
                    MelonLogger.Error($"No local file exists and unable to download latest version from GitHub. {fileName} will not load!");
                    return;
                }
                MelonLogger.Warning($"Couldn't find {fileName}.dll on disk. Saving latest version from GitHub. to the locaton "+ AppDomain.CurrentDomain.BaseDirectory + "\\Mods\\" + $"{fileName}.dll");
                bytes = latestBytes;
                File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory+"\\Mods\\"+$"{fileName}.dll", bytes);
            }


            if (latestBytes != null)
            {
                var latestHash = ComputeHash(sha256, latestBytes);
                var currentHash = ComputeHash(sha256, bytes);

                if (latestHash != currentHash)
                {
                        bytes = latestBytes;
                        File.WriteAllBytes($"{fileName}.dll", bytes);
                        MelonLogger.Msg(ConsoleColor.Green, $"Updated {fileName} to latest version.\n"+ ConsoleColor.Magenta+$"CurrentHash: { currentHash}\n"+ ConsoleColor.Blue + $" latestHash: {latestHash}\n");
                    }
                }


            MelonLogger.Msg("Now saving Updated mod to the Mods folder....");

            
        }

        private static string ComputeHash(HashAlgorithm sha256, byte[] data)
        {
            var bytes = sha256.ComputeHash(data);
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }

}
