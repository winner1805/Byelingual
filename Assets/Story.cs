namespace Assets
{
    public class Story
    {
        private string _name;
        private string _description;

        public Story(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public string Description
        {
            get { return _description; }
        }

        public override string ToString()
        {
            return _name;
        }
        

    }
}