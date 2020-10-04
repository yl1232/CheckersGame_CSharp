using System.Collections.Generic;
using System.Linq;

namespace Ex05
{
    public class Move
    {
        private readonly List<Square> m_CapturedSquares;
        private readonly Square m_From;
        private Square m_To;

        public Move(Square i_From, Square i_To)
        {
            m_From = i_From;
            m_To = i_To;
            m_CapturedSquares = new List<Square>();
        }

        public Move(Square i_From)
        {
            m_From = i_From;
            m_CapturedSquares = new List<Square>();
        }

        public Move(Move i_Move)
        {
            m_From = i_Move.From;
            m_To = i_Move.To;
            m_CapturedSquares = i_Move.CapturedSquares;
        }

        public Square From
        {
            get
            {
                return m_From;
            }
        }

        public Square To
        {
            get
            {
                return m_To;
            }

            set
            {
                m_To = value;
            }
        }

        public List<Square> CapturedSquares
        {
            get
            {
                return m_CapturedSquares;
            }
        }

        public override bool Equals(object i_Object)
        {
            if((i_Object == null) || !this.GetType().Equals(i_Object.GetType()))
            {
                return false;
            }
            else
            {
                Move move = (Move)i_Object;
                return m_From.Equals(move.From) && m_To.Equals(move.To) &&
                    (m_CapturedSquares.All(move.CapturedSquares.Contains) &&
                    (m_CapturedSquares.Count == move.CapturedSquares.Count));
            }
        }

        public void AddCapturedSquare(Square i_CapturedSquare)
        {
            m_CapturedSquares.Add(i_CapturedSquare);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
