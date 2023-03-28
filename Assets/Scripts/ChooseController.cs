using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseController : MonoBehaviour
{
   public ChoiceController label;

   public void DisplayChoices(ChooseScene scene)
   {
      gameObject.SetActive(true);
      float labelHeight = -1;
      for (int index = 0; index < scene.labels.Count; index++)
      {
         ChoiceController choice = Instantiate(label.gameObject, transform).GetComponent<ChoiceController>();
         choice.choiceText.text = scene.labels[index].text;
         choice.scene = scene.labels[index].nextScene;

         //if (labelHeight == -1)
         //{
         //labelHeight = choice.GetLabelHeight();
         //}
      }
   }

   public void HideChoicePanel()
   {
      gameObject.SetActive(false);
   }

   public void AdjustChoiceHeight()
   {
      
   }

}
