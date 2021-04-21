using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static int port = 8005; 
        static void Main(string[] args)
        {
            
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var Array = new string[3, 3];

            string x = "X";
            string o = "O";
            int num;
            byte[] data;
            try
            {              
                listenSocket.Bind(ipPoint);               
                listenSocket.Listen(10);

                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                    Socket handler = listenSocket.Accept();                
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    data = new byte[256];
                    do
                    {
                        builder.Clear();
                        do
                        {
                            bytes = handler.Receive(data);
                            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                        }
                        while (handler.Available > 0);
                        num = Convert.ToInt32(builder.ToString()); 
                       
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



                        data = Encoding.Unicode.GetBytes(num.ToString());
                        handler.Send(data);
                    } while (true);
                    
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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