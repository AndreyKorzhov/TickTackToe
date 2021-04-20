using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        // адрес и порт сервера, к которому будем подключаться
        static int port = 8005; // порт сервера
        static string address = "127.0.0.1"; // адрес сервера
        static void Main(string[] args)
        {
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // подключаемся к удаленному хосту
                socket.Connect(ipPoint);
                ////////////////////////////////////
                var Array = new string[3, 3];

                string x = "X";
                string o = "O";
                int num;
                byte[] data;
                do
                {
                    
                    do
                    {

                        Console.WriteLine("Введите номер ячейки 1....9");
                        num = Convert.ToInt32(Console.ReadLine());
                        data = Encoding.Unicode.GetBytes(num.ToString());
                        
                        socket.Send(data);
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
                    // получаем ответ
                    data = new byte[256]; // буфер для ответа
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; // количество полученных байт

                    do
                    {
                        bytes = socket.Receive(data, data.Length, 0);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (socket.Available > 0);
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
                } while (true);
                
                

                // закрываем сокет
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
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