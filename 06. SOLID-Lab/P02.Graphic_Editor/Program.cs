using System;

namespace P02.Graphic_Editor
{
    public class Program
    {
        public static void Main()
        {
            GraphicEditor graphicEditor = new GraphicEditor();

            Square square = new Square();

            graphicEditor.DrawShape(square);

            graphicEditor.DrawShape(new Rectangle());
        }
    }
}
