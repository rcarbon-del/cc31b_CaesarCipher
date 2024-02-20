namespace CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the text: ");
            string text = Console.ReadLine();

            Console.Write("Enter the shift: ");
            int shift = Convert.ToInt32(Console.ReadLine());

            string encoded = CaesarCipher.Encode(text, shift);
            Console.WriteLine($"Encoded: {encoded}");

            string decoded = CaesarCipher.Decode(encoded, shift);
            Console.WriteLine($"Decoded: {decoded}");
        
        }
    }
    public class CaesarCipher
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string Encode(string input, int shift)
        {
            return new string(input.ToUpper().Select(c => Cipher(c, shift)).ToArray());
        }

        public static string Decode(string input, int shift)
        {
            return new string(input.ToUpper().Select(c => Cipher(c, -shift)).ToArray());
        }

        private static char Cipher(char c, int shift)
        {
            if (!Alphabet.Contains(c))
            {
                return c;
            }

            int shiftedPosition = (Alphabet.IndexOf(c) + shift) % Alphabet.Length;
            if (shiftedPosition < 0)
            {
                shiftedPosition += Alphabet.Length;
            }

            return Alphabet[shiftedPosition];
        }
    }
}