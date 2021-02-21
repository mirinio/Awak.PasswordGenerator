using System;

namespace Awak.PasswordGenerator
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            var argReader = new ArgumentsReader(args);
            var arguments = argReader.Read();
            arguments.ToString();
            var generator = new Generator(arguments);
                       
            bool createPassword = true;
            int pwCounter = 0;
            while (createPassword)
            {
                pwCounter++;
                var pw = generator.CreatePassword();
                Console.WriteLine(pw);

                if (arguments.PasswordCount <= pwCounter)
                {
                    Console.WriteLine("Create another one? (Y/N)");
                    string response = Console.ReadLine();
                    createPassword = ParseResponse(response);
                }
            }
        }

        private static bool ParseResponse(string response)
        {
            return response.Equals("Y", StringComparison.InvariantCulture) || 
                response.Equals("y", StringComparison.InvariantCulture);
        }
    }
}
