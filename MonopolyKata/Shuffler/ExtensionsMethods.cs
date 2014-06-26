using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace MonopolyKata.Extensions
{
    public static class ExtensionMethods
    {

        public static List<T> Shuffle<T>(this IList<T> list)
        {

            return list.OrderBy(a => Guid.NewGuid()).ToList();
            
        }

    }


}
