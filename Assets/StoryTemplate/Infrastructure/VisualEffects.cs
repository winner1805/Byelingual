using UnityEngine;
using UnityEngine.UI;

namespace Assets.StoryTemplate.Infrastructure
{
    public static class VisualEffects
    {
        public static void FadeIn(Image image, float targetAlpha, float fadeRate)
        {
            Color curColor = image.color;
            float alphaDiff = Mathf.Abs(curColor.a - targetAlpha);
            if (alphaDiff > 0.0001f)
            {
                //Lerp linear interpolation
                curColor.a = Mathf.Lerp(curColor.a, targetAlpha, fadeRate * Time.deltaTime);
                image.color = curColor;
            }
        }

        public static void SetImageTransparent(Image image)
        {
            var curColour = image.color;
            curColour.a = 0f;
            image.color = curColour;
        }
    }
}
