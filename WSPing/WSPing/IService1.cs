using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WSPing
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        [OperationContractAttribute(AsyncPattern = true)]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "Ping")]
        IAsyncResult BeginPingAsyncMethod(AsyncCallback callback, object asyncState);

        // Note: There is no OperationContractAttribute for the end method.
        string EndPingAsyncMethod(IAsyncResult result);

        // TODO: agregue aquí sus operaciones de servicio
    }
}
