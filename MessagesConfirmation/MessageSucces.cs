using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopScore.MessagesConfirmation
{
    internal class MessageSucces : MessageConfirmation
    {

        /// <inheritdoc/>
        public MessageSucces(string message) : base(message)
        {

        }

        /// <inheritdoc/>
        public override Requete Afficher()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return base.Afficher();
        }
    }
}
