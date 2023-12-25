namespace ChristmasTree.BuilderPicture
{
    public abstract class PictureBuilder
    {
        public Picture PictureObj { get; private set; }
        public void CreatePicture()
        {
            PictureObj = new Picture();
        }

        /// <summary> Вывод звезды.</summary>
        public abstract void StarPrint();

        /// <summary> Вывод елки.</summary>
        public abstract void TreePrint();

        /// <summary> Вывод снежинок.</summary>
        public abstract void SnowflakePrint();

        /// <summary> Вывод подарков.</summary>
        public abstract void PresentsPrint();

        /// <summary> Вывод снега.</summary>
        public abstract void SnowPrint();

        /// <summary> Вывод снеговика.</summary>
        public abstract void SnowmanPrint();

        /// <summary> Мерцание снежинок и фонариков.</summary>
        public abstract void FlickerOnePointPictures();
    }
}
