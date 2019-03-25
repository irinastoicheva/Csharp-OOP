namespace Shapes
{
    using System.Text;

    public class Rectangle : IDrawable
    {
        private int width;
        private int height;
        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public string Draw()
        {
            StringBuilder sb = new StringBuilder();
           DrowLine(this.Width, '*', '*', sb);
            for (int i = 1; i < this.Height - 1; i++)
            {
                DrowLine(this.Width, '*', ' ', sb);
            }

            DrowLine(this.Width, '*', '*', sb);
            return sb.ToString();
        }

        private string DrowLine(int width, char end, char mid, StringBuilder sb)
        {
            sb.Append(end);
            for (int i = 1; i < this.Width - 1; i++)
            {
                sb.Append(mid);
            }

            sb.AppendLine(end.ToString());
            return sb.ToString();
        }
    }
}
