using ChristmasTree.PictureObjects;

namespace ChristmasTree.BuilderSnowman
{
    public class CristmasSnowmanBuilder : SnowmanBuilder
    {
        public override void PrintHat()
        {
            Console.ForegroundColor = SnowmanObj.ColorHatButton;
            for (var i = -Snowman.BrimHatIndent; i <= SnowmanObj.SmallSnowBall.Width + Snowman.BrimHatIndent; i++)
            {
                PrintHelper.PrintPicturePoint(SnowmanObj.SmallSnowBall.StartPoint.X + i, SnowmanObj.SmallSnowBall.StartPoint.Y);
            }
            for (var j = SnowmanObj.SmallSnowBall.StartPoint.Y - 1; j > SnowmanObj.SmallSnowBall.StartPoint.Y - SnowmanObj.HatHeight; j--)
            {
                for (var i = 0; i < SnowmanObj.SmallSnowBall.Width; i++)
                {
                    PrintHelper.PrintPicturePoint(SnowmanObj.SmallSnowBall.StartPoint.X + i, j);
                }
            }
        }

        #region Snowman Face
        public override void PrintFace()
        {
            var left = SnowmanObj.SmallSnowBall.Width * 1 / 3;
            var right = SnowmanObj.SmallSnowBall.Width * 2 / 3;
            PrintEyes(left, right);
            PrintMouth(left, right);
        }

        /// <summary> Вывод глаз.</summary>
        private void PrintEyes(int left, int right)
        {
            var eyesY = SnowmanObj.SmallSnowBall.Height * 1 / 3 + 1;
            Console.ForegroundColor = SnowmanObj.ColorEyes;
            PrintHelper.PrintPicturePoint(SnowmanObj.SmallSnowBall.StartPoint.X + left, SnowmanObj.SmallSnowBall.StartPoint.Y + eyesY);
            PrintHelper.PrintPicturePoint(SnowmanObj.SmallSnowBall.StartPoint.X + right, SnowmanObj.SmallSnowBall.StartPoint.Y + eyesY);
        }

        /// <summary> Вывод рта.</summary>
        private void PrintMouth(int left, int right)
        {
            var mouthY = SnowmanObj.SmallSnowBall.Height * 2 / 3;
            Console.ForegroundColor = Snowman.ColorMouth;
            for (var i = left + 1; i < right; i++)
                PrintHelper.PrintPicturePoint(SnowmanObj.SmallSnowBall.StartPoint.X + i, SnowmanObj.SmallSnowBall.StartPoint.Y + mouthY);
        }
        #endregion

        public override void PrintButtons()
        {
            Console.ForegroundColor = SnowmanObj.ColorHatButton;
            var top = SnowmanObj.BigSnowBall.Height * 1 / 3;
            var bottom = SnowmanObj.BigSnowBall.Height * 2 / 3;

            var buttomWidth = SnowmanObj.SmallSnowBall.Width * 1 / 3 - 1;
            var j = top;
            while (j <= bottom)
            {
                for (int i = 0; i < buttomWidth; i++)
                {
                    PrintHelper.PrintPicturePoint(SnowmanObj.BigSnowBall.StartPoint.X + (SnowmanObj.BigSnowBall.Width - buttomWidth) / 2 + i, SnowmanObj.BigSnowBall.StartPoint.Y + j);
                }
                j += 2;
            }
        }

        #region Snowman Hand
        public override void PrintHand()
        {
            Console.ForegroundColor = Snowman.ColorHand;
            var handLenght = SnowmanObj.BigSnowBall.Height / 2;
            for (int j = 0; j < handLenght; j++)
                PrintHandPoint(j);

            PrintHandPoint(handLenght - 1, 1);
        }

        private void PrintHandPoint(int indexY, int incrementX = 0)
        {
            var handY = SnowmanObj.BigSnowBall.Height / 2;
            PrintHelper.PrintPicturePoint(SnowmanObj.BigSnowBall.StartPoint.X + SnowmanObj.BigSnowBall.Width + indexY + incrementX, SnowmanObj.BigSnowBall.StartPoint.Y + handY - indexY);
            PrintHelper.PrintPicturePoint(SnowmanObj.BigSnowBall.StartPoint.X - indexY - 1 - incrementX, SnowmanObj.BigSnowBall.StartPoint.Y + handY - indexY);
        }
        #endregion
    }
}
