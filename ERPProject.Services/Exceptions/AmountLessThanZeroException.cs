using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Services.Exceptions
{
    [Serializable]
    public class AmountLessThanZeroException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public AmountLessThanZeroException()
        {
        }

        public AmountLessThanZeroException(string message) : base(message)
        {
        }

        public AmountLessThanZeroException(string message, Exception inner) : base(message, inner)
        {
        }

        protected AmountLessThanZeroException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }

}
