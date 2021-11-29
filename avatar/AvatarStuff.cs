using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRC.Core;
using Newtonsoft.Json;


namespace SimpleAvatarInfo
{
    class AvatarStuff
    {

        public LinkedList<string> avi = new LinkedList<string>();

        // Sets up simple api avatar adapter 
        [Serializable]
        internal class Avatar
        {
          

            public string Id { get; set; }
            public string AvatarName { get; set; }
            public string AuthorId { get; set; }
            public string AuthorName { get; set; }
            public string Description { get; set; }
            public string AssetUrl { get; set; }
            public string ImageUrl { get; set; }
            public string ThumbnailUrl { get; set; }
            public ApiModel.SupportedPlatforms SupportedPlatforms = ApiModel.SupportedPlatforms.StandaloneWindows;

            public Avatar()
            {
            }
            // creates and pulls avatar info from api
            public Avatar(ApiAvatar apiAvatar)
            {
                Id = apiAvatar.id;
                AvatarName = apiAvatar.name;
                AuthorId = apiAvatar.authorId;
                AuthorName = apiAvatar.authorName;
                Description = apiAvatar.description;
                AssetUrl = apiAvatar.assetUrl;
                ThumbnailUrl = apiAvatar.thumbnailImageUrl;
                SupportedPlatforms = apiAvatar.supportedPlatforms;
            }

            // sets me to allow to bull avi with more and more info
            public ApiAvatar AsApiAvatar()
            {
                return new ApiAvatar
                {
                    id = Id,
                    name = AvatarName,
                    authorId = AuthorId,
                    authorName = AuthorName,
                    description = Description,
                    assetUrl = AssetUrl,
                    thumbnailImageUrl = string.IsNullOrEmpty(ThumbnailUrl) ? (string.IsNullOrEmpty(ImageUrl) ? "https://assets.vrchat.com/system/defaultAvatar.png" : ImageUrl) : ThumbnailUrl,
                    releaseStatus = "public",
                    unityVersion = "2019.4.29f1",
                    version = 1,
                    apiVersion = 1,
                    Endpoint = "avatars",
                    Populated = false,
                    assetVersion = new AssetVersion("2019.4.29f1", 0),
                    tags = new Il2CppSystem.Collections.Generic.List<string>(0),
                    supportedPlatforms = SupportedPlatforms,
                };
            }

            public string ToJson()
            {
                return JsonConvert.SerializeObject(this);
            }
            

            public string getAvatarId()
            {
               
                return this.Id;
            }

            public string getAvatarName()
            {
                return this.AvatarName;
            }
            
            public string getAvatarAssetURl()
            {
                return this.AssetUrl;
            }

   
        }
        public void addAvatarsToList(VRC.Core.ApiAvatar apiAvi)
        {
            Avatar avatar = new Avatar(apiAvi);

            avi.AddFirst(avatar.getAvatarId());
            avi.Append(avatar.getAvatarName());
            avi.Append(avatar.getAvatarAssetURl());
            
        }


        public string getAvatarList()
        {
            return avi.ToString();
        }
    }

}
