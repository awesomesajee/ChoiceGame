using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameScene currentScene;
    public DialogController controller;
    public BackgroundController backgroundController;
    public ChooseController chooseController;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        if (currentScene is StoryScene)
        {
            StoryScene storyScene = currentScene as StoryScene;
            controller.PlayScene(storyScene);
            backgroundController.SwitchBackground(storyScene.background);
            chooseController.HideChoicePanel();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (controller.IsCompleted())
            {
                if (controller.IsLastSentence())
                {
                    PlayScene((currentScene as StoryScene).nextScene);
                }
                else
                {
                    controller.PlayNextSentence();
                }
            }
        }

    }
    
    public void PlayScene(GameScene scene)
    {
        StartCoroutine(SwitchScene(scene));
    }
    
    private IEnumerator SwitchScene(GameScene scene)
    {
        currentScene = scene;
        yield return new WaitForSeconds(1f);
        if (scene is StoryScene)
        {
            StoryScene storyScene = scene as StoryScene;
            backgroundController.SwitchBackground(storyScene.background);
            yield return new WaitForSeconds(1f);
            yield return new WaitForSeconds(1f);
            controller.PlayScene(storyScene);
        }
        else if (scene is ChooseScene)
        {
            chooseController.DisplayChoices(scene as ChooseScene);
        }
    }
}
