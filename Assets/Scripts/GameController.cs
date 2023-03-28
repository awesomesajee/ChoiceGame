using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public StoryScene currentScene;
    public DialogController controller;
    public BackgroundController backgroundController;
    public ChooseController chooseController;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        controller.PlayScene(currentScene);
        chooseController.HideChoicePanel();
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
                    if (currentScene.choices != null)
                    {
                        chooseController.DisplayChoices(currentScene.choices);
                        controller.PlayScene(chooseController.label.scene);
                    }
                    currentScene = currentScene.nextScene;
                    controller.PlayScene(currentScene);
                    backgroundController.SwitchBackground(currentScene.background);
                }
                else
                {
                    controller.PlayNextSentence();
                }
            }
        }

    }
}
