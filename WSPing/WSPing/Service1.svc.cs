using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WSPing.Model;
using WSPing.Business;

namespace WSPing
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {

        public IAsyncResult BeginPingAsyncMethod(AsyncCallback callback, object asyncState)
        {
            //Console.WriteLine("BeginServiceAsyncMethod called with: \"{0}\"", msg);
            return new CompletedAsyncResult();
        }

        public string EndPingAsyncMethod(IAsyncResult r)
        {
            CompletedAsyncResult result = r as CompletedAsyncResult;
            //Console.WriteLine("EndServiceAsyncMethod called with: \"{0}\"", result.Data);
            return result.Data;
        }
    }
}
