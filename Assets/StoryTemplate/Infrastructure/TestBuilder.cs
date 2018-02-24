using UnityEngine;

namespace Assets.StoryTemplate.Infrastructure
{
    public abstract class TestBuilder<T>
    {
        protected string _name;
        public abstract T Build();

        public TestBuilder<T> Named(string name)
        {
            _name = name;
            return this;
        }

        public static implicit operator T(TestBuilder<T> builder)
        {
            return builder.Build();
        }
    }

}
