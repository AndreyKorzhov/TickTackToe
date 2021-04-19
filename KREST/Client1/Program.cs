using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client1
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
            var server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Connect(ipServer);
            while (true)
            {
                Show(Array);
                int num;
                do
                {
                    Console.WriteLine("Введите номер ячейки 1....9");
                    num = Convert.ToInt32(Console.ReadLine());
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
                
                var data = Encoding.Unicode.GetBytes(num.ToString());
                server.Send(data);

                var msg = new StringBuilder();
                var dataSend = new byte[256];
                do
                {
                    var bytes = server.Receive(data);
                    msg.Append(Encoding.Unicode.GetString(dataSend, 0, bytes));
                } while (server.Available > 0);
                Console.WriteLine(msg);
            }
            

            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }
        static void ShowSumbol(int row, int col, string[,] array, string sumbol)
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
 