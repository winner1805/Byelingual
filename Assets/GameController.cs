using Assets.StoryTemplate.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets
{
    public class GameController : MonoBehaviour
    {
        
        private List<Story> _stories;
        private List<Canvas> _canvases;
        private bool _init = true;
        
        

        // Use this for initialization
        private void Start()
        {
            _canvases = new List<Canvas>();
            //
            _stories = new List<Story>();
            _stories = Resources.GetStoriesFromInternet();

            var exitButton = FindButton.Named("ExitButton");
            
            exitButton.onClick.AddListener(ExitGame);
            Debug.Log("x");

            //Canvas initialization
            var mainMenuCanvas = FindCanvas.Named("MainMenuCanvas");
            _canvases.Add(mainMenuCanvas);


            



            /*Button initialization
            _exitButton = GameObject.Find("btnExit").GetComponent<Button>();
            

            //Assigning Methods to Unity actions
            _exit += ExitGame;
            

            //Assigning Unity actions to button Events
            _exitButton.onClick.AddListener(_exit);
            */

        }


        private async void LoadButtons()
        {
            
            if (_stories.Count > 0)
            {
                var a = IMG2Sprite.Instance(_stories[0].SnakeCase() + "spriter");
                var b = IMG2Sprite.Instance(_stories[1].SnakeCase() + "spriter");
                FindImage.Named("ImageStory1").sprite = await a.LoadNewSprite(_stories[0].ImageUrl);
                FindImage.Named("ImageStory2").sprite = await b.LoadNewSprite(_stories[1].ImageUrl); 
              
            }
            
        }

        // Update is called once per frame
        private void Update()
        {
            if (_init)
            {
                LoadButtons();
                _init = false;
            }
            
        }

        

        private static void ExitGame()
        {
            Debug.Log("Exit game");
            Application.Quit();
        }

        private void StartStory1()
        {
            //hiding main menu and showing the story 1 intro
            DisableAllCanvases();
            //_story1Intro.enabled = true;
        }

        private void ExitStory1Intro()
        {
            //Remove this method - It's only for testing
            DisableAllCanvases();
            //_story1Intro.enabled = false;
        }

        public void DisableAllCanvases()
        {
            foreach (var canvas in _canvases)
            {
                canvas.enabled = false;
            }
        }

        public void EnableCanvas(Canvas canvas)
        {
            DisableAllCanvases();
            canvas.enabled = true;
        }
    }
}