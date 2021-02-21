using System.Text;

namespace Awak.PasswordGenerator
{
    internal class Arguments
    {
        public readonly int PasswordLength;
        public readonly int PasswordCount;

        public readonly bool HasSpecialChar;
        public readonly bool HasNumbers;
        public readonly bool HasLetters;
        public readonly bool HasSpecialAnnoyingChars;

        public Arguments(
            int passwordLength = 16,
            int passwordCount = 1,
            bool hasSpecialChar = true,
            bool hasNumbers = true,
            bool hasLetters = true,
            bool hasSpecialAnnoyingChars = false)
        {
            PasswordLength = passwordLength;
            PasswordCount = passwordCount;
            HasSpecialChar = hasSpecialChar;
            HasNumbers = hasNumbers;
            HasLetters = hasLetters;
            HasSpecialAnnoyingChars = hasSpecialAnnoyingChars;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("---Arguments---");
            builder.AppendLine($"-c for Password length: {PasswordLength}");
            builder.AppendLine($"-pwc Password count: {PasswordLength}");
            builder.AppendLine($"-s special characters: {HasSpecialChar}");
            builder.AppendLine($"-n numbers: {HasNumbers}");
            builder.AppendLine($"-l letters: {HasLetters}");
            builder.AppendLine($"-a annoying chars: {HasSpecialAnnoyingChars}");

            return builder.ToString();
        }
    }
}
