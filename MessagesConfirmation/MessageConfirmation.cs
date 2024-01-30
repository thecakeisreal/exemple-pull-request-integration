using System;
using System.Collections.Generic;


namespace TopScore.MessagesConfirmation
{
    /// <summary>
    /// Gère les messages de confirmation
    /// </summary>
    internal abstract class MessageConfirmation : Vue
    {
        /// <summary>
        /// Constructeur qui accepte le message
        /// </summary>
        /// <param name="message">Le message à afficher</param>
        public MessageConfirmation(string message) : base(
            new Dictionary<string, object>{{ "Message", message }})
        {

        }

        /// <inheritdoc/>
        public override Requete Afficher()
        {
            /*switch ((int)donnees["Code"])
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
            }*/

            Console.WriteLine(donnees["Message"]);
            Console.ForegroundColor = ConsoleColor.Gray;
            return null;
        }
    }
}
