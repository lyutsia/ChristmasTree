using System.Drawing;

namespace ChristmasTree.PictureObjects
{
    public class SnowBall : IPrintable
    {
        private const ConsoleColor ColorSnow = ConsoleColor.White;
        /// <summary>
        /// количество строк в центре, когда ширина максимальная
        /// сначала идет увеличение до достижения максимальной ширины,затем уменьшение
        /// </summary>
        private int rowCountInCenterWithMaxWidth;
        public Point StartPoint { get; set; }
        public int Height { get; set; }
        public int Width { get; private set; }

        public SnowBall(int height)
        {
            Height = height;
            Width = height * 2;// чтобы сохранять примерные пропорции окружности
            rowCountInCenterWithMaxWidth = (height % 2 == 0) ? 2 : 3;
        }

        public void Print()
        {
            Console.ForegroundColor = ColorSnow;

            var indent = 2 * (Height - rowCountInCenterWithMaxWidth) / 2;
            var rowCountInCenter = 1;
            var step = 2;
            for (var j = 0; j < Height; j++)
            {
                for (var i = indent; i < Width - indent; i++)
                {
                    PrintHelper.PrintPicturePoint(StartPoint.X + i, StartPoint.Y + j);
                }

                if (indent == 0 && rowCountInCenter < rowCountInCenterWithMaxWidth)
                    rowCountInCenter++;
                else if (rowCountInCenter == rowCountInCenterWithMaxWidth)
                    indent += step;
                else
                    indent -= step;
            }
        }
    }
}

