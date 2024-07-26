using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.Data.SqlClient;
using Models;
using System.Windows.Input;

namespace API.SensorInteractor
{
    namespace API.SensorInteractor
    {
        class SensorInteractor
        {
            static SerialPort serialPort;
            static List<string> data = new List<string>(); // List to store data
            static int maxLines = 15; // Maximum number of lines to read
            static bool productPresent = false;
            static int indicator = -1;

            static async Task Main(string[] args)
            {
                serialPort = new SerialPort("COM4", 9600);
                serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                serialPort.Open();

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();

                serialPort.Close();
            }

            private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
            {
                SerialPort sp = (SerialPort)sender;
                bool productPresent = false;

                while (data.Count < maxLines)
                {
                    try
                    {
                        string line = sp.ReadLine();
                        data.Add(line);
                        Console.WriteLine($"Data received: {line}");

                        if (data.Count >= maxLines)
                        {
                            serialPort.DataReceived -= new SerialDataReceivedEventHandler(DataReceivedHandler);
                            Console.WriteLine("Stopped reading data after receiving 10 lines.");
                            break;
                        }

                        if (data[data.Count - 1].Contains("0"))
                        {
                            productPresent = false;
                            indicator = 1;
                        }
                        else if (data[data.Count - 1].Contains("1"))
                        {
                            productPresent = true;
                            indicator = 1;
                        }
                    }
                    catch (TimeoutException tex)
                    {
                        Console.WriteLine($"Timeout: {tex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error reading data: {ex.Message}");
                    }
                }
            }

        public static async void InsertSensorDataAsync()
        {
                if (indicator != 1)
                {
                    Console.WriteLine("bool did not work");
                        return;
                }

            SqlConnection connection = new SqlConnection(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
            try
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("INSERT_DataEntry", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("SensorId", value: 1);
                command.Parameters.AddWithValue("Shelf", 1);
                command.Parameters.AddWithValue("PositionOnShelf", 1);
                command.Parameters.AddWithValue("FoodItemId", "3CC3819A - 66EC - 4008 - 8E22 - BBAF0E965969");
                command.Parameters.AddWithValue("ProductPresent", productPresent);


                int result = await command.ExecuteNonQueryAsync();
                await connection.CloseAsync();
                if (result > 0)
                    Console.WriteLine("inserted");
                else
                    Console.WriteLine("not");
            }
            catch (Exception e)
            {
                await connection.CloseAsync();
            }
        }
        }

    }

}

