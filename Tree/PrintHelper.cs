namespace ChristmasTree
{
    public static class PrintHelper
    {
        public static void PrintPicturePoint(int x, int y)
        {
            //чтобы снежинки не перекрывали основные рисунки
            Picture.Flashlights.RemoveAll(s => s.Point.X == x && s.Point.Y == y);
            Print(x, y);
        }

        public static void Print(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            PrintSymbol();
        }

        public static void PrintFlashlight(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            PrintSymbol('☻');
        }

        public static void PrintSymbol(char sym = '*')
        {
            Console.Write(sym);
        }
    }
}
