using ChristmasTree.BuilderSnowman;
using ChristmasTree.PictureObjects;
using System.Drawing;

namespace ChristmasTree.BuilderPicture
{
    public class ChristmasTreePictureBuilder : PictureBuilder
    {
        private Random random = new Random();
        private int pictureEnd;

        public override void StarPrint()
        {
            var star = new Star(PictureConstans.StarHeight);
            star.Print();
        }

        public override void TreePrint()
        {
            PictureObj.Tree = new Tree(PictureConstans.StarHeight + TreeWindow.StartHeight - 1, PictureConstans.TreeTriangleCount);
            PictureObj.Tree.Print();
            pictureEnd = PictureConstans.StarHeight + TreeWindow.StartHeight + PictureObj.Tree.TreeHeight + PictureObj.Tree.TrunkHeight - 1;
        }

        public override void SnowflakePrint()
        {
            for (int j = 0; j < TreeWindow.Height; j++)
            {
                int ind = 0;
                while (ind < PictureConstans.SnowflakeCountInRow)
                {
                    var x = random.Next(1, TreeWindow.Width - 1);
                    if (Picture.OnePointPictures.Any(f => Math.Abs(f.Point.X - x) <= PictureConstans.MinIntervalSnowflake && f.Point.Y == j || f.Point.X == x && f.Point.Y == j - 1))
                        continue;
                    var snowflake = new Snowflake(x, j);
                    Picture.OnePointPictures.Add(snowflake);
                    snowflake.Print();
                    ind++;
                }
            }
        }

        #region Presents
        public override void PresentsPrint()
        {
            var presentY = pictureEnd - PictureConstans.PresentHeight;
            var presentLeftX = TreeWindow.CenterWidth - PictureObj.Tree.TrunkWidth / 2;
            var presentRightX = TreeWindow.CenterWidth + PictureObj.Tree.TrunkWidth / 2;

            for (int i = 0; i < PictureConstans.PresentCount / 2; i++)
            {
                //подарки слева
                var present = GetPresent();
                presentLeftX = presentLeftX - PictureConstans.PresentInterval - present.PresentWidth;
                PresentPrint(present, presentLeftX, presentY - present.BowHeight);

                //подарки справа
                present = GetPresent();
                presentRightX += PictureConstans.PresentInterval;
                PresentPrint(present, presentRightX, presentY - present.BowHeight);
                presentRightX += present.PresentWidth;
            }
        }

        private Present GetPresent()
        {
            var bowColor = PictureConstans.BowColors[random.Next(0, PictureConstans.BowColors.Count())];
            var presentColor = PictureConstans.PresentColors[random.Next(0, PictureConstans.PresentColors.Count())];
            return new Present(PictureConstans.PresentHeight, (ConsoleColor)presentColor, (ConsoleColor)bowColor);
        }

        private void PresentPrint(Present present, int presentX, int presentY)
        {
            present.StartPoint = new Point(presentX, presentY);
            present.Print();
        }
        #endregion

        public override void SnowmanPrint()
        {
            var cristmasSnowmanBuilder = new CristmasSnowmanBuilder();
            var snowmenPrinter = new SnowmenPrinter(cristmasSnowmanBuilder);
            snowmenPrinter.Display(new Point(TreeWindow.Width / 7, pictureEnd), PictureConstans.BigSnowballHeight);
        }

        public override void SnowPrint()
        {
            Console.ForegroundColor = ConsoleColor.White;

            for (int j = 0; j < PictureConstans.SnowHeight; j++)
            {
                for (int i = 0; i < TreeWindow.Width; i++)
                {
                    PrintHelper.PrintPicturePoint(i, pictureEnd + j);
                }
            }
        }

        public override void FlickerOnePointPictures()
        {
            while (true)
            {
                var index = random.Next(0, Picture.OnePointPictures.Count());
                (Picture.OnePointPictures[index] as IPrintable)?.Print();
            }
        }
    }
}
