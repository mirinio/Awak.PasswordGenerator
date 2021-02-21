using System;
using System.Collections.Generic;
using System.Text;

namespace Awak.PasswordGenerator
{
    internal class Generator
    {
        private readonly Arguments _arguments;
        private readonly char[] _basicLetters = 
            { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 
            'h','i','j','k','l','m','n','o','p',
            'q','r','s','t','u','v','w','x','y','z' };

        private readonly char[] _basicLettersUpper =
            { 'A', 'B', 'C', 'D', 'E', 'F', 'G',
            'H','I','J','K','L','M','N','O','P',
            'Q','R','S','T','U','V','W','X','Y','Z' };

        private readonly char[] _specialChars = 
            { '+', '-', '*', '%', '&', '=', '?', '@', '#'  };

        private readonly char[] _specialAnnoyingChars = 
            { 'ç','~','¦', '°', '§','|','¢','(',')',
            '>', '<', ':' , '_',',', '.' ,';','\\', '/' };

        private readonly char[] _numberCharacters = 
            { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

        private Random _random;
        private List<char[]> _randomListofLists;

        internal Generator(Arguments arguments)
        {
            _arguments = arguments;
            _random = new Random();

            CreateRandomListofLists();
        }

        internal string CreatePassword()
        {
            string password = "";

            for (int i = 0; i < _arguments.PasswordLength; i++)
            {
                int randomCharListIndex = _random.Next(_randomListofLists.Count);
                var randomSelectedList = _randomListofLists[randomCharListIndex];
                int randomSelectedListIndex = _random.Next(randomSelectedList.Length);
                password += randomSelectedList[randomSelectedListIndex];
            }

            return password;
        }


        private void CreateRandomListofLists()
        {
            _randomListofLists = new List<char[]>();
            if (_arguments.HasLetters)
            {
                _randomListofLists.Add(_basicLetters);
                _randomListofLists.Add(_basicLettersUpper);
            }

            if (_arguments.HasNumbers)
            {
                _randomListofLists.Add(_numberCharacters);
            }

            if (_arguments.HasSpecialChar)
            {
                _randomListofLists.Add(_specialChars);
            }

            if (_arguments.HasSpecialAnnoyingChars)
            {
                _randomListofLists.Add(_specialAnnoyingChars);
            }
        }
    }
}
