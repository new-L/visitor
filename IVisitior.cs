using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
    public interface IVisitor<out T>
    {
        public T Visit(Literal expression);
        public T Visit(BinaryOperation expression);
        public T Visit(Brackets expression);
    }
}
