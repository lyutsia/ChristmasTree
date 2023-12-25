using System.Drawing;

namespace ChristmasTree.PictureObjects
{
    public class SnowBall : IPrintable
    {
        private const ConsoleColor ColorSnow = ConsoleColor.White;

        /// <summary>
        /// Количество строк в центре, когда ширина максимальная.
        /// Сначала идет увеличение до достижения максимальной ширины,затем уменьшение.
        /// </summary>
        private int rowCountInCenterWithMaxWidth;

        /// <summary> Левая верзняя точка.</summary>
        public Point StartPoint { get; set; }
        public int Height { get; set; }
        public int Width => Height * 2;// чтобы сохранять примерные пропорции окружности

        public SnowBall(int height)
        {
            Height = height;
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

