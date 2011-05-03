using System;
using Microsoft.SPOT;

namespace Morsey
{
    class MorseCharacters
    {
        private Char[] Letters = new Char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g',
          'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u',
          'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8',
          '9', ' '};

        private String[] MorseCode = new String[] {".-", "-...", "-.-.",
          "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..",
          "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-",
          "...-", ".--", "-..-", "-.--", "--..", "-----", ".----", "..---",
          "...--", "....-", ".....", "-....", "--...", "---..", "----.", " "};

        public String ConvertCharToMorse(char c)
        {
            int index = -1;
            index = Array.IndexOf(Letters, c);
            if (index != -1)
                return MorseCode[index];
            return string.Empty;
        }

        public String ConvertMessageToMorse(String message)
        {
            String morseMessage = String.Empty;
            message = message.ToLower();
            foreach (char c in message)
            {
                morseMessage += ConvertCharToMorse(c);
            }
            return morseMessage;
        }
    }
}
