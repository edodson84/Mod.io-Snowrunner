

namespace ModioSnowrunner
{


    public class ModStruct
    {
        public Datum[] data
        {
            get; set;
        }
        public int result_count
        {
            get; set;
        }
        public int result_offset
        {
            get; set;
        }
        public int result_limit
        {
            get; set;
        }
        public int result_total
        {
            get; set;
        }
    }

    public class Datum
    {
        public int id
        {
            get; set;
        }
        public int game_id
        {
            get; set;
        }
        public int status
        {
            get; set;
        }
        public int visible
        {
            get; set;
        }
        public Submitted_By submitted_by
        {
            get; set;
        }
        public int date_added
        {
            get; set;
        }
        public int date_updated
        {
            get; set;
        }
        public int date_live
        {
            get; set;
        }
        public int maturity_option
        {
            get; set;
        }
        public int community_options
        {
            get; set;
        }
        public int monetization_options
        {
            get; set;
        }
        public int stock
        {
            get; set;
        }
        public int price
        {
            get; set;
        }
        public int tax
        {
            get; set;
        }
        public Logo logo
        {
            get; set;
        }
        public object homepage_url
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
        public string name_id
        {
            get; set;
        }
        public string summary
        {
            get; set;
        }
        public string description
        {
            get; set;
        }
        public string description_plaintext
        {
            get; set;
        }
        public object metadata_blob
        {
            get; set;
        }
        public string profile_url
        {
            get; set;
        }
        public Media media
        {
            get; set;
        }
        public Modfile modfile
        {
            get; set;
        }
        public bool dependencies
        {
            get; set;
        }
        public Platform1[] platforms
        {
            get; set;
        }
        public object[] metadata_kvp
        {
            get; set;
        }
        public Tag[] tags
        {
            get; set;
        }
        public Stats stats
        {
            get; set;
        }
    }

    public class Submitted_By
    {
        public int id
        {
            get; set;
        }
        public string name_id
        {
            get; set;
        }
        public string username
        {
            get; set;
        }
        public object display_name_portal
        {
            get; set;
        }
        public int date_online
        {
            get; set;
        }
        public int date_joined
        {
            get; set;
        }
        public Avatar avatar
        {
            get; set;
        }
        public string timezone
        {
            get; set;
        }
        public string language
        {
            get; set;
        }
        public string profile_url
        {
            get; set;
        }
    }

    public class Avatar
    {
        public string filename
        {
            get; set;
        }
        public string original
        {
            get; set;
        }
        public string thumb_50x50
        {
            get; set;
        }
        public string thumb_100x100
        {
            get; set;
        }
    }

    public class Logo
    {
        public string filename
        {
            get; set;
        }
        public string original
        {
            get; set;
        }
        public string thumb_320x180
        {
            get; set;
        }
        public string thumb_640x360
        {
            get; set;
        }
        public string thumb_1280x720
        {
            get; set;
        }
    }

    public class Media
    {
        public object[] youtube
        {
            get; set;
        }
        public object[] sketchfab
        {
            get; set;
        }
        public Images[] images
        {
            get; set;
        }
    }

    public class Images
    {
        public string filename
        {
            get; set;
        }
        public string original
        {
            get; set;
        }
        public string thumb_320x180
        {
            get; set;
        }
        public string thumb_1280x720
        {
            get; set;
        }
    }

    public class Modfile
    {
        public int id
        {
            get; set;
        }
        public int mod_id
        {
            get; set;
        }
        public int date_added
        {
            get; set;
        }
        public int date_updated
        {
            get; set;
        }
        public int date_scanned
        {
            get; set;
        }
        public int virus_status
        {
            get; set;
        }
        public int virus_positive
        {
            get; set;
        }
        public object virustotal_hash
        {
            get; set;
        }
        public int filesize
        {
            get; set;
        }
        public int filesize_uncompressed
        {
            get; set;
        }
        public Filehash filehash
        {
            get; set;
        }
        public string filename
        {
            get; set;
        }
        public string version
        {
            get; set;
        }
        public string changelog
        {
            get; set;
        }
        public object metadata_blob
        {
            get; set;
        }
        public Download download
        {
            get; set;
        }
        public Platform[] platforms
        {
            get; set;
        }
    }

    public class Filehash
    {
        public string md5
        {
            get; set;
        }
    }

    public class Download
    {
        public string binary_url
        {
            get; set;
        }
        public int date_expires
        {
            get; set;
        }
    }

    public class Platform
    {
        public string platform
        {
            get; set;
        }
        public int status
        {
            get; set;
        }
    }

    public class Stats
    {
        public int mod_id
        {
            get; set;
        }
        public int popularity_rank_position
        {
            get; set;
        }
        public int popularity_rank_total_mods
        {
            get; set;
        }
        public int downloads_today
        {
            get; set;
        }
        public int downloads_total
        {
            get; set;
        }
        public int subscribers_total
        {
            get; set;
        }
        public int ratings_total
        {
            get; set;
        }
        public int ratings_positive
        {
            get; set;
        }
        public int ratings_negative
        {
            get; set;
        }
        public int ratings_percentage_positive
        {
            get; set;
        }
        public float ratings_weighted_aggregate
        {
            get; set;
        }
        public string ratings_display_text
        {
            get; set;
        }
        public int date_expires
        {
            get; set;
        }
    }

    public class Platform1
    {
        public string platform
        {
            get; set;
        }
        public int modfile_live
        {
            get; set;
        }
    }

    public class Tag
    {
        public string name
        {
            get; set;
        }
        public string name_localized
        {
            get; set;
        }
        public int date_added
        {
            get; set;
        }
    }


}
