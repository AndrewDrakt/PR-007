using System;
using System.IO;

namespace практ7

{
    internal class Program
    {
        public static void menudrive(int y)
        {
            foreach (var dr in DriveInfo.GetDrives())
            {
                y++;
                Console.WriteLine("  " + dr.Name + " " + dr.AvailableFreeSpace / 1073741824 + "ГБ свободно из " + dr.TotalSize / 1073741824);
            }
        }
        public static void Main()
        {
            Console.WriteLine("<<-------------------------------------------------------------------->>");
            int sch = 1;
            int alpha = 3;
            int x = 2;
            int y = 0;
            /*menudrive(y);*/
            foreach (var dr in DriveInfo.GetDrives())
            {
                y++;
                Console.WriteLine("  " + dr.Name + " " + dr.AvailableFreeSpace / 1073741824 + "ГБ свободно из " + dr.TotalSize / 1073741824);
            }
            ConsoleKeyInfo clav = Console.ReadKey();

            while (clav.Key != ConsoleKey.Enter)
            {

                if (clav.Key == ConsoleKey.UpArrow)
                {
                    sch--;

                    if (sch < 1)
                    {
                        sch = y;
                    }
                }
                else if (clav.Key == ConsoleKey.DownArrow)
                {
                    sch++;
                    if (sch > y)
                    {
                        sch = 1;
                    }
                }
                Console.Clear();
                Console.WriteLine("<<-------------------------------------------------------------------->>");
                foreach (var dr in DriveInfo.GetDrives())
                {
                    Console.WriteLine("  " + dr.Name + " " + dr.AvailableFreeSpace / 1073741824 + "ГБ свободно из " + dr.TotalSize / 1073741824);
                }
                Console.SetCursorPosition(0, sch);
                Console.WriteLine("->");
                clav = Console.ReadKey();
            }


            void checkfolder(string path)
            {

                 string d = Path.GetDirectoryName(path);
                Console.Clear();
                DirectoryInfo dir = new DirectoryInfo(Directory.GetDirectories(path)[sch - 1]);
                FileInfo fil = new FileInfo(Directory.GetFiles(path)[sch - 1]);
                Console.WriteLine("Папка");
                Console.WriteLine(@""" <<-------------------------------------------------------------------->>
  Имя файла       Дата создания       Тип""");
                foreach (var item in dir.GetDirectories())
                {
                    Console.WriteLine("  " + item.Name + "      " + item.CreationTime + "        " + item.GetType, d, d.Length);
                    x++;
                }
                ConsoleKeyInfo vbr = Console.ReadKey();
                while (vbr.Key != ConsoleKey.Escape || vbr.Key != ConsoleKey.Enter)
                {
                    if (vbr.Key == ConsoleKey.UpArrow)
                    {
                        alpha--;
                        if (alpha < 3)
                        {
                            alpha = x;
                        }
                    }
                    else if (vbr.Key == ConsoleKey.DownArrow)
                    {
                        alpha++;
                        if (alpha > x)
                        {
                            alpha = 3;
                        }
                    }
                    Console.SetCursorPosition(0, alpha);
                    Console.WriteLine("->");
                    vbr = Console.ReadKey();
                }
                if (vbr.Key == ConsoleKey.Enter)
                {
                    checkfolder(dir.GetDirectories()[alpha].ToString());

                }
                if (vbr.Key == ConsoleKey.Escape)
                {
                    return;
                }
                /*            Console.Clear();
                            DirectoryInfo dir1 = new DirectoryInfo(dir.GetDirectories()[alpha - 3].Name);
                            foreach (var item in dir1.GetDirectories())
                            {
                                Console.WriteLine("  " + item.Name + "      " + item.CreationTime + "        " + item.GetType);

                            }*/
            }
        }
    }
}