namespace SimpleCSProject
{
    internal class Program
    {
        static double add(double n1, double n2)
        {
            return n1 + n2;
        }
        static double sub(double n1, double n2)
        {
            return n1 - n2;
        }
        static double mul(double n1, double n2)
        {
            return n1 * n2;
        }
        static double div(double n1, double n2)
        {
            return n1 / n2;
        }
        static double SecDegEqroot1(double a, double b, double c)
        {
            double discriminant = (b * b) - (4 * a * c);

            if (discriminant < 0)
            {
                return double.NaN; // No real root exists
            }

            double z = Math.Sqrt(discriminant);
            double r1 = (-b + z) / (2 * a);
            return r1;
        }

        static double SecDegEqroot2(double a, double b, double c)
        {
            double discriminant = (b * b) - (4 * a * c);

            if (discriminant < 0)
            {
                return double.NaN; // No real root exists
            }

            double z = Math.Sqrt(discriminant);
            double r2 = (-b - z) / (2 * a);
            return r2;
        }

        static int[,] add2Arrays(int[,] arr1, int[,] arr2)
        {
            int rows = arr1.GetLength(0);
            int columns = arr1.GetLength(1);
            // Initialize the jagged array z
            int[,] sum = new int[rows, columns];
            // Perform the addition
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    sum[i, j] = arr1[i, j] + arr2[i, j];
                }
            }
            return sum;
        }

        static int[,] subtract2Arrays(int[,] arr1, int[,] arr2)
        {
            int rows = arr1.GetLength(0);
            int columns = arr1.GetLength(1);
            // Initialize the jagged array z
            int[,] sub = new int[rows, columns];
            // Perform the addition
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    sub[i, j] = arr1[i, j] - arr2[i, j];
                }
            }

            return sub;
        }

        static int[,] multiply2Arrays(int[,] arr1, int[,] arr2)
        {
            int rows = arr1.GetLength(0);
            int columns = arr1.GetLength(1);
            int[,] mul = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    mul[i, j] = arr1[i, j] * arr2[i, j];
                }
            }

            return mul;
        }
        /*
        {
            int rows1 = arr1.GetLength(0);
            int cols1 = arr1.GetLength(1);
            int rows2 = arr2.GetLength(0);
            int cols2 = arr2.GetLength(1);

            // Check if multiplication is possible
            if (cols1 != rows2)
            {
                throw new ArgumentException("Number of columns in the first matrix must equal the number of rows in the second matrix.");
            }

            // Resultant matrix will have dimensions rows1 x cols2
            int[,] result = new int[rows1, cols2];
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    result[i, j] = 0; // Initialize the result matrix element to 0
                    for (int k = 0; k < cols1; k++)
                    {
                        result[i, j] += arr1[i, k] * arr2[k, j];
                    }
                }
            }

            return result;
        }
        */

        static void Main(string[] args)
        {
            int choise;
            do
            {
                Console.WriteLine("Welcome to the main program :)");
                Console.WriteLine("Choose the program you want to use:");
                Console.WriteLine("1: Calculator");
                Console.WriteLine("2: Solving the 2nd degree Equation");
                Console.WriteLine("3: Operations on Arrays");
                Console.WriteLine("0: Close the App :( ");
                choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        Console.WriteLine("Welcome to the Calculator App");
                        Console.WriteLine("Enter 2 Numbers.");
                        double n1 = double.Parse(Console.ReadLine());
                        double n2 = double.Parse(Console.ReadLine());
                        char o;
                        do
                        {
                            Console.WriteLine("Choose The Operation from the following:");
                            Console.WriteLine("+ : Get the output of number1 + number2");
                            Console.WriteLine("- : Get the output of number1 - number2");
                            Console.WriteLine("* : Get the output of number1 * number2");
                            Console.WriteLine("/ : Get the output of number1 / number2");
                            Console.WriteLine("q : Exit.");
                            o = Convert.ToChar(Console.ReadLine());
                            switch (o)
                            {
                                case '+':
                                    Console.WriteLine(add(n1, n2));
                                    break;
                                case '-':
                                    Console.WriteLine(sub(n1, n2));
                                    break;
                                case '*':
                                    Console.WriteLine(mul(n1, n2));
                                    break;
                                case '/':
                                    if (n2 == 0)
                                        Console.WriteLine("Can't divide by zero!");
                                    else Console.WriteLine(div(n1, n2));
                                    break;
                                case 'q':
                                    Console.WriteLine("Thanks for using the calc app :)");
                                    break;
                                default:
                                    Console.WriteLine("Invalid Operation!");
                                    break;
                            }
                        }
                        while (o != 'q');
                        break;
                    case 2:
                        Console.WriteLine("Welcome to the 2nd Degree Equation Solver");
                        Console.WriteLine("Enter values of a, b, and c of The form ax^2 + bx +c = 0");
                        double a = double.Parse(Console.ReadLine());
                        double b = double.Parse(Console.ReadLine());
                        double c = double.Parse(Console.ReadLine());
                        double root1 = SecDegEqroot1(a, b, c);
                        double root2 = SecDegEqroot2(a, b, c);
                        if (double.IsNaN(root1) || double.IsNaN(root2))
                        {
                            Console.WriteLine("The equation has no real roots.");
                        }
                        else
                        {
                            Console.WriteLine("Value of X1 is: " + root1);
                            Console.WriteLine("Value of X2 is: " + root2);
                        }

                        break;

                    case 3:

                        Console.WriteLine("Enter the number of rows for the 2 arrays.");
                        int row = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the number of columns for the 2 arrays.");
                        int col = int.Parse(Console.ReadLine());

                        int[,] arr1 = new int[row, col];
                        for (int i = 0; i < row; i++)
                        {
                            for (int j = 0; j < col; j++)
                            {
                                Console.WriteLine("Please enter data for Row no: " + (i + 1) + " And Column no: " + (j + 1) + " Of the 1st array");
                                arr1[i, j] = int.Parse(Console.ReadLine());

                            }
                        }

                        int[,] arr2 = new int[row, col];
                        for (int i = 0; i < row; i++)
                        {
                            for (int j = 0; j < col; j++)
                            {
                                Console.WriteLine("Please enter data for Row no: " + (i + 1) + " And Column no: " + (j + 1) + " Of the 2nd array");
                                arr2[i, j] = int.Parse(Console.ReadLine());

                            }
                        }
                        int arrChoise;
                        do
                        {
                            Console.WriteLine("Choose the opration");
                            Console.WriteLine("1. Array addition.");
                            Console.WriteLine("2. Array subtraction.");
                            Console.WriteLine("3. Multiply the Elements of the 2 Arrays.");
                            Console.WriteLine("0. Exit.");
                            arrChoise = int.Parse(Console.ReadLine());
                            switch (arrChoise)
                            {
                                case 1:
                                    int[,] sum = add2Arrays(arr1, arr2);
                                    for (int i = 0; i < row; i++)
                                    {
                                        for (int j = 0; j < col; j++)
                                        {
                                            Console.Write(sum[i, j] + "\t");
                                        }
                                        Console.WriteLine();
                                    }

                                    break;
                                case 2:
                                    int[,] sub = subtract2Arrays(arr1, arr2);
                                    for (int i = 0; i < row; i++)
                                    {
                                        for (int j = 0; j < col; j++)
                                        {
                                            Console.Write(sub[i, j] + "\t");
                                        }
                                        Console.WriteLine();
                                    }
                                    break;
                                case 3:
                                    int[,] mul = multiply2Arrays(arr1, arr2);
                                    for (int i = 0; i < row; i++)
                                    {
                                        for (int j = 0; j < col; j++)
                                        {
                                            Console.Write(mul[i, j] + "\t");
                                        }
                                        Console.WriteLine();
                                    }
                                    break;
                                case 0:
                                    Console.WriteLine("Thanks for using the Array app :)");
                                    break;
                                default:
                                    Console.WriteLine("Invalid Operation!");
                                    break;
                            }
                        }
                        while (arrChoise != 0);


                        break;
                    case 0:
                        Console.WriteLine("Thanks for using my app :)");
                        break;
                    default:
                        Console.WriteLine("Invalid Choise!");
                        break;
                }
            } while (choise != 0);


        }
    }
}
