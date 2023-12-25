using ChristmasTree;
using ChristmasTree.BuilderPicture;

TreeWindow.ChangeWindowSizeAndPosition();
var christmasTreePictureBuilder = new ChristmasTreePictureBuilder();
var picturePrinter = new PicturePrinter(christmasTreePictureBuilder);
picturePrinter.Display();