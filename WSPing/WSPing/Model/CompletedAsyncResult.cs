using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using WSPing.Business;

namespace WSPing.Model
{
    // Simple async result implementation.
    class CompletedAsyncResult : IAsyncResult
    {
        public string Data { get; }

        public CompletedAsyncResult()
        {
            string idMsg = DateTime.Now.Ticks.ToString();
            Productor.ProducirMsg("Ping_Message", idMsg);
            this.Data = Consumidor.Consumir(idMsg);
        }        

        #region IAsyncResult Members
        public object AsyncState
        { get { return (object)Data; } }

        public WaitHandle AsyncWaitHandle
        { get { throw new Exception("The method or operation is not implemented."); } }

        public bool CompletedSynchronously
        {
            get
            {
                return true;
            }
        }

        public bool IsCompleted
        { get { return true; } }
        #endregion
    }
}