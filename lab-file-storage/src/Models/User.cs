using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_FileStorage.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public DateTime CreationDate { get; set; }

        public int StorageUsed { get; set; }
    }
}
