using System.Runtime.InteropServices;

namespace ChristmasTree
{
    public class TreeWindow
    {
        private const int SWP_NOSIZE = 0x0001;
        /// <summary>
        /// абцисса левого верхнего угла консольного окна
        /// </summary>
        private const int XPos = 50;
        /// <summary>
        /// ордината левого верхнего угла консольного окна
        /// </summary>
        private const int YPos = 5;

        public static int Width => 150;
        public static int Height => 50;
        public static int CenterWidth => Width / 2;
        /// <summary>
        /// ордината, с которой начинается изображение
        /// </summary>
        public static int StartHeight => 2;

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        private static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        private static IntPtr ConsoleTreeWindow = GetConsoleWindow();

        /// <summary>
        /// меняем размер и расположение консольного окна
        /// </summary>
        public static void ChangeWindowSizeAndPosition()
        {
            SetWindowPos(ConsoleTreeWindow, 0, XPos, YPos, 0, 0, SWP_NOSIZE);
            Console.SetWindowSize(Width, Height);
        }
    }
}
