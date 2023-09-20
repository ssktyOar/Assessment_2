using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SyncObject : MonoBehaviour
{
    [SerializeField]
    private long objectType;

    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private GameObject head;

    internal ServerSender serverSender;
    internal long objectID;

    MemoryStream stream;

    // Update is called once per frame
    internal byte[] GetInfo()
    {
        stream = new(new byte[60], 0, 60, true, true);
        stream.Write(serverSender.GetKey());
        stream.Write(BitConverter.GetBytes(objectType));
        stream.Write(BitConverter.GetBytes(gameObject.transform.position.x));
        stream.Write(BitConverter.GetBytes(gameObject.transform.position.y));
        stream.Write(BitConverter.GetBytes(gameObject.transform.position.z));
        stream.Write(BitConverter.GetBytes(head.transform.eulerAngles.x));
        stream.Write(BitConverter.GetBytes(gameObject.transform.eulerAngles.y));
        stream.Write(BitConverter.GetBytes(gameObject.transform.eulerAngles.z));
        stream.Write(BitConverter.GetBytes(rb.velocity.x));
        stream.Write(BitConverter.GetBytes(rb.velocity.y));
        stream.Write(BitConverter.GetBytes(rb.velocity.z));
        stream.Write(serverSender.GetKey());
        return stream.GetBuffer();
    }

    internal void AcceptInfo(ref byte[] data, int start)
    {
        gameObject.transform.position = new Vector3(BitConverter.ToSingle(data, start), BitConverter.ToSingle(data, start + 4), BitConverter.ToSingle(data, start + 8));
        head.transform.eulerAngles = gameObject.transform.position = new Vector3(BitConverter.ToSingle(data, start + 12), head.transform.eulerAngles.y, head.transform.eulerAngles.z);
        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, BitConverter.ToSingle(data, start + 16), BitConverter.ToSingle(data, start + 20));
        gameObject.transform.position = new Vector3(BitConverter.ToSingle(data, start + 24), BitConverter.ToSingle(data, start + 28), BitConverter.ToSingle(data, start + 32));
    }
}
