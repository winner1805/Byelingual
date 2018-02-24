using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.StoryTemplate
{
    public class GameController : MonoBehaviour
    {

        private List<Story> _stories;
        // Use this for initialization
        void Start ()
        {
            _stories = new List<Story>();
            _stories = Resources.GetStoriesFromInternet();

            var c = GameObject.Find("StoryCanvas").GetComponent<Canvas>();
            c.transform.SetAsLastSibling();

            var t = GameObject.Find("txStoryList").GetComponent<Text>();
            t.text = "";
            if (_stories.Count > 0) { 
                foreach (var story in _stories)
                {
                    t.text += story + "\n";

                }

            }
            else
            {
                t.text = "No stories to list, please buy! \nOr just maybe if you're not connected to internet, try that first.";
            }
        }

        

        // Update is called once per frame
        void Update () {
           
        }
    }
}
