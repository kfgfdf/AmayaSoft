using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControll : MonoBehaviour
{
    private ItemsControll ItemsControll;
    public Text nameQuestText;
    public GameObject restartLevelButton;

    private void Start() 
    {
        ItemsControll = gameObject.GetComponent<ItemsControll>();
    }


    public void ChangeText(string text)
    {
        nameQuestText.text = "Find - " + text;
    }

    public void RestartLevelsUI()
    {
        restartLevelButton.SetActive(true);
    }

    public void ClickRestartLevelsUI()
    {
        restartLevelButton.SetActive(false);
        ItemsControll.RestartLevelsButton();
    }
}
