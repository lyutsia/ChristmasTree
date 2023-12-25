using ChristmasTree.PictureObjects;
using System.Drawing;

namespace ChristmasTree.BuilderSnowman
{
    public abstract class SnowmanBuilder
    {
        public Snowman SnowmanObj { get; private set; }
        public void CreateSnowman(Point leftBottomPoint, int bigBallHeight)
        {
            SnowmanObj = new Snowman(leftBottomPoint, bigBallHeight);
        }
        /// <summary> Вывод шляпы.</summary>
        public abstract void PrintHat();

        /// <summary> Вывод лица.</summary>
        public abstract void PrintFace();

        /// <summary> Вывод пуговиц.</summary>
        public abstract void PrintButtons();

        /// <summary> Вывод рук.</summary>
        public abstract void PrintHand();
    }
}
