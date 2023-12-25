using System.Drawing;

namespace ChristmasTree.PictureObjects
{
    /// <summary> Абстрактный класс для изображений, состоящих из одной точки. </summary>
    public abstract class OnePointPicture
    {
        /// <summary> Координаты точки изображения.</summary>
        public Point Point { get; set; }
    }
}
