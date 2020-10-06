using System;
using System.Linq;

namespace MUsefullMethods
{
    public static class StringHelpers
    {
        private static char[] _validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
        private static char[] _validCharacters = { '\'', '\"', '!', '^', '+', '#', '$', '%', '&', '/', '{', '}', '(', ')', '[', ']', '=', '?', '*', '\\', '-', '_', '~', ',', ';', '´', '.', ':', '|', '<', '>', '@', '€', '¨', ' ' };
        public static string GenerateUniqueCode()
        {
            string base64String = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            base64String = System.Text.RegularExpressions.Regex.Replace(base64String, "[/+=]", "");

            return base64String.ToLower(new System.Globalization.CultureInfo("en-US", false));
        }

        public static string GenerateUpperCode(int size = 6)
        {
            var random = new Random();
            var code = string.Empty;

            for (int i = 0; i < size; i++)
            {
                code += _validChars[random.Next(_validChars.Length)];
            }

            return code;
        }
        public static string RandomPasswordGenerator(int size = 6) => GenerateUniqueCode().Substring(0, size);
        public static string CharacterConverter(string name)
        {
            string sonuc = name.ToLower();
            sonuc = ClearHiddenCharacters(sonuc);
            sonuc = sonuc.Replace("'", "");
            sonuc = sonuc.Replace(" ", "_");
            sonuc = sonuc.Replace("  ", "_");
            sonuc = sonuc.Replace("   ", "_");
            sonuc = sonuc.Replace("<", "");
            sonuc = sonuc.Replace(">", "");
            sonuc = sonuc.Replace("&", "");
            sonuc = sonuc.Replace("[", "");
            sonuc = sonuc.Replace("!", "");
            sonuc = sonuc.Replace("]", "");
            sonuc = sonuc.Replace("ı", "i");
            sonuc = sonuc.Replace("ö", "o");
            sonuc = sonuc.Replace("ü", "u");
            sonuc = sonuc.Replace("ş", "s");
            sonuc = sonuc.Replace("ç", "c");
            sonuc = sonuc.Replace("ğ", "g");
            sonuc = sonuc.Replace("İ", "I");
            sonuc = sonuc.Replace("Ö", "O");
            sonuc = sonuc.Replace("Ü", "U");
            sonuc = sonuc.Replace("Ş", "S");
            sonuc = sonuc.Replace("Ç", "C");
            sonuc = sonuc.Replace("Ğ", "G");
            sonuc = sonuc.Replace("|", "");
            sonuc = sonuc.Replace(".", "_");
            sonuc = sonuc.Replace("?", "_");
            sonuc = sonuc.Replace(";", "_");
            sonuc = sonuc.Replace("#", "_sharp");

            return sonuc;
        }

        public static string ClearHiddenCharacters(string text)
        {
            return new string(text.Where(x => char.IsLetter(x) || char.IsNumber(x) || _validCharacters.Contains(x)).ToArray());
        }

        public static string CapitalSentences(string sentence)
        {
            if (string.IsNullOrEmpty(sentence)) return "";

            var last = "";
            var arr = sentence.Split(' ');

            foreach (var s in arr)
            {
                if (s.Length == 1)
                {
                    last += s.ToUpper() + " ";
                    continue;
                }

                if (s.Length > 1)
                {
                    last += s.Substring(0, 1).ToUpper() + s.Substring(1).ToLower() + " ";
                    continue;
                }
            }

            return last.Trim();
        }

        public static string ReplaceTrChars(string text)
        {
            return text.Replace('ı', 'i')
                .Replace('ğ', 'g')
                .Replace('ü', 'u')
                .Replace('ş', 's')
                .Replace('ö', 'o')
                .Replace('ç', 'c')
                .Replace('İ', 'I')
                .Replace('Ü', 'U')
                .Replace('Ş', 'S')
                .Replace('Ö', 'O')
                .Replace('Ç', 'C');
        }

        public static string ClearIllegalChars(string text, bool isFile = false)
        {
            text = ClearHiddenCharacters(text);
            text = text
                .Replace("\'", "")
                .Replace("\"", "")
                .Replace("#", "")
                .Replace("!", "")
                .Replace("$", "")
                .Replace("%", "")
                .Replace("&", "")
                .Replace("{", "")
                .Replace("}", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("[", "")
                .Replace("]", "")
                .Replace("=", "")
                .Replace("?", "")
                .Replace("*", "");

            if (!isFile)
                text = text
                    .Replace("\"", "")
                    .Replace("/", "");

            return text;
        }

        public static string[] NameSurnameSplitter(string fullName)
        {
            var namesArray = fullName.Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Trim()).ToArray();

            if (namesArray.Length < 2) return new string[] { CapitalSentences(fullName), "" };

            var name = "";
            var surname = "";

            for (int i = 0; i < namesArray.Length; i++)
            {
                if (i == 0)
                    name = namesArray[i];
                else if (i == namesArray.Length - 1)
                    surname = namesArray[i];
                else
                    name += " " + namesArray[i];
            }

            return new string[] { CapitalSentences(name), CapitalSentences(surname) };
        }
        public static string ConcatForUserName(string part1, string part2)
        {
            var splitted = part1.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var userName = CharacterConverter(splitted[0] + part2.ToLower());
            return userName;
        }
        public static string FormatForTag(this string input)
        {
            var text = input.ToLower().Trim();
            text = CharacterConverter(text);
            var splitted = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var result = "";
            for (int i = 0; i < splitted.Length; i++)
                result += i == splitted.Length - 1 ? splitted[i] : $"{splitted[i]}-";

            return result;
        }
    }
}
