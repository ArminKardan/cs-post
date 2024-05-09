using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;


public class Utilities
{
    public static byte[] HttpPost(string url, byte[] reqBytes)
    {
        try
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 20000;
            request.Method = "POST";
            request.Accept = "*/*";
            request.ContentType = "application/octet-stream";
            request.UserAgent = "okhttp/3.12.4";

            request.AutomaticDecompression = DecompressionMethods.None;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(reqBytes, 0, reqBytes.Length);
                stream.Close();
            }


            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();
            MemoryStream ms = new MemoryStream();
            response.GetResponseStream().CopyTo(ms);
            return ms.ToArray();
        }
        catch
        {
            return null;
        }
    }
}