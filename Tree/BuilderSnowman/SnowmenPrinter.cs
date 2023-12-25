using System.Drawing;

namespace ChristmasTree.BuilderSnowman
{
    public class SnowmenPrinter
    {
        private SnowmanBuilder snowmanBuilder;
        public SnowmenPrinter(SnowmanBuilder snowmanBuilder)
        {
            this.snowmanBuilder = snowmanBuilder;
        }

        /// <summary> Вывод снеговика.</summary>
        public void Display(Point leftBottomPoint, int bigBallHeight)
        {
            snowmanBuilder.CreateSnowman(leftBottomPoint, bigBallHeight);
            snowmanBuilder.SnowmanObj.SmallSnowBall.Print();
            snowmanBuilder.SnowmanObj.BigSnowBall.Print();
            snowmanBuilder.PrintHat();
            snowmanBuilder.PrintFace();
            snowmanBuilder.PrintButtons();
            snowmanBuilder.PrintHand();
        }
    }
}
