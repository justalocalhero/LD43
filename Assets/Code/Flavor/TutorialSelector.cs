using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialSelector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

	public GameObject tutorialWindow;

    public void OnPointerEnter(PointerEventData eventData)
    {
        tutorialWindow.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tutorialWindow.SetActive(false);
    }
}
