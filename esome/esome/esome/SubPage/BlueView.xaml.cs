//using Android.Bluetooth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace esome.SubPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlueView : ContentView
    {
        //BluetoothDevice devtag;
        //const string SerialPortServiceClass_UUID = "00001101-0000-1000-8000-00805F9B34FB";
        //BluetoothSocket sock;
        public BlueView()
        {
            InitializeComponent();
        }

        //void Init()
        //{
        //    //BluetoothAdapter localAdapter = BluetoothAdapter.DefaultAdapter;
        //    //if (!localAdapter.IsEnabled)
        //    //{
        //    //    localAdapter.Enable();
        //    //}
        //    //BluetoothServerSocket serverSock = localAdapter.ListenUsingRfcommWithServiceRecord("Bluetooth", Java.Util.UUID.FromString("xxxx-xxxx-xxxx-xxxx-xxxxxxx"));
        //    //BluetoothSocket ssock = serverSock.Accept();
        //    //serverSock.Close();//服务器获得连接后及时关闭ServerSocket
        //    ////启动新的线程，开始数据传输
        //    //Thread st = new Thread(connected);
        //    //st.Start(ssock);


        //    //StreamReader sReader = new StreamReader(ssock.InputStream);
        //    //StreamWriter sWriter = new StreamWriter(ssock.OutputStream);
        //}
        //void Listen()
        //{
        //    sock = devtag.CreateRfcommSocketToServiceRecord(Java.Util.UUID.FromString(SerialPortServiceClass_UUID));
        //    try
        //    {
        //        sock.Connect();//连接服务器
        //        //启动新的线程，开始传输数据
        //        void method(object s) => Connected((BluetoothSocket)s);
        //        Thread t = new Thread(method);
        //        t.Start(sock);
        //    }
        //    catch (Exception e)
        //    {
        //        sock.Dispose();
        //    }
        //}
        //void Connected(BluetoothSocket sock)
        //{
        //    if (sock != null && sock.IsConnected)
        //    {
        //        while (true)
        //        {
        //            StreamReader reader = new StreamReader(sock.InputStream);
        //            string data = reader.ReadToEnd();
        //            AppendText(data);
        //        }
        //    }
        //}
        private void Btn_Init_Clicked(object sender, EventArgs e)
        {
            //    BluetoothAdapter localAdapter = BluetoothAdapter.DefaultAdapter;
            //    if (!localAdapter.IsEnabled)
            //    {
            //        localAdapter.Enable();
            //    }
            //    DateTime end = DateTime.Now.AddSeconds(30);
            //    while (localAdapter.State != State.On && localAdapter.State != State.Connected)
            //    {
            //        if (DateTime.Compare(DateTime.Now, end) > 0) break;
            //    }
            //    List<BluetoothDevice> bondedDevices = new List<BluetoothDevice>(localAdapter.BondedDevices);
            //    foreach (BluetoothDevice d in bondedDevices)
            //    {
            //        devtag = d;
            //        txtmsg.Text += $"{d.Name}{Environment.NewLine}{d.Address}{Environment.NewLine}";
            //    }
        }
        void AppendText(string text)
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                txtmsg.Text += text;
            });
        }

        private void Btn_Listen_Clicked(object sender, EventArgs e)
        {
            //    Listen();
        }

        private void TxtCmd_Completed(object sender, EventArgs e)
        {
            //if (sock != null && sock.IsConnected)
            //{
            //    StreamWriter writer = new StreamWriter(sock.OutputStream);
            //    writer.WriteLine(((Editor)sender).Text);
            //    ((Editor)sender).Text = "";
            //}
        }
    }
}