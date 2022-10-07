using System;
using System.Collections.Generic;
using System.Linq;

namespace Progame.Domain.Models.Response.Error
{
    public class ErrorResponse
    {
        public string TraceId { get; private set; }
        public List<ErrorDetails> Erros { get; private set; }

        public ErrorResponse()
        {
            TraceId = Guid.NewGuid().ToString();
            Erros = new List<ErrorDetails>();
        }

        public ErrorResponse(string logRef, string message)
        {
            TraceId = Guid.NewGuid().ToString();
            Erros = new List<ErrorDetails>();
            AddError(logRef, message);
        }

        private void AddError(string logRef, string message)
        {
            Erros.Add(new ErrorDetails(logRef, message));
        }

        #region [Class ErrorDetails]
        public class ErrorDetails
        {
            public ErrorDetails(string logRef, string message)
            {
                LogRef = logRef;
                Message = message;
            }

            public string LogRef { get; private set; }
            public string Message { get; private set; }
        }

        #endregion
    }
}
