using Newtonsoft.Json.Linq;
using System.Text.Json;
using ModioSnowrunner;

namespace ModioSnowrunner
{
    public static class GlobalVariables
    {
        public static string ModioApi = "https://api.mod.io/v1";
        public static int tokenexpires;
        public static string AuthToken;
        public static string apikey;
        public static string Email;
        public static string profile_directory;
        public static JObject Mod;
        public static JObject user_profile = JObject.Parse(@"{
        ""UserProfile"": {
            ""modDependencies"": {
                ""SslType"": ""ModDependencies"",
                ""SslValue"": {
                    ""dependencies"": {}
                }
            },
            ""modStateList"": [],
            ""modTags"": {
                ""SslSubtype"": [""ModBrowserFilterTagGroup""],
                ""SslType"": ""array"",
                ""SslValue"": [{
                        ""tagGroupName"": ""Type"",
                        ""isDropDownType"": true,
                        ""tags"": [""Vehicle New"", ""Vehicle Tweak"", ""Map""],
                        ""isHidden"": false
                    }, {
                        ""tagGroupName"": ""Vehicle"",
                        ""isDropDownType"": true,
                        ""tags"": [""Motorbike"", ""Car"", ""4x4"", ""Truck"", ""Other""],
                        ""isHidden"": false
                    }, {
                        ""tagGroupName"": ""Map"",
                        ""isDropDownType"": true,
                        ""tags"": [""Winter"", ""Summer"", ""Autumn"", ""Spring""],
                        ""isHidden"": false
                    }, {
                        ""tagGroupName"": ""Players"",
                        ""isDropDownType"": false,
                        ""tags"": [""Multiplayer"", ""Singleplayer""],
                        ""isHidden"": false
                    }, {
                        ""tagGroupName"": ""Changes"",
                        ""isDropDownType"": false,
                        ""tags"": [""Appearance"", ""Crane"", ""Engine"", ""Names"", ""Physics"", ""Settings"", ""Sound"", ""Trailer"", ""Transmission"", ""Tires"", ""Winch""],
                        ""isHidden"": false
                    }
                ]
            },
            ""areModsPermitted"": 1,
            ""lastSaves"": 1,
            ""gdprAccept"": true,
            ""gdprSeen"": true,
            ""lastAgreement"": 1,
            ""modFilter"": {
            }
        },
        ""cfg_version"": 1
    }");
        public static JObject authjson = JObject.Parse(@"{
        'access_token': '',
        'expiration_date': ,
        'last_user_event_poll_id': 0,
        'user': {
            'avatar': {
                'filename': '',
                'original': '',
                'thumb_100x100': '',
                'thumb_50x50': ''
            },
            'date_online': 0,
            'id': 0,
            'language': '',
            'name_id': '',
            'profile_url': '',
            'timezone': '',
            'username': ''
        }
    }");
    }
}

