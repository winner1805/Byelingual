using UnityEngine;
using UnityEngine.UI;

namespace Assets.StoryTemplate.Infrastructure
{
    public abstract class FindObject<T>
    {
        public static T Named(string name)
        {
            var obj = GameObject.Find(name).GetComponent<T>();
            return obj;
        }

        
    }

    public class FindCanvas : FindObject<Canvas>
    {

    }

    public class FindImage : FindObject<Image>
    {

    }

    public class FindButton : FindObject<Button>
    {

    }
}
