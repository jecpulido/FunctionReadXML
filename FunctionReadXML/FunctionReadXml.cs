using System;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionReadXML
{
    public static class FunctionReadXml
    {
        [FunctionName("FunctionReadXml")]
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log, ExecutionContext context)
        {           
            try
            {
                using (var fileStream = File.Open(Path.Combine(context.FunctionAppDirectory, "Files\\Stock.xml"), FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Gosocket));
                    var DocumentGoSocket = (Gosocket)serializer.Deserialize(fileStream);

                    log.LogInformation($"N�mero de �reas existentes: {DocumentGoSocket.NumberOfAreas} ");
                    log.LogInformation($"N�mero de �reas con m�s de 2 empleados : {DocumentGoSocket.getNumberOfAreasMoreTwoEmployees()} ");                    
                    foreach (var item in DocumentGoSocket.Area)
                    {
                        log.LogInformation($" �rea: {item.Name} | Total salarios: {item.GetSumOfSalaries() } ");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                log.LogError($"Erros: ex.Message");
            }
            
        }
    }
}
