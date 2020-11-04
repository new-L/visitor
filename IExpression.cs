using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
    public interface IExpression
    {
        public T Accept<T>(IVisitor<T> visitor);
    }
}
