using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchCharacter : MonoBehaviour
{
    public Image character;

    public void DisplayCharacter(Sprite character)
    {
        this.character.sprite = character;
    }

}
