using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Progame.Domain.Models.Response
{
    public class ResponseBase : IDisposable
    { 
        public HttpStatusCode StatusCode { get; set; }
        public string Mensagem { get; set; }
        public object Data { get; set; }

        public ResponseBase()
        {
        }

        public ResponseBase(HttpStatusCode statusCode, string mensagem, object data)
        {
            StatusCode = statusCode;
            Mensagem = mensagem;
            Data = data;
        }

        #region [IDisposable Support]
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //Descartar estado gerenciado (Objetos Gerenciados)
                }

                //Liberar recursos não gerenciados (objetos não gerenciados) e substituir um finalizador abaixo.
                //Definir campos grandes como nulos.

                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            //Não altere esse código. Coloque o código de limpeza em Dispose(bool disposing) acima.
            Dispose(true);
        }
        #endregion
    }
}
