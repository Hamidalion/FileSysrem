using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_FileStorage.Models
{
    [Serializable]
    public class Serialization
    {
        public string Name { get; set; }

        public string Extension { get; set; }

        public int Size { get; set; }

        public string CreationDate { get; set; }

        public int DownloadsNumber { get; set; }
    }
}
