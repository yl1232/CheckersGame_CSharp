namespace Ex05
{
    public struct Square
    {
        private readonly int m_Row;
        private readonly int m_Column;

        public Square(int i_Row, int i_Column)
        {
            m_Row = i_Row;
            m_Column = i_Column;
        }

        public override bool Equals(object i_Object)
        {
            if((i_Object == null) || !this.GetType().Equals(i_Object.GetType()))
            {
                return false;
            }
            else
            {
                Square square = (Square)i_Object;
                return (m_Row == square.Row) && (m_Column == square.Column);
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int Row
        {
            get
            {
                return m_Row;
            }
        }

        public int Column
        {
            get
            {
                return m_Column;
            }
        }
    }
}
