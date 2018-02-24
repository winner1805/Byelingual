using UnityEngine;
using UnityEngine.UI;

namespace Assets.StoryTemplate.Infrastructure
{
    public class ImageBuilder : TestBuilder<Image>
    {

        public override Image Build()
        {
            var image = new GameObject().AddComponent<Image>();
            image.name = _name;
            return image;
        }
    }
}
