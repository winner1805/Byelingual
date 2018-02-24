using UnityEngine;

namespace Assets.StoryTemplate.Infrastructure
{

    /*This abstract class contains common properties and methods for creation of various game objects 
     *Buttons, Canvases, Images, Scenes etc.
     *To implement it for creation of a Button, create a ButtonBuilder class to inherit ComponentBuilder<Button>
     *In ButtonBuilder class, override the Build() method to suit specific needs for button that differ from
     *other game objects, like button text
     *
     */
    public abstract class ComponentBuilder<T>
    {
        protected string _name;
        public abstract T Build();

        public ComponentBuilder<T> Named(string name)
        {
            _name = name;
            return this;
        }

        public static implicit operator T(ComponentBuilder<T> builder)
        {
            return builder.Build();
        }
    }

}
