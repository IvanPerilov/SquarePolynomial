using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Квадратное_уравнение
{
    /// <summary>
    /// Это класс квадратных многочленов или степенью ниже.
    /// </summary>
    internal class SquarePolynomial
    {
        /// <summary>
        /// Эта переменная отвечает за коэффициент перед x^2.
        /// </summary>
        private double a;
        public double A 
        {
            get { return a; }
            set 
            {
                if (value == 0) Console.WriteLine("Ошибка! Коэффициент перед x^2 не может быть равен 0.");
                else a = value;
            }
        }
        /// <summary>
        /// Эта переменная отвечает за коэффициент перед x.
        /// </summary>
        private double b;
        public double B
        {
            get { return b; }
            set
            {
                b = value;
            }
        }
        /// <summary>
        /// Эта переменная отвечает за коэффициент свободного члена.
        /// </summary>
        private double c;
        public double C 
        {
            get { return c; }
            set 
            {
                c = value;
            }
        }
        /// <summary>
        /// Дискриминант.
        /// </summary>
        private double D;
        public double Discriminant
        {
            get { return D; }
            set { }
        }
        /// <summary>
        ///Первый корень 
        /// </summary>
        private double x1;
        public double X1
        {
            get { return x1; }
            set { }
        }
        /// <summary>
        /// Второй корень
        /// </summary>
        private double x2;        
        public double X2
        {
            get { return x2; }
            set { }
        }
        public SquarePolynomial()
        {
            a = 1;
            b = 2;
            c = 1;
        }
        /// <summary>
        /// Ввод квадартного уравнение через строку
        /// </summary>
        /// <param name="squarePolynomial">Строка, где дложно быть квадратное уравнение:"ax^2+bx+c</param>
        public SquarePolynomial(string squarePolynomial)
        {
            StringBuilder text = new StringBuilder(squarePolynomial);
            text.Replace(" ", "");
            a = RecordingСoefficient(ref text);
            if (a == 0)
            {
                Console.WriteLine("Ошибка! Коэффициент при x^2 равен нулю");
                return;
            }
            if ((text.ToString()).IndexOf("x", 0) != -1)
                b = RecordingСoefficient(ref text);
            if ((text.Length != 0) && ((text[0] == '-') || (text[0] == '+')))
                c = RecordingСoefficient(ref text);
        }
        /// <summary>
        /// Считывание первого коэффициента из строки. Далее идёт к началу следующего и удоляет все, что сзади.
        /// </summary>
        /// <param name="text">Строка, где в начале стоит необходимый коэффициент.</param>
        /// <returns>Возвращает коэффициент, уже переведённый в dobule</returns>
        private double RecordingСoefficient(ref StringBuilder text)
        {
            StringBuilder buff = new StringBuilder();
            int i = 0;
            while ((i < text.Length) && (text[i] != 'x') && (text[i] != '*'))
            {
                buff.Append(text[i]);
                i++;
            }
            buff.Replace("+", "");
            if (buff.ToString() == "")
            {
                buff.Append("1");
            }
            if (buff.ToString() == "-")
            {
                buff.Append("-1");
            }
            while ((i < text.Length) && (text[i] != '+') && (text[i] != '-')) i++;
            text.Remove(0, i);
            return double.Parse(buff.ToString());
        }
        /// <summary>
        /// Прямой ввод значений коэфициентов
        /// </summary>
        /// <param name="value1">Соответсвует коэффициенту перед x^2.</param>
        /// <param name="value2">Соответсвует коэффициенту перед x.</param>
        /// <param name="value3">Соответсвует коэффициенту свободного члена.</param>
        public SquarePolynomial (double value1,  double value2, double value3)
        {
            if(value1==0) 
            {
                Console.WriteLine("Ошибка! Коэффициент при x^2 равен нулю");
            }
            else
            {
                a = value1;
                b = value2;
                c = value3;
            }
        }
        private void FindDiscriminant()
        {
            D = b * b - 4 * c * a;
        }
        public void Solve(int roundingDegree = 3)
        {
            FindDiscriminant();
            if (D >= 0) FindX(roundingDegree);
        }
        /// <summary>
        /// Находит корни уравнения
        /// </summary>
        /// <param name="roundingDegree">Округления до n знаков после запятой</param>
        private void FindX(int roundingDegree = 3)
        {
            if (D > 0)
            {
                double tmp2 = Math.Sqrt(D) / (2 * a);
                double tmp1 = -b / (2 * a);
                x1 = Math.Round(tmp1 + tmp2, roundingDegree);
                x2 = Math.Round(tmp1 - tmp2, roundingDegree);
            }
            else
            {
                x1 = -b/ (2 * a);
                x2 = x1;
            }
        }
        /// <summary>
        /// Выводит квадратное уравнение.
        /// </summary>
        public void Print()
        {
            StringBuilder buff = new StringBuilder();
            if (a == 1) buff.Append("x^2");
            else
            {
                if (a == -1) buff.Append("- x^2");
                else
                {
                    if (a > 0) buff.Append($"{a} * x^2");
                    else buff.Append($"- {-a} * x^2");
                }
            }
            if (b != 0)
            {
                buff.Append(" ");
                if (b == 1) buff.Append("+ x");
                else
                {
                    if (b == -1) buff.Append("- x");
                    if (b > 0) buff.Append($"+ {b} * x");
                    else buff.Append($"- {-b} * x");
                }             
            }
            if (c != 0)
            {
                buff.Append(" ");
                if (c > 0) buff.Append($"+ {c}");
                else buff.Append($"- {-c}");
            }
            buff.Append(" = 0");
            Console.WriteLine(buff.ToString());
        }

        private void PrintDiscriminant()
        {
            Console.WriteLine("D = " + D);
        }
        /// <summary>
        /// Необходимо в представлении квадратного уравнения в виде произведения корней
        /// </summary>
        /// <param name="x">Один из двух корней</param>
        /// <param name="numberOfRoot">Номер корня</param>
        /// <returns></returns>
        private string PrintAlternativeSquarePolynomial(double x, int numberOfRoot)
        {
            StringBuilder buff = new StringBuilder();
            if (x > 0) buff.Append($"(x - {x1})");
            else
            {
                if (x < 0) buff.Append($"(x + {-x1})");
                else
                {
                    if (numberOfRoot == 1) buff.Append("x * ");
                    else buff.Append("x");
                }
            }
            return buff.ToString();
        }
        /// <summary>
        /// Выводит решение
        /// </summary>
        /// <param name="printDiscriminant">Показать дискриминант</param>
        /// <param name="printSquarePolynomial">Показать квадратное уравнение.</param>
        /// <param name="printAlternativeSquarePolynomial">Показать квадартное уравнение в виде произведения корней.</param>
        public void PrintResult(bool printDiscriminant = true, bool printSquarePolynomial = true, bool printAlternativeSquarePolynomial = false)
        {
            if (printSquarePolynomial) Print();
            if (printDiscriminant) PrintDiscriminant();
            if (D > 0)
            {
                Console.WriteLine($"x1 = {x1};");
                Console.WriteLine($"x2 = {x2};");
            }
            else
            {
                if (D < 0) Console.WriteLine("Действительных корней нет!");
                else Console.WriteLine($"x(1,2)= {x1}");
            }
            if (printAlternativeSquarePolynomial) Console.WriteLine(PrintAlternativeSquarePolynomial(x1, 1) + PrintAlternativeSquarePolynomial(x2, 2) + " = 0");
        }
    }
}
