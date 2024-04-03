using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class QuadraticEquation
    {
        // основные поля класса
        private double a1, b1, c1;

        private string[] res = new string[2];

        // конструкторы, задающие значения в свойства
        public QuadraticEquation()
        {
            // базовые значения для примера
            a1 = 1;
            b1 = 2;
            c1 = 1;
        }

        public QuadraticEquation(string a, string b, string c)
        {
            A1 = a;
            B1 = b;
            C1 = c;
        }

        public QuadraticEquation(double a, double b, double c)
        {
            A1 = a.ToString();
            B1 = b.ToString();
            C1 = c.ToString();
        }

        public string A1
        {
            set 
            {
                try
                {
                    a1 = double.Parse(value);
                }
                catch
                {
                    throw new ArgumentException();
                }
            }
            get { return A1; }
        }

        public string B1
        {
            set
            {
                try
                {
                    b1 = double.Parse(value);
                }
                catch
                {
                    throw new ArgumentException();
                }
            }
            get { return B1; }
        }

        public string C1
        {
            set 
            {
                try
                {
                    c1 = double.Parse(value);
                }
                catch
                {
                    throw new ArgumentException();
                }
            }
            get { return C1; }
        }
        public string inscription()
        {
            return a1 + "x^2 + (" + b1 + ")x + (" + c1 + ") = 0";
        }
        public void decision()
        {
            double a = a1;
            double b = b1;
            double c = c1;
            if (a != 0)
            {
                double d = b * b - 4 * a * c;
                if (d > 0)
                {
                    double x1 = (-1 * b + Math.Sqrt(d)) / (2 * a);
                    double x2 = (-1 * b - Math.Sqrt(d)) / (2 * a);
                    res[0] = Convert.ToString(x1);
                    res[1] = Convert.ToString(x2); // самый обычный случай, просто записываем в массив два корня
                }
                else if (d == 0)
                {
                    double x1 = (-1 * b) / (2 * a);
                    res[0] = Convert.ToString(x1);
                    res[1] = "N"; // N - в случае, если дискриминант равен 0, и у нас получается один корень
                }
                else
                {
                    res[0] = "KN"; // KN - в случае, если дискрминант меньше 0, действительных корней нету
                }
            }

            else if (a == 0 && b == 0 && c == 0)
            {
                res[0] = "L"; // L - значит, что любое число
            }
            else if (a == 0 && b == 0 && c != 0)
            {
                res[0] = "RN"; // RN - в случае, когда a и b равны 0, вследствие чего остаётся только c, который не равен 0, то есть это равенство всегда неверное, так как любое число, кроме 0, не равно 0 - нет корней
            }
            else if (a == 0)
            {
                double x1 = ((-1 * c) / b);
                res[0] = Convert.ToString(x1); // второй случай использования N - снова один корень (когда a = 0 и b > 0)
                res[1] = "N";
            }
            else
            {
                res[0] = "L";
            }
        }
        /// <summary>
        /// возвращает ответы на квадратное уравнение
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public string GetAnswers()
        {
            if (res[0] == "KN") return "Действительных корней нет";
            else if (res[0] == "RN") return "Решений нет";
            else if (res[0] == "L") return "Х - любое число";
            else if (res[1] == "N") return "X1 = " + res[0];
            else return "X1 = " + res[0] + " X2 = " + res[1];
        }
    }
}
