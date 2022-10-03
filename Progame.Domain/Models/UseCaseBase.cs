using System;

namespace Progame.Domain.Models
{
    public class UseCaseBase : IDisposable
    {
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
