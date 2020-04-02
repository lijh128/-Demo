namespace PieceToStock
{
    public class Piece
    {
        public Piece()
        {
        }

        private decimal length;
        private string label;
        private bool isArranged = false;
        public decimal cuttingLegnth ;

        public string Label { get => label; set => label = value; }
        public decimal Length { get => length; set => length = value; }
        public bool IsArranged { get => isArranged; set => isArranged = value; }

        public override string ToString()
        {

            return "(标签:" +label + ";长度:" + length.ToString() +")";
        }
    }


}
