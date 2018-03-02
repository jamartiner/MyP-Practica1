﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using WSPong.Business;

namespace WSPong
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        static Service1()
        {
            Consumidor.IniciarBackgrounWorker();
        }
        public int ObtenerCantidadMensajesRecibidos()
        {
            return Consumidor.ContadorMensajesRecibidos;
        }

        public int ObtenerCantidadMensajesAtendidos()
        {
            return Productor.ContadorMensajesAtendidos;
        }
    }    
}
