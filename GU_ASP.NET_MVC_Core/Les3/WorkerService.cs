using Les3.Interface;

namespace Les3
{
    internal sealed class WorkerService
    {
        public void CalculateSquare(IFigure summaryItem)
        {
            summaryItem.GqtSquare();
        }
    }

}
