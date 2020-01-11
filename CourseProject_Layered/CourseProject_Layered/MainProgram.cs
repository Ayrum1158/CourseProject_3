using System.Windows.Forms;
using DBI;

namespace CourseProject_Layered
{
    public interface IDB_Write
    {
        bool WriteToDB(DB_interface DBI_obj);
    }

    public interface IDB_Read
    {
        object[] ReadFromDB(DB_interface DBI_obj);
    }

    public enum SocketType { AM2, AM3, AM4, LGA_1151, LGA_1150, LGA_1155, LGA_2011, LGA_775, LGA_1156, LGA_1366 };
    public enum Manufacturer { Asus, MSI, Gigabyte, EVGA, Biostar, ASRock };
    public enum RAM_Type { DDR2, DDR3, DDR4 };
    public enum PeripheralType { Mouse, Keyboard, Printer, Webcam, Microphone, Headphones }
    public enum DB_ConstructorMode { InFolder, OFD }



    static class MainProgram
    {
        /// <summary>
        /// App entry point.
        /// </summary>
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ComputerPartsForm());
        }
    }
}
