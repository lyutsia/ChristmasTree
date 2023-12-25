namespace ChristmasTree.PictureObjects
{
    public class Star : IPrintable
    {
        private const ConsoleColor Color = ConsoleColor.DarkRed;

        public int Height { get; set; }

        public int Width => Height % 2 == 0 ? Height + 1 : Height;// ширина должна быть нечетным значением, чтобы верхушка звезды была в центре

        public Star(int height)
        {
            Height = height;
        }

        public void Print()
        {
            Console.ForegroundColor = Color;
            var end = TreeWindow.CenterWidth + Width / 2;
            var start = TreeWindow.CenterWidth - Width / 2;
            var thirdPartHeight = Height / 3;
            var indent = Width / 2 + 1;
            var widthLimbStart = 0;
            for (int j = 0; j < Height; j++)
            {
                if (j == thirdPartHeight)//максимальная ширина, когда 2 противополжных конца звезды на одной линии
                {
                    indent = 0;
                }
                else if (j < thirdPartHeight)//верхушка звезды
                {
                    indent--;
                }
                else if (j == thirdPartHeight + 1)//начинало вывода нижних концов звезды
                {
                    indent = 1;
                    widthLimbStart = Width / 2 - 1;
                }
                else if (j > thirdPartHeight + 1)//уменьшаем ширину нижних концов звезды
                {
                    widthLimbStart--;
                }

                for (var i = start + indent; i <= end - indent; i++)
                {
                    if (j <= thirdPartHeight + 1 || (i <= start + indent + widthLimbStart || i >= end - indent - widthLimbStart))
                        PrintHelper.PrintPicturePoint(i, TreeWindow.StartHeight + j);
                }
            }
        }
    }
}
