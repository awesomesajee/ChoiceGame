using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ChoiceController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Color defaultColor;
    public Color hoveredColor;
    public StoryScene scene;
    public TextMeshProUGUI choiceText;
    private ChooseController controller;

    private void Start()
    {
        choiceText = GetComponent<TextMeshProUGUI>();
        choiceText.color = defaultColor;
        controller = transform.parent.GetComponent<ChooseController>();
    }

    public float GetLabelHeight()
    {
        return choiceText.rectTransform.sizeDelta.y * choiceText.rectTransform.localScale.y;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked");
        controller.PerformChoose(scene);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        choiceText.color = hoveredColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    { 
        choiceText.color = defaultColor;
    }
}
