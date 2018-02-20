using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using Debug = UnityEngine.Debug;

namespace Assets
{
    public static class Resources
    {
        private const string GameUri = "http://api.byelingual.me:8000/";

        public static string GetStringResponse(string apiSource)
        {
            // Create a request for the URL.   
            var request = WebRequest.Create(new Uri(GameUri + apiSource +"/"));
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.  
            var response = request.GetResponse();
            // Display the status.  
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.  
            var dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.  
            var reader = new StreamReader(dataStream);
            // Read the content.  
            var responseFromServer = reader.ReadToEnd();
            // Clean up the streams and the response.  
            reader.Close();
            response.Close();

            
            //Return the value
            //Debug.Log(responseFromServer);
            return responseFromServer;
        }

        public static Bitmap GetBitmapFromURL(string apiSource)
        {
            // Create a request for the URL.   
            var request = WebRequest.Create(new Uri(GameUri + apiSource));
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.  
            var response = request.GetResponse();
            // Display the status.  
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.  
            var dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.  
            var bitmap = new Bitmap(dataStream);

            // Clean up the streams and the response.  
            
            response.Close();


            //Return the value
            //Debug.Log(responseFromServer);
            return bitmap;
        }

       
    }
}