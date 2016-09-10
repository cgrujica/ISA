using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;

namespace Restoran
{
    public class Help
    {
        public static string ID;

        public static string emailGosta;
        public static string idRestorana;
        public static DateTime vremeDolaska;
        public static DateTime vremeOdlaska;

        public static uint vremeTrajanja;
        public static string idStola;

        public static EntityState Modified { get; internal set; }

        public static string encrypt(string ToEncrypt)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(ToEncrypt));
        }
        public static string decrypt(string cypherString)
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(cypherString));
        }
    }
}