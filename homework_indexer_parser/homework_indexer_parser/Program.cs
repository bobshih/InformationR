using System;
using System.Windows.Forms;

namespace InformationRetrieval
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new QueryForm().Show();
            new IndexingFrom().Show();
            Application.Run();
        }
    }
}
