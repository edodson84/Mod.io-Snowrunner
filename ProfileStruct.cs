

namespace ModioSnowrunner
{

    public class ProfileStruct
    {
        public Userprofile UserProfile
        {
            get; set;
        }
        public int cfg_version
        {
            get; set;
        }
    }

    public class Userprofile
    {
        public Modtags modTags
        {
            get; set;
        }
        public Modfilter modFilter
        {
            get; set;
        }
        public int lastAgreement
        {
            get; set;
        }
        public int areModsPermitted
        {
            get; set;
        }
        public Modstatelist[] modStateList
        {
            get; set;
        }
        public bool gdprAccept
        {
            get; set;
        }
        public bool gdprSeen
        {
            get; set;
        }
        public int lastSaves
        {
            get; set;
        }
        public Moddependencies modDependencies
        {
            get; set;
        }
    }

    public class Modtags
    {
        public string[] SslSubtype
        {
            get; set;
        }
        public Sslvalue[] SslValue
        {
            get; set;
        }
        public string SslType
        {
            get; set;
        }
    }

    public class Sslvalue
    {
        public string tagGroupName
        {
            get; set;
        }
        public string[] tags
        {
            get; set;
        }
        public bool isHidden
        {
            get; set;
        }
        public bool isDropDownType
        {
            get; set;
        }
    }

    public class Modfilter
    {
        public User979527719 user979527719
        {
            get; set;
        }
    }

    public class User979527719
    {
        public Sslvalue1 SslValue
        {
            get; set;
        }
        public string SslType
        {
            get; set;
        }
    }

    public class Sslvalue1
    {
        public object[] tags
        {
            get; set;
        }
        public bool isEnabledMode
        {
            get; set;
        }
        public bool isConsoleForbiddenMode
        {
            get; set;
        }
        public bool isSubscriptionsMode
        {
            get; set;
        }
        public bool isConsoleApprovedMode
        {
            get; set;
        }
        public string sortField
        {
            get; set;
        }
        public bool sortIsAsc
        {
            get; set;
        }
    }

    public class Moddependencies
    {
        public Sslvalue2 SslValue
        {
            get; set;
        }
        public string SslType
        {
            get; set;
        }
    }

    public class Sslvalue2
    {
        public Dependencies dependencies
        {
            get; set;
        }
    }

    public class Dependencies : Dictionary<string, object[]>
    {

    }

    public class Modstatelist
    {
        public int modId
        {
            get; set;
        }
        public bool modState
        {
            get; set;
        }
    }

}
