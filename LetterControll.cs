using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterControll : MonoBehaviour
{
    public ScriptableObjectItems SOItems;
    public List<Sprite> allItems;
    public GameObject prefItemButton;

    public GameObject panelItemButtons;




    private Sprite thisQuest;
    private int thisQuestIndex;

    private int firstQuest, secondQuest, thirdQuest;
    private bool _first, _second, _third;

    private int _whatIsLevel;

    private GameObject questGO;
    public List<GameObject> otherItemsGO;

    public GameObject restartLevelButton;

    private int otherGO1, otherGO2, otherGO3, otherGO4, otherGO5, otherGO6, otherGO7, otherGO8;

    public Text nameQuestText;

    void Start()
    {
        allItems = SOItems.allItems;
        StartCoroutine("GetQuestIE");
    }

    public void TESTBUTTONCLICK()
    {
       // questGO.transform.SetSiblingIndex(2);
       RandomPosition();
    }

    IEnumerator GetQuestIE()
    {
        int rndQuest = Random.Range(0, allItems.Count);
        Debug.Log("RndQuest = " + rndQuest);
        if(!_first)
        {
            TakeQuestLetter(rndQuest);
            yield return 0;
        }
        else if(!_second)
        {
            while(rndQuest == firstQuest)
            {
                rndQuest = Random.Range(0, allItems.Count);
            }
            TakeQuestLetter(rndQuest);
            yield return 0;
        }
        else if(!_third)
        {
            while(rndQuest == firstQuest || rndQuest == secondQuest)
            {
                rndQuest = Random.Range(0, allItems.Count);
            }
            TakeQuestLetter(rndQuest);
            yield return 0;
        }


        yield return 0;
    }

    private void TakeQuestLetter(int i)
    {
        thisQuestIndex = i;
        thisQuest = allItems[i];

        questGO = Instantiate(prefItemButton, panelItemButtons.transform);
        questGO.GetComponent<Button>().onClick.AddListener(ClickQuestButton);
        GameObject questImageGO = questGO.transform.GetChild(0).gameObject;
        questImageGO.GetComponent<Image>().sprite = allItems[i];

        if(!_first)
        {
            _first = true;
            firstQuest = thisQuestIndex;
            _whatIsLevel = 1;
        }
        else if(!_second)
        {
            _second = true;
            secondQuest = thisQuestIndex;
            _whatIsLevel = 2;
        }
        else if(!_third)
        {
            _third = true;
            thirdQuest = thisQuestIndex;
            _whatIsLevel = 3;
        }

        nameQuestText.text = "Find - " + thisQuest.name;

        SpawnOthersLetters();

        Debug.Log("Quest letter - " + thisQuest.name + " - " + thisQuestIndex);

        RandomPosition();
    }

    private void SpawnOthersLetters()
    {
        switch(_whatIsLevel)
        {
            case 1:
                for(int i = 0; i < 2; i++)
                {
                    int rndOtherLetter = Random.Range(0, allItems.Count);
                    while(rndOtherLetter == firstQuest || otherGO1 == rndOtherLetter)
                    {
                        rndOtherLetter = Random.Range(0, allItems.Count);
                    }
                    if(i == 0) otherGO1 = rndOtherLetter;
                    GameObject otherLetterGO = Instantiate(prefItemButton, panelItemButtons.transform);
                    otherLetterGO.GetComponent<Button>().onClick.AddListener(ClickOtherLetterButton);
                    otherItemsGO.Add(otherLetterGO);
                    GameObject otherLetterImageGO = otherLetterGO.transform.GetChild(0).gameObject;
                    otherLetterImageGO.GetComponent<Image>().sprite = allItems[rndOtherLetter];
                    Debug.Log("Spawn other letter - " + otherLetterImageGO.GetComponent<Image>().sprite.name + " - " + rndOtherLetter);
                }
            break;
            case 2:
                for(int i = 0; i < 5; i++)
                {
                    int rndOtherLetter = Random.Range(0, allItems.Count);
                    while(rndOtherLetter == secondQuest || otherGO1 == rndOtherLetter || otherGO2 == rndOtherLetter || otherGO3 == rndOtherLetter
                    || otherGO4 == rndOtherLetter || otherGO5 == rndOtherLetter)
                    {
                        rndOtherLetter = Random.Range(0, allItems.Count);
                    }
                    if(i == 0) otherGO1 = rndOtherLetter;
                    if(i == 1) otherGO2 = rndOtherLetter;
                    if(i == 2) otherGO3 = rndOtherLetter;
                    if(i == 3) otherGO4 = rndOtherLetter;
                    if(i == 4) otherGO5 = rndOtherLetter;
                    GameObject otherLetterGO = Instantiate(prefItemButton, panelItemButtons.transform);
                    otherLetterGO.GetComponent<Button>().onClick.AddListener(ClickOtherLetterButton);
                    otherItemsGO.Add(otherLetterGO);
                    GameObject otherLetterImageGO = otherLetterGO.transform.GetChild(0).gameObject;
                    otherLetterImageGO.GetComponent<Image>().sprite = allItems[rndOtherLetter];
                    Debug.Log("Spawn other letter - " + otherLetterImageGO.GetComponent<Image>().sprite.name + " - " + rndOtherLetter);
                }
            break;
            case 3:
                for(int i = 0; i < 8; i++)
                {
                    int rndOtherLetter = Random.Range(0, allItems.Count);
                    while(rndOtherLetter == thirdQuest|| otherGO1 == rndOtherLetter || otherGO2 == rndOtherLetter || otherGO3 == rndOtherLetter
                    || otherGO4 == rndOtherLetter || otherGO5 == rndOtherLetter || otherGO6 == rndOtherLetter || otherGO7 == rndOtherLetter
                    || otherGO8 == rndOtherLetter)
                    {
                        rndOtherLetter = Random.Range(0, allItems.Count);
                    }
                    if(i == 0) otherGO1 = rndOtherLetter;
                    if(i == 1) otherGO2 = rndOtherLetter;
                    if(i == 2) otherGO3 = rndOtherLetter;
                    if(i == 3) otherGO4 = rndOtherLetter;
                    if(i == 4) otherGO5 = rndOtherLetter;
                    if(i == 5) otherGO6 = rndOtherLetter;
                    if(i == 6) otherGO7 = rndOtherLetter;
                    if(i == 7) otherGO8 = rndOtherLetter;
                    GameObject otherLetterGO = Instantiate(prefItemButton, panelItemButtons.transform);
                    otherLetterGO.GetComponent<Button>().onClick.AddListener(ClickOtherLetterButton);
                    otherItemsGO.Add(otherLetterGO);
                    GameObject otherLetterImageGO = otherLetterGO.transform.GetChild(0).gameObject;
                    otherLetterImageGO.GetComponent<Image>().sprite = allItems[rndOtherLetter];
                    Debug.Log("Spawn other letter - " + otherLetterImageGO.GetComponent<Image>().sprite.name + " - " + rndOtherLetter);
                }
            break;
        }
    }

    private void RandomPosition()
    {
        if(_whatIsLevel == 1)
        {
            int rndIndex = Random.Range(0, 3);
            questGO.transform.SetSiblingIndex(rndIndex);
            Debug.Log("Change index quest - " + rndIndex);
        }
        else if(_whatIsLevel == 2)
        {
            int rndIndex = Random.Range(0, 6);
            questGO.transform.SetSiblingIndex(rndIndex);
            Debug.Log("Change index quest - " + rndIndex);
        }
        else if(_whatIsLevel == 3)
        {
            int rndIndex = Random.Range(0, 9);
            questGO.transform.SetSiblingIndex(rndIndex);
            Debug.Log("Change index quest - " + rndIndex);
        }
    }

    public void ClickQuestButton()
    {
        Debug.Log("Click quest button");
        Destroy(questGO);
        for(int i = 0; i < otherItemsGO.Count; i++)
        {
            Destroy(otherItemsGO[i]);
        }
        otherItemsGO.Clear();

        if(_whatIsLevel == 3)
            RestartLevels();

        StartCoroutine("GetQuestIE");
    }

    public void ClickOtherLetterButton()
    {
        Debug.Log("Click other letter button");
    }

    private void RestartLevels()
    {
        restartLevelButton.SetActive(true);
    }

    public void ClickRestartLevels()
    {
        firstQuest = 0;
        secondQuest = 0;
        thirdQuest = 0;
        _first = false;
        _second = false;
        _third = false;
        _whatIsLevel = 0;

        restartLevelButton.SetActive(false);

        StartCoroutine("GetQuestIE");
    }





    private void TakeLettersForString(string questLetter)
    {
        thisQuest = allItems.Find(p => p.name == questLetter);
        thisQuestIndex = allItems.FindIndex(p => p.name == questLetter);

        if(!_first)
        {
            _first = true;
            firstQuest = thisQuestIndex;
        }
        else if(!_second)
        {
            _second = true;
            firstQuest = thisQuestIndex;
        }
        else if(!_third)
        {
            _third = true;
            firstQuest = thisQuestIndex;
        }

        Debug.Log(thisQuest.name + " - " + thisQuestIndex);
    }
}
