using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace non.tam.fits
{
	class InvalidAxisNumberException : Exception
	{
		public InvalidAxisNumberException()
		{
		}

		public InvalidAxisNumberException(string message) : base(message)
		{
		}

		public InvalidAxisNumberException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected InvalidAxisNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
