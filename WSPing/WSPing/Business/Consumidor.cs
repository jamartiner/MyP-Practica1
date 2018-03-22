using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;

namespace WSPing.Business
{
    public static class Consumidor
    {
        private static Dictionary<string, string> respuestas;
        private static KafkaOptions options;
        private static BrokerRouter router;
        private static KafkaNet.Consumer consumer;
        public static BackgroundWorker backgrounWorker = new BackgroundWorker();

        static Consumidor()
        {
            options = new KafkaOptions(new Uri("http://localhost:9092")/*, new Uri("http://localhost:9092")*/);
            router = new BrokerRouter(options);
            consumer = new KafkaNet.Consumer(new ConsumerOptions("PongPingTopic", new BrokerRouter(options)));
            respuestas = new Dictionary<string, string>();
            IniciarBackgrounWorker();
        }

        public static void IniciarBackgrounWorker()
        {
            if (!backgrounWorker.IsBusy)
            {
                backgrounWorker.DoWork += new DoWorkEventHandler(bw_DoWork);
                backgrounWorker.RunWorkerAsync();
            }
        }

        static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            ConsumirRespuestas();
        }

        /*public static string Consumir(string idMsg)
        {           
            //Consume returns a blocking IEnumerable (ie: never ending stream)
            foreach (var message in consumer.Consume())
            {
                //Console.WriteLine("Response: P{0},O{1} : {2}, key: " + Encoding.UTF8.GetString(message.Key) + ", ConsumerTaskAccount: " + consumer.ConsumerTaskCount, message.Meta.PartitionId, message.Meta.Offset, Encoding.UTF8.GetString(message.Value));
                if (Encoding.UTF8.GetString(message.Key).Equals(idMsg))
                {
                    return Encoding.UTF8.GetString(message.Value);
                }                
            }

            return string.Empty;
        }*/

        public static void ConsumirRespuestas()
        {
            try
            {
                //Consume returns a blocking IEnumerable (ie: never ending stream)
                foreach (var message in consumer.Consume())
                {
                    string keyMsg = Encoding.UTF8.GetString(message.Key);
                    if (!respuestas.ContainsKey(keyMsg))
                    {
                        respuestas.Add(keyMsg, Encoding.UTF8.GetString(message.Value));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static string ObtenerRespuesta(string idMsg)
        {
            for (int i = 0; i < 240; i++)
            {
                if (respuestas.ContainsKey(idMsg))
                {
                    string respuesta = respuestas[idMsg];
                    respuestas.Remove(idMsg);
                    return respuesta;
                }

                Thread.Sleep(250);
            }            

            return "No se recibió una respuesta.";
        }
    }
}