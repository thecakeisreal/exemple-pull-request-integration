using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopScore.MessagesConfirmation
{
    internal class MessageErreur : MessageConfirmation
    {
        /// <inheritdoc/>
        public MessageErreur(string message) : base(message)
        {

        }

        /// <inheritdoc/>
        public override Requete Afficher()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return base.Afficher();
        }
    }
}
