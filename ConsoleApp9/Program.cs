using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp8
{
    class Program
    {
        class help
        {
            string[] arr1 = { "cd", "cls", "dir", "quit", "copy", "del", "help", "md", "rd", "rename", "type", "import", "export" };
            string[] arr2 =
            {"Change the current default directory to . If the argument is not present,"+'\n'+'\t'+"report the current directory. If the directory does not exist an appropriate error should be reported"
            ,"Clear the screen","List the contents of directory","Quit the shell","Copies one or more files to another location​","Deletes one or more files"
            ,"Provides Help information for commands","Creates a directory","Removes a directory","Renames a file","Displays the contents of a text file","import text file(s) from your computer​"
            ,"export text file(s) to your computer​" };
            public void run()
            {
                string str;
                Console.WriteLine(Environment.CurrentDirectory);

                Console.Write(">>> ");
                str = Console.ReadLine();
                string no = str;
                str = str.ToLower();
                str = str.Trim();
                while (str != "exit")
                {
                    string x = "";
                    bool space = true;
                    for (int i = 0; i < str.Length; i++)
                    {

                        if (str[i] != ' ')
                        {
                            x += str[i];
                            space = true;
                        }
                        else
                        {
                            if (space)
                            {
                                x += str[i];
                                space = false;
                            }
                        }
                    }

                    string[] s = x.Split(' ');

                    if (s.Length == 1)
                    {
                        if (s[0] == "")
                        {

                        }
                        else if (s[0] == "help")
                        {
                            h();
                        }
                        else if (s[0] == "cls")
                        {
                            Console.Clear();
                            Console.WriteLine(Environment.CurrentDirectory);
                        }
                        else
                        {
                            Console.WriteLine(no + " is not existe");
                        }

                    }
                    else if (s.Length > 1)
                    {
                        if (s[1] == "help")
                        {
                            h1(s[1], no);
                        }

                    }
                    Console.Write(">>> ");
                    str = Console.ReadLine().ToLower();
                    no = str;
                    str = str.Trim();
                }
                Environment.Exit(0);

            }


            public void h()
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    Console.WriteLine(arr1[i] + '\t' + arr2[i]);
                }
            }
            public void h1(string y, string z)
            {
                bool found = false;
                for (int i = 0; i < arr1.Length; i++)
                {

                    if (y == arr1[i])
                    {
                        Console.WriteLine(arr1[i] + '\t' + arr2[i]);
                        found = true;
                    }
                }
                if (!found)
                {
                    Console.WriteLine(z + " is not existe");
                }
            }
        }
        class VD
        {
            public void a()
            {

                FileStream f = new FileStream(@"C:\Users\Dell G5\Desktop\kero.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                {
                    byte[] s0 = Encoding.UTF8.GetBytes("0");
                    for (int i = 0; i < 1024; i++)
                    {
                        f.Write(s0, 0, 1);
                    }
                    byte[] s1 = Encoding.UTF8.GetBytes("*");
                    for (int i = 0; i < 4 * 1024; i++)
                    {
                        f.Write(s1, 0, 1);
                    }
                    byte[] s2 = Encoding.UTF8.GetBytes("#");
                    for (int i = 0; i < 1019 * 1024; i++)
                    {
                        f.Write(s2, 0, 1);
                    }
                    f.Close();
                }
            }
            public static byte[] rb(int i)
            {
                FileStream f = new FileStream(@"C:\Users\Dell G5\Desktop\kero.txt", FileMode.Open, FileAccess.ReadWrite);

                byte[] x = new byte[1024];
                f.Seek(1024 * i, SeekOrigin.Begin);
                f.Read(x, 0, 1024);
                f.Close();
                return x;
            }

            public void wb(byte[] y, int i)
            {
                FileStream f = new FileStream(@"C:\Users\Dell G5\Desktop\kero.txt", FileMode.Open, FileAccess.ReadWrite);
                f.Seek(1024 * i, SeekOrigin.Begin);
                f.Write(y, 0, y.Length);
                f.Close();
            }


        }
        class FAT
        {
            static int[] fat = new int[1024];
            public void ifat()
            {
                for (int i = 0; i < 1024; i++)
                {
                    if (i < 5)
                    {
                        fat[i] = -1;
                    }

                }
            }
            public void wfat()
            {
                FileStream f = new FileStream(@"C:\Users\Dell G5\Desktop\kero.txt", FileMode.Open, FileAccess.ReadWrite);
                f.Seek(1024, SeekOrigin.Begin);
                byte[] b = new byte[4 * 1024];
                Buffer.BlockCopy(fat, 0, b, 0, b.Length);
                f.Write(b, 0, b.Length);
                f.Close();
            }
            public void gfat()
            {
                FileStream f = new FileStream(@"C:\Users\Dell G5\Desktop\kero.txt", FileMode.Open, FileAccess.ReadWrite);
                f.Seek(1024, SeekOrigin.Begin);

                byte[] b = new byte[4 * 1024];
                f.Read(b, 0, b.Length);
                for (int i = 0; i < fat.Length; i++)
                {
                    fat[i] = BitConverter.ToInt32(b, i * 4);
                    //Console.WriteLine(fat[i]);
                }
                f.Close();
            }
            public void SN(int i, int x)
            {
                fat[i] = x;
            }
            public int GN(int i)
            {
                return fat[i];
            }
            public static int GAB()
            {
                int i = -1;
                for (i = 0; i < fat.Length; i++)
                    if (fat[i] == 0)
                    {
                        break;
                    }
                return i;
            }

            public static int GABs()
            {
                int x = 0;
                for (int i = 0; i < fat.Length; i++)
                    if (fat[i] == 0)
                    {
                        x++;
                    }
                return x;
            }
        }
        class Directory_Entry
        {
            public char[] file_name = new char[11];
            public byte file_attr;
            public byte[] file_empty = new byte[12];
            public int file_firstCluster;
            public int file_size;

            public Directory_Entry(string file_name, byte file_attr, int file_firstCluster)
            {
                this.file_attr = file_attr;
                this.file_firstCluster = file_firstCluster;
                this.file_name = file_name.ToCharArray();

            }
            public byte[] get_byts()
            {
                byte[] B = new byte[32];
                for (int i = 0; i < 11; i++)
                {
                    B[i] = (byte)file_name[i];
                }
                B[11] = file_attr;
                for (int i = 12; i < 24; i++)
                {
                    B[i] = file_empty[i % 12];
                }
                byte[] fc = BitConverter.GetBytes(file_firstCluster);

                for (int i = 24; i < 28; i++)
                {
                    B[i] = fc[i % 24];
                }
                byte[] sz = BitConverter.GetBytes(file_size);
                for (int i = 28; i < 32; i++)
                {
                    B[i] = sz[i % 28];
                }
                return B;
            }
            public Directory_Entry get_Directory_Entry(byte[] B)
            {
                char[] fileName = new char[11];
                byte fileAttr;
                byte[] fileEmpty = new byte[12];
                int fileFfirstCluster;
                int fileSize;
                for (int i = 0; i < 11; i++)
                {
                    fileName[i] = (char)B[i];
                }
                fileAttr = B[11];
                for (int i = 12; i < 24; i++)
                {
                    fileEmpty[i % 12] = B[i];
                }
                byte[] fc = new byte[4];
                for (int i = 24; i < 28; i++)
                {
                    fc[i % 24] = B[i];
                }
                fileFfirstCluster = BitConverter.ToInt32(fc, 0);
                byte[] sz = new byte[4];
                for (int i = 28; i < 32; i++)
                {
                    sz[i % 28] = B[i];
                }
                fileSize = BitConverter.ToInt32(fc, 0);
                Directory_Entry d = new Directory_Entry(new string(fileName), fileAttr, fileFfirstCluster);
                d.file_empty = fileEmpty;
                d.file_size = fileSize;
                return d;
            }
        }
        class Directory : Directory_Entry
        {
            public List<Directory_Entry> Directory_table;
            public Directory parent;
            public Directory(string file_name, byte file_attr, int file_firstCluster, Directory parent) : base(file_name, file_attr, file_firstCluster)
            {
                Directory_table = new List<Directory_Entry>();
                if (parent != null)
                {
                    this.parent = parent;
                }
            }

            public void write_directory()
            {
                byte[] DTB = new byte[Directory_table.Count * 32];
                double NRB = Math.Ceiling(DTB.Length / 1024.0);
                int remider = DTB.Length % 1024;
                for (int i = 0; i < Directory_table.Count; i++)
                {
                    byte[] DEB = new byte[32];
                    DEB = Directory_table[i].get_byts();
                    for (int j = 32 * i, c = 0; c < 32; c++, j++)
                    {
                        DTB[j] = DEB[j % 32];
                    }
                }
                if (NRB <= FAT.GABs())
                {
                    int fi, li = -1;
                    if (file_firstCluster != 0)
                    {
                        fi = file_firstCluster;
                    }
                    else
                    {
                        fi = FAT.GAB();
                    }
                    for (int i = 0; i < NRB; i++)
                    {
                        VD.rb(i);

                    }
                }
            }
        }
        static void Main(string[] args)
        {

            FAT f = new FAT();
            VD v = new VD();
            if (File.Exists(@"C:\Users\Dell G5\Desktop\kero.txt"))
            {
                v.a();
                f.ifat();
                f.wfat();
            }
            else
            {
                f.gfat();
            }
            help a = new help();
            a.run();


        }
    }

}
