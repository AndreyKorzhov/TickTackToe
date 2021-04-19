using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace KREST
{
    class Program
    {
        static void Main(string[] args)
        {
            var Array = new string[3, 3];
            
            string x = "X";
            string o = "O";
             var ip = IPAddress.Parse("127.0.0.1");
             const int PORT = 8005;
             var ipServer = new IPEndPoint(ip, PORT);

             var listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
             listen.Bind(ipServer);
             listen.Listen(10);
             Console.WriteLine("Сервер запущен. Ожидание подключений...");


             while (true)
             {
                 var client = listen.Accept();
                 var messagebilder = new StringBuilder();
                 var data = new byte[256];

                 do
                 {
                     var bytes = client.Receive(data);
                     messagebilder.Append(Encoding.Unicode.GetString(data, 0, bytes));

                 } while (client.Available > 0);

                var num1 = messagebilder.ToString();
                var num = Convert.ToInt32(num1);
                switch (num)
                {
                    case 1:

                        ShowSumbol(0, 0, Array, x);
                        break;
                    case 2:

                        ShowSumbol(0, 1, Array, x);
                        break;
                    case 3:

                        ShowSumbol(0, 2, Array, x);
                        break;
                    case 4:

                        ShowSumbol(1, 0, Array, x);
                        break;
                    case 5:

                        ShowSumbol(1, 1, Array, x);
                        break;
                    case 6:

                        ShowSumbol(1, 2, Array, x);
                        break;
                    case 7:

                        ShowSumbol(2, 0, Array, x);
                        break;
                    case 8:

                        ShowSumbol(2, 1, Array, x);
                        break;
                    case 9:

                        ShowSumbol(2, 2, Array, x);
                        break;


                    default:
                        Console.WriteLine("");
                        break;
                }
                
                Show(Array);
                
                do
                {
                    
                    Console.WriteLine("Введите номер ячейки 1....9");
                    num1 = Console.ReadLine();
                    data = Encoding.Unicode.GetBytes(num1);
                    num = Convert.ToInt32(num1);
                    client.Send(data);
                    switch (num)
                    {
                        case 1:

                            ShowSumbol(0, 0, Array, x);
                            break;
                        case 2:

                            ShowSumbol(0, 1, Array, x);
                            break;
                        case 3:

                            ShowSumbol(0, 2, Array, x);
                            break;
                        case 4:

                            ShowSumbol(1, 0, Array, x);
                            break;
                        case 5:

                            ShowSumbol(1, 1, Array, x);
                            break;
                        case 6:

                            ShowSumbol(1, 2, Array, x);
                            break;
                        case 7:

                            ShowSumbol(2, 0, Array, x);
                            break;
                        case 8:

                            ShowSumbol(2, 1, Array, x);
                            break;
                        case 9:

                            ShowSumbol(2, 2, Array, x);
                            break;


                        default:
                            Console.WriteLine("");
                            break;
                    }
                } while (num < 1 || num > 9);
                



                client.Shutdown(SocketShutdown.Both);
                 client.Close();

             }

                                 
            
        }
        static void ShowSumbol(int row,int col,string [,] array,string sumbol)
        {
            string h = " ";
            for (int i = 0; i < 3; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < 3; j++)
                {
                    array[row, col] = sumbol;
                    Console.Write($"{array[i, j]} |{h}");
                }
                Console.WriteLine();
            }
        }
        static void Show(string[,] array)
        {
            string h = " ";

            for (int i = 0; i < 3; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < 3; j++)
                {
                    array[i, j] = h;
                    Console.Write($"  |{h}");
                }
                Console.WriteLine();
            }
        }
        
    }
}

