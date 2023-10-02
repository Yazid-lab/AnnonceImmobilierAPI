using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAnnonce.Application.Exceptions
{
    public class EmailNotSentException: Exception
    {
        public EmailNotSentException( string emailType) : base( $"Error occured while sending the {emailType} email") { }
    }
}
