namespace CW
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();//инициализируем настройки формы
            Application.Run(new MainForm());//запускаем приложение, выводя форму
        }
    }
}