using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedParanthesis
{
    public class ParanthesisComparer : EqualityComparer<Char>
    {
        public static readonly ParanthesisComparer _paranthesisComparer = new ParanthesisComparer();

        private ParanthesisComparer() { }

        public static ParanthesisComparer instance {  get { return _paranthesisComparer;} }

        public override bool Equals(char x, char y)
        {
            if (x == Constants.openCurly && y == Constants.closedCurly)
                return true;
            if (x == Constants.openNormal && y == Constants.closedNormal)
                return true;
            if (x == Constants.openSquare && y == Constants.closedSquare)
                return true;

            return false;
        }

        public override int GetHashCode(char obj)
        {
            throw new NotImplementedException();
        }
    }
}
