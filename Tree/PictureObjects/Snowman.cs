using System.Drawing;

namespace ChristmasTree.PictureObjects
{
    public class Snowman
    {
        public const ConsoleColor ColorHand = ConsoleColor.DarkGray;
        public const ConsoleColor ColorMouth = ConsoleColor.DarkRed;
        /// <summary> Отступ для полей шляпы.</summary>
        public const int BrimHatIndent = 2;

        public int HatHeight { get; private set; }
        public SnowBall SmallSnowBall { get; private set; }
        public SnowBall BigSnowBall { get; private set; }
        public int BigBallHeight { get; set; }
        public int SmallBallHeight { get; set; }
        public ConsoleColor ColorHatButton { get; set; } = ConsoleColor.DarkBlue;
        public ConsoleColor ColorEyes { get; set; } = ConsoleColor.DarkBlue;
        /// <summary> Левая верхняя точка, начало области вывода снеговика.</summary>
        public Point StartPoint { get; set; }
        public int SnowmanHeight => BigBallHeight + SmallBallHeight + HatHeight - 2;

        public Snowman(Point leftBottomPoint, int bigBallHeight)
        {
            BigBallHeight = bigBallHeight;
            SmallBallHeight = bigBallHeight - 2;

            SmallSnowBall = new SnowBall(SmallBallHeight);
            BigSnowBall = new SnowBall(BigBallHeight);
            HatHeight = SmallSnowBall.Height - 1;

            //устанавливаем левую верхнюю точку
            StartPoint = new Point(leftBottomPoint.X, leftBottomPoint.Y - SnowmanHeight);

            var indent = (BigSnowBall.Width - SmallSnowBall.Width) / 2;
            SmallSnowBall.StartPoint = new Point(StartPoint.X + indent, StartPoint.Y + HatHeight);
            BigSnowBall.StartPoint = new Point(StartPoint.X, StartPoint.Y + HatHeight + SmallBallHeight - 1);
        }
    }
}
