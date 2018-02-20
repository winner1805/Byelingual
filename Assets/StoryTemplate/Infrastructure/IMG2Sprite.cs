﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.StoryTemplate.Infrastructure
{
    public class IMG2Sprite : MonoBehaviour
    {
        // This script loads a PNG or JPEG image from disk and returns it as a Sprite
        // Drop it on any GameObject/Camera in your scene (singleton implementation)
        //
        // Usage from any other script:
        // MySprite = IMG2Sprite.instance.LoadNewSprite(mediaUrl, [PixelsPerUnit (optional)])

        private static IMG2Sprite _instance;

        public static IMG2Sprite instance
        {
            get
            {
                //If _instance hasn't been set yet, we grab it from the scene!
                //This will only happen the first time this reference is used.

                if (_instance == null)
                    _instance = GameObject.FindObjectOfType<IMG2Sprite>();
                return _instance;
            }
        }

        public Sprite LoadNewSprite(string mediaUrl, float PixelsPerUnit = 100.0f)
        {

            // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference

            Sprite NewSprite = new Sprite();
            var SpriteTexture = LoadTexture(mediaUrl);
            NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPerUnit);

            return NewSprite;
        }

        public static Texture2D LoadTexture(string url)
        {

            // Load a PNG or JPG file from disk to a Texture2D
            // Returns null if load fails

            var Tex2D = new Texture2D(2,2);
            var ms = new MemoryStream();

            
            {
                var bitmapFromUrl = Resources.GetBitmapFromURL(url);
                bitmapFromUrl.Save(ms, bitmapFromUrl.RawFormat);

                
                if (Tex2D.LoadImage(ms.ToArray()))           // Load the imagedata into the texture (size is set automatically)
                    return Tex2D;                 // If data = readable -> return texture
            }
            return null;                     // Return null if load failed
        }
    }
}
