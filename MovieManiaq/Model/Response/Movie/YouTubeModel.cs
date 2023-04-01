namespace MovieManiaq.Model.Response.Movie
{
    public class YouTubeModel
    {
        public class AdaptiveFormat
        {
            public string approxDurationMs { get; set; }
            public int averageBitrate { get; set; }
            public int bitrate { get; set; }
            public string contentLength { get; set; }
            public int fps { get; set; }
            public int height { get; set; }
            public IndexRange indexRange { get; set; }
            public InitRange initRange { get; set; }
            public int itag { get; set; }
            public string lastModified { get; set; }
            public string mimeType { get; set; }
            public string projectionType { get; set; }
            public string quality { get; set; }
            public string qualityLabel { get; set; }
            public string url { get; set; }
            public int width { get; set; }
            public ColorInfo colorInfo { get; set; }
            public bool? highReplication { get; set; }
            public int? audioChannels { get; set; }
            public string audioQuality { get; set; }
            public string audioSampleRate { get; set; }
            public double? loudnessDb { get; set; }
        }

        public class ColorInfo
        {
            public string matrixCoefficients { get; set; }
            public string primaries { get; set; }
            public string transferCharacteristics { get; set; }
        }

        public class Format
        {
            public string approxDurationMs { get; set; }
            public int audioChannels { get; set; }
            public string audioQuality { get; set; }
            public string audioSampleRate { get; set; }
            public int averageBitrate { get; set; }
            public int bitrate { get; set; }
            public string contentLength { get; set; }
            public int fps { get; set; }
            public int height { get; set; }
            public int itag { get; set; }
            public string lastModified { get; set; }
            public string mimeType { get; set; }
            public string projectionType { get; set; }
            public string quality { get; set; }
            public string qualityLabel { get; set; }
            public string url { get; set; }
            public int width { get; set; }
        }

        public class IndexRange
        {
            public string end { get; set; }
            public string start { get; set; }
        }

        public class InitRange
        {
            public string end { get; set; }
            public string start { get; set; }
        }

        public class YouTubeRoot
        {
            public List<AdaptiveFormat> adaptiveFormats { get; set; }
            public List<Format> formats { get; set; }
            public bool isProtectedContent { get; set; }
            public string publishDate { get; set; }
        }
    }
}
