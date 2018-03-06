using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.StoryTemplate.Infrastructure;

namespace Assets.StoryTemplate
{
    class CabinInTheWoods : Story
    {
        public CabinInTheWoods(string name, string description, string imageUrl) : base(name, description, imageUrl)
        {
            IntroImage = An.Image().Named("CabinIntroImage");
            IntroImage.sprite = 
        }
    }
}
