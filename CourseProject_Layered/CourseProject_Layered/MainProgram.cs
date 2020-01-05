using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DBI;
using System.IO;

namespace CourseProject_Layered
{
    interface IDB_Write
    {
        void WriteToDB(DB_interface DBI_obj);
    }

    interface IDB_Read
    {
        object[] ReadFromDB(DB_interface DBI_obj);
    }

    enum SocketType { AM2, AM3, AM4, LGA_1151, LGA_1150, LGA_1155, LGA_2011, LGA_775, LGA_1156, LGA_1366 };
    enum Manufacturer { Asus, MSI, Gigabyte, EVGA, Biostar, ASRock };
    enum RAM_Type { DDR2, DDR3, DDR4 };
    enum PeripheralType { Mouse, Keyboard, Printer, Webcam, Microphone, Headphones }
    enum DB_ConstructorMode { InFolder, OFD }

    static class MainProgram
    {
        /// <summary>
        /// App entry point.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //################################## tests start

            //File.Copy(@"D:\Documents\Ayrum\3 курс\SPZ\CP\CourseProject_Layered\CourseProject_Layered\DB\CPDatabase.mdf", "MyDatabase.mdf");

            DBI.DB_interface dbi = new DBI.DB_interface(DB_ConstructorMode.InFolder);

            RAM ram1 = new RAM(1, 300, 2200, RAM_Type.DDR3, 2);
            RAM ram2 = new RAM(2, 450, 2400, RAM_Type.DDR4, 4);
            ram1.WriteToDB(dbi);
            ram2.WriteToDB(dbi);

            var a = ram1.ReadFromDB(dbi);

            dbi.ClearTable("RAMs");

            //################################## tests end

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ComputerPartsForm());
        }
    }
}
