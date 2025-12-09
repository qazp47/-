using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_3
{

    [Flags]
    enum FileAccess
    {
        None = 0,
        Read = 1,
        Write = 2,
        Execute = 4
    }
    struct File
    {
        public FileAccess Permissions;
        public File(FileAccess permissions)
        {
            Permissions = permissions;
        }
        public bool CanRead()
        {
            return (Permissions & FileAccess.Read) == FileAccess.Read;
        }
        public bool CanWrite()
        {
            return (Permissions & FileAccess.Write) == FileAccess.Write;
        }
    }

    class Program
    {
        static void Main()
        {
            var f = new File(FileAccess.Read | FileAccess.Write);
            Console.WriteLine("Can Read? " + f.CanRead());
            Console.WriteLine("Can Write? " + f.CanWrite());

        }
    }
}