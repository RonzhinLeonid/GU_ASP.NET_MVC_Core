namespace Les4.Adapter
{
    public interface IData
    {
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        void Print();
    }
}
