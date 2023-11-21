namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BasicExceptionHandling();
            MultipleExceptionTypes();
            FinalyBlockUsage();
            CustomExceptionClass();
            ExceptionPropagation();
            UsingThrowAndCatch();
        }

        static void BasicExceptionHandling()
        {
            Console.Write("Enter a number: ");
            try
            {

                int number = int.Parse(Console.ReadLine());

                Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
        }

        static void MultipleExceptionTypes()
        {
            Console.Write("Enter a number: ");
            try
            {
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: The entered number is too large or too small.");
            }
        }

        static void FinalyBlockUsage()
        {
            Console.Write("Enter a number: ");
            try
            {
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
            finally
            {
                Console.WriteLine("Finally block executed.");
            }
        }
        class NegativeNumberException : ApplicationException
        {
            public NegativeNumberException(string message) : base(message) { }
        }

        static void CustomExceptionClass()
        {
            Console.Write("Enter a number: ");
            try
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 0)
                {
                    throw new NegativeNumberException("Error: Negative numbers are not allowed.");
                }

                Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
            catch (NegativeNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ExceptionPropagation()
        {
            Console.Write("Enter a number: ");
            try
            {
                int number = int.Parse(Console.ReadLine());
                CheckNumber(number);
                Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void CheckNumber(int number)
        {
            if (number > 100)
            {
                throw new ArgumentOutOfRangeException("Error: Number cannot be greater than 100.");
            }
        }

        static void UsingThrowAndCatch()
        {
            Console.Write("Enter a number: ");
            try
            {
                int number = int.Parse(Console.ReadLine());
                CheckNumberWithLogging(number);
                Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Logged Message: {ex.Message}");
            }
        }
        static void CheckNumberWithLogging(int number)
        {
            try
            {
                if (number > 100)
                {
                    Console.WriteLine($"Logging: Number {number} is greater than 100.");
                    throw new ArgumentOutOfRangeException("Error: Number cannot be greater than 100.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Logging: {ex.Message}");
                throw;
            }

        }
    }
}