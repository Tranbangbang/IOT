using System;
using System.IO.Ports;
using System.Net.Sockets;
using System.Net;
using System.Text;

class Program
{
    #region.guidata
    /* // gui data
    static void Main()
    {
        try
        {
            //COM3 → Đây là cổng giao tiếp serial dùng để gửi dữ liệu.
            //9600 → Baud rate (tốc độ truyền dữ liệu), thường là 9600 bit/giây.
            //8 → 8 bit dữ liệu cho mỗi byte gửi đi.
            //StopBits.One → Dùng 1 bit dừng (stop bit) để xác định điểm kết thúc của byte dữ liệu.
            SerialPort serialPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
            serialPort.Open();
            Console.WriteLine("Gửi dữ liệu tới COM3...");
            serialPort.WriteLine("Hello");
            serialPort.Close();
            Console.WriteLine("Dữ liệu đã gửi thành công.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi: " + ex.Message);
        }
    }
    */
    #endregion

    #region.gui va nhan data
    /* // gui va nhan lai data 
    static void Main()
    {
        try
        {
            SerialPort serialPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.Open();

            Console.WriteLine("Gửi lệnh tới COM3...");
            serialPort.WriteLine("Hello");

            Console.WriteLine("Chờ nhận phản hồi...");
            Console.ReadLine(); 
            serialPort.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi: " + ex.Message);
        }
    }

    private static void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        string response = sp.ReadExisting();
        Console.WriteLine("Nhận dữ liệu: " + response);
    }
    */
    #endregion

    #region.Gửi lệnh ESC/POS đến máy in
    /*
    static void Main()
    {
        SerialPort printer = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
        printer.Open();

        byte[] escInit = { 0x1B, 0x40 }; // Reset máy in
        byte[] text = Encoding.UTF8.GetBytes("Hóa đơn test\n");
        byte[] cutPaper = { 0x1D, 0x56, 0x01 }; // Lệnh cắt giấy

        printer.Write(escInit, 0, escInit.Length);
        printer.Write(text, 0, text.Length);
        printer.Write(cutPaper, 0, cutPaper.Length);

        printer.Close();
        Console.WriteLine("Đã gửi lệnh in.");
    }
    */
    #endregion

    #region.On OFF
    /*
    static void Main()
    {
        SerialPort device = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
        device.Open();

        while (true)
        {
            Console.Write("Nhập lệnh (ON/OFF): ");
            string command = Console.ReadLine();
            if (command.ToUpper() == "EXIT") break;

            device.WriteLine(command);
            Console.WriteLine($"Đã gửi lệnh: {command}");
        }

        device.Close();
    
    }
    */
    #endregion

    #region. gui nhan data lien tuc
    /*
    static SerialPort serialPort;
    static void Main()
    {
        serialPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
        serialPort.DataReceived += SerialPort_DataReceived;
        serialPort.Open();

        Thread sendThread = new Thread(SendData);
        sendThread.Start();

        Console.WriteLine("Nhấn Enter để dừng...");
        Console.ReadLine();

        serialPort.Close();
    }

    static void SendData()
    {
        while (true)
        {
            serialPort.WriteLine("Hello TranBangBang " + DateTime.Now);
            Thread.Sleep(3000); 
        }
    }

    static void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        string receivedData = serialPort.ReadExisting();
        Console.WriteLine("Nhận: " + receivedData);
    }
    */

    #endregion

    #region.ghi log file
    /*
    static string logFile = "serial_log.txt";
    static SerialPort serialPort;

    static void Main()
    {
        try
        {
            serialPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.DtrEnable = true;
            serialPort.RtsEnable = true;
            serialPort.Open();

            Console.WriteLine("Đang ghi log dữ liệu từ COM3...");
            Console.WriteLine("Chờ nhận dữ liệu....");

            while (true)
            {
                if (Console.ReadLine()?.ToLower() == "exit")
                {
                    break;
                }
            }

            serialPort.Close();
            Console.WriteLine("COM3 đã đóng.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Lỗi: COM3 đang bị chiếm.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khác: " + ex.Message);
        }
    }

    private static void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        try
        {
            string data = serialPort.ReadLine().Trim();
            Console.WriteLine("Dữ liệu nhận: " + data);

            File.AppendAllText(logFile, DateTime.Now + " - " + data + Environment.NewLine);
            Console.WriteLine("Dữ liệu đã ghi vào file: " + logFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi nhận dữ liệu: " + ex.Message);
        }
    }
    */
    #endregion
}
