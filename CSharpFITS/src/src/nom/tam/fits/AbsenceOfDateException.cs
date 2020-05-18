using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FITSExceptions
{
	class AbsenceOfDateException : Exception
	{
		public AbsenceOfDateException()
		{
		}

		public AbsenceOfDateException(string message) : base(message)
		{
		}

		public AbsenceOfDateException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected AbsenceOfDateException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
