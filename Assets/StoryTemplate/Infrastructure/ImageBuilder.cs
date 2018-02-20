using UnityEngine;
using UnityEngine.UI;

namespace Assets.StoryTemplate.Infrastructure
{
    public class ImageBuilder : TestBuilder<Image>
    {

        private string _name = "UnnamedImage";


        public ImageBuilder Named(string name)
        {
            _name = name;
            return this;
        }

        public override Image Build()
        {
            var image = new GameObject().AddComponent<Image>();
            image.name = _name;
            return image;
        }
    }
}
