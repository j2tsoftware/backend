using System.Runtime.Serialization;

namespace Domain.Shared.Exceptions
{
    [Serializable()]
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }

        /// <summary>
        /// Método construtor para serialização
        /// </summary>
        /// <param name="info">Informação da exception</param>
        /// <param name="context">Contexto </param>
        protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
