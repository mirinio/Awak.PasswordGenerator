using System;
using System.Linq;

namespace Awak.PasswordGenerator
{
    internal class ArgumentsReader
    {
        private readonly string[] _args;

        public ArgumentsReader(string[] args)
        {
            _args = args;
        }


        internal Arguments Read()
        {
            if (_args.Any())
            {
                bool hasSpecial = false;
                bool hasNumbers = false;
                bool hasLetters = false;
                bool hasAnnoying = false;
                int charCount = 0;
                int passwordCount = 1;

                for (int i = 0; i < _args.Length; i++)
                {
                    string argument = _args[i].ToLower();
                    switch (argument)
                    {
                        case "-s":
                            hasSpecial = true;
                            break;
                        case "-n":
                            hasNumbers = true;
                            break;
                        case "-l":
                            hasLetters = true;
                            break;
                        case "-a":
                            hasAnnoying = true;
                            break;
                        case "-c":
                            i = ParsePasswordLength(_args[i + 1], out charCount) ? i + 1 : i;
                            break;
                        case "-pwc":
                            i = ParsePasswordCountArgument(_args[i + 1], out passwordCount) ? i + 1 : i;
                            break;
                        default:
                            break;
                    }
                }
                return new Arguments(
                       charCount,
                       passwordCount,
                       hasSpecial,
                       hasNumbers,
                       hasLetters,
                       hasAnnoying);
            }

            return new Arguments();
        }


        private bool ParsePasswordCountArgument(string argument, out int result)
        {
            if (!Int32.TryParse(argument, out result))
            {
                Console.WriteLine("Could not parse your characters count input.");
                Console.WriteLine("Using Defualt 16 characters...");
                return false;
            }

            return true;
        }

        private bool ParsePasswordLength(string argument, out int result)
        {
            if (!Int32.TryParse(argument, out result))
            {
                Console.WriteLine("Could not parse your password count for input.");
                Console.WriteLine("Generating one password...");
                return false;
            }

            return true;
        }
    }
}
