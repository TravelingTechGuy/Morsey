using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;
using System.Threading;

namespace Morsey
{
    class LED
    {
        //the LED
        private OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);
        //delay betwen characters (in milliseconds)
        private int delay;
        
        public LED(int delay = 500)
        {
            this.delay = delay;
        }

        private void Dash()
        {
            led.Write(true);
            //a dash is a second
            Thread.Sleep(1000);
            led.Write(false);
            //delay to next character
            Thread.Sleep(delay);
        }

        private void Dot()
        {
            led.Write(true);
            //a dot is a quarter second 
            Thread.Sleep(250);
            led.Write(false);
            //delay to next character
            Thread.Sleep(delay);
        }

        private void Write(bool state)
        {
            led.Write(state);
        }

        public void On() 
        {
            Write(true);
        }

        public void Off()
        {
            Write(false);
        }

        public void WriteMorse(String message) 
        {
            MorseCharacters converter = new MorseCharacters();
            String morseMessage = converter.ConvertMessageToMorse(message);
            if (morseMessage != String.Empty)
            {
                foreach (char c in morseMessage)
                {
                    switch (c)
                    {
                        case '.':
                            Dot();
                            break;
                        case '-':
                            Dash();
                            break;
                        case ' ':
                            Thread.Sleep(delay * 2); //delay for twice the character gap between words
                            break;
                        default:    //handle errors here
                            break;
                    }
                }
            }
        }
    }
}
