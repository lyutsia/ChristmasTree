using System.Drawing;

namespace ChristmasTree.PictureObjects
{
    public class Snowman : IPrintable
    {
        private const ConsoleColor ColorHand = ConsoleColor.DarkGray;
        private const ConsoleColor ColorMouth = ConsoleColor.DarkRed;

        private const int BrimHatIndent = 2;

        private int hatHeight;

        private SnowBall smallSnowBall, bigSnowBall;

        public int BigBallHeight { get; set; }
        public int SmallBallHeight { get; set; }

        public ConsoleColor ColorHatButton { get; set; } = ConsoleColor.DarkBlue;
        public ConsoleColor ColorEyes { get; set; } = ConsoleColor.DarkBlue;
        /// <summary>
        /// Левая верхняя точка, начало области вывода снеговика
        /// </summary>
        public Point StartPoint { get; set; }
        public int SnowmanHeight => BigBallHeight + SmallBallHeight + hatHeight - 2;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="leftBottomPoint">левая нижняя точка</param>
        /// <param name="bigBallHeight">высота большого шара</param>
        public Snowman(Point leftBottomPoint, int bigBallHeight)
        {
            BigBallHeight = bigBallHeight;
            SmallBallHeight = bigBallHeight - 2;

            smallSnowBall = new SnowBall(SmallBallHeight);
            bigSnowBall = new SnowBall(BigBallHeight);
            hatHeight = smallSnowBall.Height - 1;

            StartPoint = new Point(leftBottomPoint.X, leftBottomPoint.Y - SnowmanHeight);

            var indent = (bigSnowBall.Width - smallSnowBall.Width) / 2;
            smallSnowBall.StartPoint = new Point(StartPoint.X + indent, StartPoint.Y + hatHeight);
            bigSnowBall.StartPoint = new Point(StartPoint.X, StartPoint.Y + hatHeight + SmallBallHeight - 1);
        }
        public void Print()
        {
            smallSnowBall.Print();
            bigSnowBall.Print();
            PrintHat();
            PrintFace();
            PrintButtons();
            PrintHand();
        }

        public void PrintHat()
        {
            Console.ForegroundColor = ColorHatButton;
            for (var i = -BrimHatIndent; i <= smallSnowBall.Width + BrimHatIndent; i++)
            {
                PrintHelper.PrintPicturePoint(smallSnowBall.StartPoint.X + i, smallSnowBall.StartPoint.Y);
            }
            for (var j = smallSnowBall.StartPoint.Y - 1; j > smallSnowBall.StartPoint.Y - hatHeight; j--)
            {
                for (var i = 0; i < smallSnowBall.Width; i++)
                {
                    PrintHelper.PrintPicturePoint(smallSnowBall.StartPoint.X + i, j);
                }
            }
        }
        private void PrintFace()
        {
            var left = smallSnowBall.Width * 1 / 3;
            var right = smallSnowBall.Width * 2 / 3;
            PrintEyes(left, right);
            PrintMouth(left, right);
        }
        private void PrintEyes(int left, int right)
        {
            var eyesY = smallSnowBall.Height * 1 / 3 + 1;
            Console.ForegroundColor = ColorEyes;
            PrintHelper.PrintPicturePoint(smallSnowBall.StartPoint.X + left, smallSnowBall.StartPoint.Y + eyesY);
            PrintHelper.PrintPicturePoint(smallSnowBall.StartPoint.X + right, smallSnowBall.StartPoint.Y + eyesY);
        }
        private void PrintMouth(int left, int right)
        {
            var mouthY = smallSnowBall.Height * 2 / 3;
            Console.ForegroundColor = ColorMouth;
            for (var i = left + 1; i < right; i++)
                PrintHelper.PrintPicturePoint(smallSnowBall.StartPoint.X + i, smallSnowBall.StartPoint.Y + mouthY);
        }
        private void PrintButtons()
        {
            Console.ForegroundColor = ColorHatButton;
            var top = bigSnowBall.Height * 1 / 3;
            var bottom = bigSnowBall.Height * 2 / 3;

            var buttomWidth = smallSnowBall.Width * 1 / 3 - 1;
            var j = top;
            while (j <= bottom)
            {
                for (int i = 0; i < buttomWidth; i++)
                {
                    PrintHelper.PrintPicturePoint(bigSnowBall.StartPoint.X + (bigSnowBall.Width - buttomWidth) / 2 + i, bigSnowBall.StartPoint.Y + j);
                }
                j += 2;
            }
        }

        private void PrintHand()
        {
            Console.ForegroundColor = ColorHand;
            var handLenght = bigSnowBall.Height / 2;
            for (int j = 0; j < handLenght; j++)
                PrintHandPoint(j);

            PrintHandPoint(handLenght - 1, 1);
        }

        private void PrintHandPoint(int indexY, int incrementX = 0)
        {
            var handY = bigSnowBall.Height / 2;
            PrintHelper.PrintPicturePoint(bigSnowBall.StartPoint.X + bigSnowBall.Width + indexY + incrementX, bigSnowBall.StartPoint.Y + handY - indexY);
            PrintHelper.PrintPicturePoint(bigSnowBall.StartPoint.X - indexY - 1 - incrementX, bigSnowBall.StartPoint.Y + handY - indexY);
        }

    }
}
