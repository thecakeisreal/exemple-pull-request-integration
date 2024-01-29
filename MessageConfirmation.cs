using System;
using System.Collections.Generic;


namespace TopScore
{
    /// <summary>
    /// Gère les messages de confirmation
    /// </summary>
    internal class MessageConfirmation : Vue
    {
        /// <inheritdoc/>
        public MessageConfirmation(Dictionary<string, object> donnees) : base(donnees)
        {

        }

        /// <inheritdoc/>
        public override Requete Afficher()
        {
            switch ((int)donnees["Code"])
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
            }

            Console.WriteLine(donnees["Message"]);
            Console.ForegroundColor = ConsoleColor.Gray; 
            return null;
        }
    }
}
