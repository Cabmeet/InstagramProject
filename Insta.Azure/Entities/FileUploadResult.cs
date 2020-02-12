using System;

namespace Insta.Azure.Entities
{
    public sealed class FileUploadResult
    {
        public string ContentMD5 { get; set; }

        public Uri Uri { get; set; }
    }
}