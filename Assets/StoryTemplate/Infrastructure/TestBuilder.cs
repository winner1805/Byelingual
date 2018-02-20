using UnityEngine;

namespace Assets.StoryTemplate.Infrastructure
{
    public abstract class TestBuilder<T>
    {

        public abstract T Build();

        

        public static implicit operator T(TestBuilder<T> builder)
        {
            return builder.Build();
        }
    }
}
