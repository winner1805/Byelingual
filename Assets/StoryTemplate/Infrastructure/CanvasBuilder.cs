using UnityEngine;

namespace Assets.StoryTemplate.Infrastructure
{
    public class CanvasBuilder : TestBuilder<Canvas>
    {

        

        
       

        public override Canvas Build()
        {
            var canvas = new GameObject().AddComponent<Canvas>();
            canvas.name = _name;
            return canvas;
        }
    }
}
