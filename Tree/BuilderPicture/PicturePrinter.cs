namespace ChristmasTree.BuilderPicture
{
    public class PicturePrinter
    {
        private PictureBuilder pictureBuilder;
        public PicturePrinter(PictureBuilder pictureBuilder)
        {
            this.pictureBuilder = pictureBuilder;
        }

        /// <summary> Вывод изображения.</summary>
        public void Display()
        {
            pictureBuilder.CreatePicture();
            pictureBuilder.SnowflakePrint();
            pictureBuilder.StarPrint();
            pictureBuilder.TreePrint();
            pictureBuilder.SnowmanPrint();
            pictureBuilder.PresentsPrint();
            pictureBuilder.SnowPrint();
            pictureBuilder.FlickerOnePointPictures();
        }
    }
}
