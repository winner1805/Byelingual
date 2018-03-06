using UnityEngine;
using UnityEngine.UI;

namespace Assets.StoryTemplate.Infrastructure
{
    public static class VisualEffects
    {
        public static Color Blush(Color color, float targetAlpha, float fadeRate)
        {
            Color curColor = color;
            float alphaDiff = Mathf.Abs(curColor.a - targetAlpha);
            if (alphaDiff > 0.0001f)
            {
                //Lerp linear interpolation
                curColor.a = Mathf.Lerp(curColor.a, targetAlpha, fadeRate * Time.deltaTime);
                
            }

            return curColor;
        }

        public static void ImageFadeIn(Image image, float targetAlpha, float fadeRate)
        {

            image.color = Blush(image.color, targetAlpha, fadeRate);
            
        }



        public static void SetImageTransparent(Image image)
        {
            var curColour = image.color;
            curColour.a = 0f;
            image.color = curColour;
        }

        public static void SetTextTransparent(Text text)
        {
            var curColour = text.color;
            curColour.a = 0f;
            text.color = curColour;
        }
    }
}
