using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle("SimpleAvatarInfo.BuildInfo.Description")]
[assembly: AssemblyDescription("SimpleAvatarInfo.BuildInfo.Description")]
[assembly: AssemblyCompany("SimpleAvatarInfo.BuildInfo.Company")]
[assembly: AssemblyProduct("SimpleAvatarInfo.BuildInfo.Name")]
[assembly: AssemblyCopyright("SimpleAvatarInfo.BuildInfo.Author")]
[assembly: AssemblyTrademark("SimpleAvatarInfo.BuildInfo.Company")]
[assembly: AssemblyVersion(SimpleAvatarInfo.BuildInfo.Version)]
[assembly: AssemblyFileVersion(SimpleAvatarInfo.BuildInfo.Version)]
[assembly: MelonInfo(typeof(SimpleAvatarInfo.SimpleAvatarInfo), SimpleAvatarInfo.BuildInfo.Name, SimpleAvatarInfo.BuildInfo.Version, SimpleAvatarInfo.BuildInfo.Author, SimpleAvatarInfo.BuildInfo.DownloadLink)]
[assembly: MelonColor()]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]