namespace Assets.StoryTemplate.Infrastructure
{
    public static class A
    {
        public static CanvasBuilder Canvas()
        {
            return new CanvasBuilder();
        }

        public static ButtonBuilder Button()
        {
            return new ButtonBuilder();
        }

        public static GameObjectBuilder GameObject()
        {
            return new GameObjectBuilder();
        }

        public static SceneBuilder Scene()
        {
            return new SceneBuilder();
            
        }
    }
}
