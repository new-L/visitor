using System;

namespace Visitor
{
    class Program
    {
        static void Main()
        {
            IExpression expression = new BinaryOperation(new Brackets(new BinaryOperation(new Literal(10), new Literal(2), "*")), new Literal(67), "+");
            IExpression newExpression = new BinaryOperation(new Brackets(new BinaryOperation(new Literal(10), new Literal(2), "*")), new Brackets(new BinaryOperation(new Literal(1000), new Literal(500), "/")), "-");
            PrintExpression _printExpression = new PrintExpression();

            expression.Accept(_printExpression);
            Console.WriteLine("Выражение: {0}",_printExpression._expression);

            _printExpression._expression = "";

            newExpression.Accept(_printExpression);
            Console.WriteLine("Выражение: {0}", _printExpression._expression);

            Console.ReadKey();
        }
    }

    public class Literal : IExpression
    {
        public int _value;

        public Literal(int value)
        {
            _value = value;
        }

        public T Accept<T>(IVisitor<T> visitor) => visitor.Visit(this);
    }

    public class BinaryOperation : IExpression
    {
        public IExpression _left;
        public IExpression _right;
        public string _symbol;

        public BinaryOperation(IExpression left, IExpression right, string symbol)
        {
            _left = left;
            _right = right;
            _symbol = symbol;
        }

        public T Accept<T>(IVisitor<T> visitor) => visitor.Visit(this);
    }

    public class Brackets : IExpression
    {
        public IExpression _innerExpression;

        public Brackets(IExpression innerExpression)
        {
            _innerExpression = innerExpression;
        }

        public T Accept<T>(IVisitor<T> visitor) => visitor.Visit(this);
    }




    class PrintExpression : IVisitor<string>
    {
        public string _expression;

        public string Visit(Literal expression)
        {
            _expression = _expression + expression._value;
            return _expression;
        }

        public string Visit(BinaryOperation expression)
        {
            expression._left.Accept(this);
            _expression = _expression + expression._symbol;
            expression._right.Accept(this);
            return _expression;
        }

        public string Visit(Brackets expression)
        {
            _expression = _expression + "(";
            expression._innerExpression.Accept(this);
            _expression = _expression + ")";
            return _expression;
        }
    }


}
