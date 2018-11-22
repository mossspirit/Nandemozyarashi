using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialDemo : MonoBehaviour {

    [SerializeField]
    SerialMain serial;

    public void OnPushed()
    {
        byte[] data = new byte[1];
        data[0] = 0x61; //aを送信
        serial.Write(data);
    }

}