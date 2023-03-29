using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseController : MonoBehaviour
{
   public ChoiceController label;
   public GameController gameController;
   public DialogController controller;

   public void DisplayChoices(ChooseScene scene)
   {
      gameObject.SetActive(true);
      float labelHeight = -1;
      for (int index = 0; index < scene.labels.Count; index++)
      {
         ChoiceController choice = Instantiate(label.gameObject, transform).GetComponent<ChoiceController>();
         choice.choiceText.text = scene.labels[index].text;
         choice.scene = scene.labels[index].nextScene;
      }
   }
   
   public void PerformChoose(StoryScene scene)
   {
      gameController.PlayScene(scene as GameScene);
      DestroyLabels();
   }

   public void HideChoicePanel()
   {
      gameObject.SetActive(false);
   }
   
   private void DestroyLabels()
   {
      foreach(Transform childTransform in transform)
      {
         Destroy(childTransform.gameObject);
      }

      HideChoicePanel();
   }

}
