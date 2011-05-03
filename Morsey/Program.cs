using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;


namespace Morsey
{
    public class Program
    {
        static bool displayMessage = false;
        static String message = "SOS";
        static LED led = new LED();
        static Thread morseThread = new Thread(MorseCode);

        public static void Main()
        {
            InterruptPort button = new InterruptPort(Pins.ONBOARD_SW1, false, Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeHigh);
            button.OnInterrupt += new NativeEventHandler(button_OnInterrupt);

            Thread.Sleep(Timeout.Infinite);

            //while (true)
            //{
            //    //repeat message every 2 seconds if button is pressed
            //    if (displayMessage)
            //    {
            //        MorseCode();
            //    }
            //    else
            //    {
            //        led.Write(false);
            //    }
            //}

        }

        private static void MorseCode()
        {
            while (true)
            {
                led.WriteMorse(message);
                Thread.Sleep(2000);
            }
        }

        static void button_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            bool isButtonDown = (data2 != 0);
            if (isButtonDown)
            {
                displayMessage = !displayMessage;
            }
            
            if (displayMessage)
            {
                if(morseThread.ThreadState == ThreadState.Unstarted)
                    morseThread.Start();
                else
                    morseThread.Resume();
            }
            else 
            {
                morseThread.Suspend();
                led.Off(); 
            }
        }

    }
}
