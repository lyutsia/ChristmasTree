namespace ChristmasTree.PictureObjects
{
    public class Star : IPrintable
    {
        private const ConsoleColor Color = ConsoleColor.DarkRed;
        public int Height { get; set; }
        public int Width => Height % 2 == 0 ? Height + 1 : Height;

        public Star(int height)
        {
            Height = height;
        }

        public void Print()
        {
            Console.ForegroundColor = Color;
            var end = TreeWindow.CenterWidth + Width / 2;
            var start = TreeWindow.CenterWidth - Width / 2;
            var indent = Width / 2 + 1;
            var widthLimbStart = 0;
            for (int j = 0; j < Height; j++)
            {
                if (j == Height * 1 / 3)//максимальная ширина, когда 2 противополжных конца звезды на одной линии
                {
                    indent = 0;
                }
                else if (j < Height * 1 / 3)//верхушка звезды
                {
                    indent--;
                }
                else if (j == Height * 1 / 3 + 1)//начинало вывода нижних концов звезды
                {
                    indent = 1;
                    widthLimbStart = Width / 2 - 1;
                }
                else if (j > Height * 1 / 3 + 1)//уменьшаем ширину нижних концов звезды
                {
                    widthLimbStart--;
                }
                for (var i = start + indent; i <= end - indent; i++)
                {
                    if (j <= Height * 1 / 3 + 1 || (i <= start + indent + widthLimbStart || i >= end - indent - widthLimbStart))
                        PrintHelper.PrintPicturePoint(i, TreeWindow.StartHeight + j);
                }
            }
        }
    }
}
