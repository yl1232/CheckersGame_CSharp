using System.Windows.Forms;

namespace Ex05
{
    public class CheckersButton : Button
    {
        private readonly Square m_Coordinates;

        public CheckersButton(int i_Row, int i_Column)
        {
            m_Coordinates = new Square(i_Row, i_Column);
        }

        public Square Coordinates
        {
            get
            {
                return m_Coordinates; 
            }
        }
    }
}
