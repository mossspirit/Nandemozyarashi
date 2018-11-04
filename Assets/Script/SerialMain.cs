using System;
using System.IO.Ports;
using UnityEngine;
using UniRx;

public class SerialMain : MonoBehaviour
{

    public string portName;
    public int baurate;
    SerialPort serial;
    bool isLoop = true;
    public byte[] data = new byte[3];
    private byte[] comingByte = new byte[3];

    void Start()
    {
        this.serial = new SerialPort(portName, baurate, Parity.None, 8, StopBits.None);

        try
        {
            this.serial.Open();
        }
        catch (Exception e)
        {
            Debug.Log("can not open serial port");
        }
    }

    public void Write(byte[] buffer)
    {
        this.serial.Write(buffer, 0, 1);
    }

    void OnDestroy()
    {
        byte[] msg = new byte[1];
        msg[0] = 0;
        Write(msg);
        this.isLoop = false;
        this.serial.Close();
    }

}