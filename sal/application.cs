using System;
using SAL.Constants.Messages;

namespace SAL
{
    public class Application
    {
        public void Run()
        {
            InitialPrint();
        }

        private static void InitialPrint()
        {
            Console.WriteLine(Msg.WELCOME_MESSAGE);
            Console.WriteLine(Msg.LIST_OF_COMMANDS);
            Console.ReadKey();
        }
    }
}