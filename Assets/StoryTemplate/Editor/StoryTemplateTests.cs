﻿using System;
using System.IO;
using Assets.StoryTemplate.Infrastructure;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Net;


namespace Assets.StoryTemplate.Editor
{
    public class StoryTemplateTests {
    
        public class Canvases
        {

            private static Canvas GetCanvas(string cnvName)
            {
                return GameObject.Find(cnvName).GetComponent<Canvas>();
            }

            [Test]
            public void _Canvas_Can_Be_Created()
            {

                var canvas = (Canvas) A.Canvas().Named("TestCanvas");

                Assert.IsNotNull(canvas);
            }

            [Test]
            public void _Image_Can_Be_Created()
            {

                var image = (Image)An.Image().Named("TestImage");

                Assert.IsNotNull(image);
            }


            [Test]
            public void Is_The_StoryCanvas_Present()
            {
                const string cnvName = "StoryCanvas";
                var canvas = (Canvas) A.Canvas().Named(cnvName);

                Assert.IsNotNull(canvas);
                Assert.AreEqual(cnvName, canvas.name);
            }

            [Test]
            public void _Add_An_Image_To_A_Canvas()
            {
                var canvas =(Canvas) A.Canvas().Named("Canvas");
                var image = (Image) An.Image().Named("Image");
                image.transform.SetParent(canvas.transform, false);

                Assert.AreEqual(canvas.transform.Find("Image").name, image.name);

            }

            [Test]
            public void Is_The_StoryIntroCanvas_Present()
            {
                const string cnvName = "StoryIntroCanvas";
                var canvas = GetCanvas(cnvName);

                Assert.IsNotNull(canvas);
            }

            [Test]
            public void Is_The_StoryCharacterDialogCanvas_Present()
            {
                const string cnvName = "StoryCharacterDialogCanvas";
                var canvas = GetCanvas(cnvName);

                Assert.IsNotNull(canvas);
            }

            [Test]
            public void Is_The_StoryObjectDialogCanvas_Present()
            {
                const string cnvName = "StoryObjectDialogCanvas";
                var canvas = GetCanvas(cnvName);

                Assert.IsNotNull(canvas);
            }

            [Test]
            public void Is_The_StoryMemorySequenceCanvas_Present()
            {
                const string cnvName = "StoryMemorySequenceCanvas";
                var canvas = GetCanvas(cnvName);
                
                Assert.IsNotNull(canvas);
            }

            [Test]
            public void Is_The_StoryEndingCanvas_Present()
            {
                const string cnvName = "StoryEndingCanvas";
                var canvas = GetCanvas(cnvName);
                
                Assert.IsNotNull(canvas);
            }
        }

        public class Buttons
        {
            private static Button GetButton(string btnName)
            {
                return GameObject.Find(btnName).GetComponent<Button>();
            }

            [Test]
            public void Exit_Button_Present()
            {
                var btnName = "btnExit";
                var testButton = GetButton(btnName);

                Assert.IsNotNull(testButton);
            
            }
            
            [Test]
            public void Can_Download_Story_List_From_Game_URI()
            {
                // Create a request for the URL.   
                WebRequest request = WebRequest.Create(new Uri(Resources.GAME_URI + "stories/"));
                // If required by the server, set the credentials.  
                request.Credentials = CredentialCache.DefaultCredentials;
                // Get the response.  
                WebResponse response = request.GetResponse();
                // Display the status.  
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.  
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseFromServer = reader.ReadToEnd();
                // Display the content.  
                Debug.Log(responseFromServer);
                // Clean up the streams and the response.  
                reader.Close();
                response.Close();

            }

            private void GetJsonResponse(IAsyncResult ar)
            {
                throw new NotImplementedException();
            }
        }
    }
}
