using UnityEngine;

namespace Assets.StoryTemplate.Infrastructure
{
    public abstract class FindObject<T>
    {
        public static T Named(string name)
        {
            return GameObject.Find(name).GetComponent<T>();
        }
    }

    public class FindCanvas : FindObject<Canvas>
    {

    }
}
