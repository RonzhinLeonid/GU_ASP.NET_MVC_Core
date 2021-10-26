using Les3.Interface;

namespace Les3.Figure
{
    internal sealed class Rectangle : IRectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public double Square { get; private set; }

        public void GqtSquare()
        {
            Square = Width * Height;
        }
    }

}
