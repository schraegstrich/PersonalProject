using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.Data.SqlClient;
using Models;
using System.Windows.Input;

    namespace API.Services
    {
        public class SensorInsertService
        {
            static SerialPort serialPort;
            static List<string> data = new List<string>(); 
            static int maxLines = 5; 
            public static int productPresent { get; set; }
            static int indicator = -1;
            public SqlConnection connection = new SqlConnection(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));

            public async Task SerialPortLauncher()
            {
                serialPort = new SerialPort("COM4", 9600);
                serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                serialPort.Open();

            }

            public static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
            {
                SerialPort sp = (SerialPort)sender;

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
                            serialPort.Close();
                            break;
                        }

                        if (data.Count == maxLines - 1 && data[data.Count - 1].Contains('1'))
                        {
                            productPresent = 1;
                            indicator = 1;
                        }

                        if (data.Count == maxLines - 1 && data[data.Count - 1].Contains('0'))
                        {
                            productPresent = 0;
                            indicator = 1;
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        throw new Exception();
                    }
                }
            }

        //
        /*public async Task<bool> InsertSensorDataAsync(SensorDataEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry), "Sensor data entry is null.");
            }

            SerialPortLauncher();

            await Task.Delay(5000);

            string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Database connection string is not configured.");
            }

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("INSERT_DataEntry", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                entry.ProductPresent = productPresent;

                command.Parameters.AddWithValue("@SensorId", entry.SensorId);
                command.Parameters.AddWithValue("@Shelf", entry.Shelf);
                command.Parameters.AddWithValue("@PositionOnShelf", entry.PositionOnShelf);
                command.Parameters.AddWithValue("@FoodItemId", entry.FoodItemId);
                command.Parameters.AddWithValue("@ProductPresent", entry.ProductPresent);

                // Log the command and parameters for debugging
                Console.WriteLine($"Executing command: {command.CommandText}");
                foreach (SqlParameter param in command.Parameters)
                {
                    Console.WriteLine($"{param.ParameterName}: {param.Value}");
                }

                int result = await command.ExecuteNonQueryAsync();
                await connection.CloseAsync();

                return result > 0;
            }
            catch (SqlException sqlEx)
            {
                System.Diagnostics.Debug.WriteLine($"SQL error: {sqlEx.ToString()}");
                await connection.CloseAsync();
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"General error: {ex.ToString()}");
                await connection.CloseAsync();
                return false;
            }
        }*/


            public async Task<bool> InsertSensorDataAsync(int sensorId, int shelf, int position, Guid foodItemId)
            {
                
                await SerialPortLauncher();
                //if (indicator != 1)
                //{
                //throw new Exception("data transfer failed");
                //}

                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand("INSERT_DataEntry", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("SensorId",  sensorId);
                    command.Parameters.AddWithValue("Shelf", shelf);
                    command.Parameters.AddWithValue("PositionOnShelf", position);
                    command.Parameters.AddWithValue("FoodItemId", foodItemId);
                    command.Parameters.AddWithValue("ProductPresent", productPresent);

                    int result = await command.ExecuteNonQueryAsync();
                    await connection.CloseAsync();
                if (result > 0)
                    return true;
                else
                    return false;
                }
                catch (Exception e)
                {
                    await connection.CloseAsync();
                    return false;
                }
            }
        }

    }
