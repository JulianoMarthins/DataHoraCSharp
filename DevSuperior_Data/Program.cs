using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DevSuperior_Data {
    internal class Program {
        static void Main(string[] args) {


            /*
             *     DateTimeKind
             *     
             *     Tipo enumerado especial que define três valores possíveis para a localidade da data: 
             *     
             *     # Local -> Fuso horário do sistema. 
             *         Exemplo: São Paulo = GMT -3
             *         
             *     # UTC -> Fuso horário GMT (Geenwich mean time)
             *         Horario de Londres, considerado a hora 0 do GMT
             *     
             *     # Unspecified -> Não especificado
             *     
             *     
             *     Boa prática
             *         Armazenar a data e hora nos bancos de dados, Json ou XML, no formato UTC
             *         Instanciar e mostrar em formato local quando for no sistema.
             *         Ou seja, sempre converter a data hora para o horario local para fornecer informações no sistema,
             *         porém armazenar esses valores como UTC no banco de dados.
             *         
             *         
             *     Para conveter um DateTime para Local ou UTC, você deve usar:
             *         * myDate.ToLocalTime() -> Conversão para horario local
             *         * myDate.ToUniversalTime() -> Conversão para UTC
             *    
             * 
             */







            // Podemos observar que data foi instanciada como local, a impressão desta acrescentará 3 horas na
            // conversão para UTC
            DateTime data = new DateTime(2000, 8, 15, 13, 5, 58, DateTimeKind.Local);
            Console.WriteLine("Data instanciada Local: "+ data);
            Console.WriteLine("Data Kind: " + data.Kind);
            Console.WriteLine("Data Local: " + data.ToLocalTime());
            Console.WriteLine("Data UTC: " + data.ToUniversalTime());

            // Podemos observar que a data foi instanciada como UTC, neste caso, a impressão no console mostrará
            // a hora local com redução de 3 horas
            DateTime data2 = new DateTime(2000, 8, 15, 13, 5, 58, DateTimeKind.Utc);
            Console.WriteLine("\n\nData instanciada UTC: " + data2);
            Console.WriteLine("Data Kind: " + data2.Kind);
            Console.WriteLine("Data Local: " + data2.ToLocalTime());
            Console.WriteLine("Data UTC: " + data2.ToUniversalTime());

            // Abaixo é instanciada uma data sem nenhum tipo de especificação, logo, o resultado será a alteração
            // nos ambos casos, local reduz 3 horas, UTC acrescenta 3 horas
            DateTime data3 = new DateTime(2000, 8, 15, 13, 5, 58);
            Console.WriteLine("\n\nData instanciada sem especificação: " + data3);
            Console.WriteLine("Data Kind: " + data3.Kind);
            Console.WriteLine("Data Local: " + data3.ToLocalTime());
            Console.WriteLine("Data UTC: " + data3.ToUniversalTime());

            /*
             *          Padrão ISO 8601
             *          
             *     Formato deve ser:
             *        
             *        yyyy-MM-ddTHH:mm:ssZ
             *        
             *     Significado:
             *        yyyy -> Ano com quatro casas decimais, 1982
             *        MM   -> Mês com duas casas deciamais, 08
             *        dd   -> Dia com duas casas decimais, 21
             *        T    -> Representa que será registrado horas
             *        HH   -> Hora
             *        mm   -> Minutos
             *        ss   -> Segundos
             *        Z    -> Significa que o código é uma string no formato UTC
             *        
             */
            

            // O comando Parse converterá uma string para o objeto DateTime
            DateTime time = DateTime.Parse("2015-05-03 15:40:30");
            Console.WriteLine("\n\nData convertida de string para DateTime: " + time);
            Console.WriteLine("Data Kind: " + time.Kind);
            Console.WriteLine("Data local: " + time.ToLocalTime());
            Console.WriteLine("Data UTC: " + time.ToUniversalTime());



            // Percebemos abaixo que a data no padrão ISO 8601 é convertidada para o padrão UTC, logo, o retorno
            // de time2 será as 12 horas, mesmo tendo sido criada com o valor de 15hs
            DateTime time2 = DateTime.Parse("2015-05-03T15:40:30Z");
            Console.WriteLine("\n\nData convertida do string no padrão iso 8601: " + time2);
            Console.WriteLine("Data Kind: " + time2.Kind);
            Console.WriteLine("Data local: " + time2.ToLocalTime());
            Console.WriteLine("Data UTC: " + time2.ToUniversalTime());


            Console.WriteLine("\n\nCovnersão de data para String: " + time2.ToString());
            Console.WriteLine("Conversão para UTC deve ser realizada primeiros\n" +
                "que a conversão para string: " + time2.ToUniversalTime().ToString());





        }
    }
}
