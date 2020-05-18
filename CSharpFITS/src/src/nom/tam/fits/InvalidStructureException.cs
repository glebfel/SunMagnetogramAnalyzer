using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace non.tam.fits
{
    public class InvalidStructureException : Exception
    {
        public InvalidStructureException()
        {
        }

        public InvalidStructureException(string message) : base(message)
        {
        }

        public InvalidStructureException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidStructureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
