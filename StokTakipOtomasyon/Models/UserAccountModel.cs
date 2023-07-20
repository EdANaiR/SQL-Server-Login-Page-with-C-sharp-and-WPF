using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipOtomasyon.Models
{
    public class UserAccountModel
    {
        public string Username { get; set; }    
        public string DisplayName { get; set; } 
        public byte[] PrpfilPicture { get; set; }
        public object ProfilePicture { get; internal set; }
    }
}
