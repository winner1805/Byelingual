﻿using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.StoryTemplate
{
    public class GameController : MonoBehaviour
    {

        private List<Story> _stories;
        // Use this for initialization
        void Start () {
            var jsonString = Resources.GetStringResponse("stories");
            _stories = new List<Story>();
            var jsonStories = JSON.Parse(jsonString);

            
            

            var storyCount = jsonStories["stories"].Count;
            for (var i = 0; i < storyCount; i++)
            {
                _stories.Add(
                    new Story(
                        jsonStories["stories"][i]["name"].ToString(),
                        jsonStories["stories"][i]["description"].ToString(),
                        jsonStories["stories"][i]["image"].ToString()
                    )
                );
            }

            var c = GameObject.Find("StoryCanvas").GetComponent<Canvas>();
            c.transform.SetAsLastSibling();

            var t = GameObject.Find("txStoryList").GetComponent<Text>();
            t.text = "";

            foreach (var story in _stories)
            {
                t.text += story + "\n";

            }

        }
	
        // Update is called once per frame
        void Update () {
           
        }
    }
}
