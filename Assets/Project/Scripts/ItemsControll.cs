using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsControll : MonoBehaviour
{
    private UIControll UIControll;
    public ScriptableObjectItems[] ScriptableObjectItems;
    public ScriptableObjectItems SOItems;
    public ScriptableObjectLevels[] levels;

    public List<Sprite> allItems;
    public GameObject prefItemButton;

    public GameObject panelItemButtons;

    private Sprite thisQuest;
    private int thisQuestIndex;

    private int _whatIsLevel;

    private GameObject questGO;
    public List<GameObject> otherItemsGO;

    public List<int> othersIndex;

    void Start()
    {
        UIControll = gameObject.GetComponent<UIControll>();

        int rndItems = Random.Range(0, ScriptableObjectItems.Length);
        SOItems = ScriptableObjectItems[rndItems];

        allItems = SOItems.allItems;
        levels = SOItems.ScriptableObjectLevels;

        for(int i = 0; i < levels.Length; i++)
        {
            levels[i]._isComplete = false;
            levels[i]._INDEX = 0;
        }
        
        StartCoroutine("GetQuestIE");
    }

    public void TESTBUTTONCLICK()
    {
       RandomPosition();
    }

    IEnumerator GetQuestIE()
    {
        int rndQuest = Random.Range(0, allItems.Count);
        
        for(int i = 0; i < levels.Length; i++)
        {
            if(!levels[i]._isComplete)
            {
                _whatIsLevel = i;
                
                RectTransform rt = panelItemButtons.GetComponent<RectTransform>() as RectTransform;
                rt.sizeDelta = new Vector2 (levels[i]._countPilars * (10 + 100), levels[i]._countLines * (10 + 100));

                if(i == 0)
                {
                    TakeQuestLetter(rndQuest);
                    yield return 0;
                }
                else if(i == 1)
                {
                    while(rndQuest == levels[i-1]._INDEX)
                    {
                        rndQuest = Random.Range(0, allItems.Count);
                    }
                    TakeQuestLetter(rndQuest);
                    yield return 0;
                }
                else if(i == 2)
                {
                    while(rndQuest == levels[i-1]._INDEX || rndQuest == levels[i-2]._INDEX )
                    {
                        rndQuest = Random.Range(0, allItems.Count);
                    }
                    TakeQuestLetter(rndQuest);
                    yield return 0;
                }
                else if(i == 3)
                {
                    while(rndQuest == levels[i-1]._INDEX || rndQuest == levels[i-2]._INDEX || rndQuest == levels[i-3]._INDEX)
                    {
                        rndQuest = Random.Range(0, allItems.Count);
                    }
                    TakeQuestLetter(rndQuest);
                    yield return 0;
                }
                else if(i == 4)
                {
                    while(rndQuest == levels[i-1]._INDEX || rndQuest == levels[i-2]._INDEX || rndQuest == levels[i-3]._INDEX
                    || rndQuest == levels[i-4]._INDEX)
                    {
                        rndQuest = Random.Range(0, allItems.Count);
                    }
                    TakeQuestLetter(rndQuest);
                    yield return 0;
                }
                else if(i == 5)
                {
                    while(rndQuest == levels[i-1]._INDEX || rndQuest == levels[i-2]._INDEX || rndQuest == levels[i-3]._INDEX
                    || rndQuest == levels[i-4]._INDEX || rndQuest == levels[i-5]._INDEX)
                    {
                        rndQuest = Random.Range(0, allItems.Count);
                    }
                    TakeQuestLetter(rndQuest);
                    yield return 0;
                }

                Debug.Log("RndQuest = " + rndQuest);

                levels[i]._isComplete = true;
                levels[i]._INDEX = rndQuest;

                Debug.Log("GetQuestIE Complete");
                break;
            }
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

        UIControll.ChangeText(thisQuest.name);

        SpawnOthersLetters();

        Debug.Log("Quest letter - " + thisQuest.name + " - " + thisQuestIndex);

        RandomPosition();
    }

    private void SpawnOthersLetters()
    {
        int countOthers = levels[_whatIsLevel]._countLines * levels[_whatIsLevel]._countPilars - 1;
        for(int w = 0; w < countOthers; w++)
        {
            int rndOtherItem = Random.Range(0, allItems.Count);
            while(rndOtherItem == thisQuestIndex || rndOtherItem == othersIndex.Find(p => p == rndOtherItem))
            {
                rndOtherItem = Random.Range(0, allItems.Count);
            }
            othersIndex.Add(rndOtherItem);
            GameObject otherLetterGO = Instantiate(prefItemButton, panelItemButtons.transform);
            otherLetterGO.GetComponent<Button>().onClick.AddListener(ClickOtherLetterButton);
            otherItemsGO.Add(otherLetterGO);
            GameObject otherLetterImageGO = otherLetterGO.transform.GetChild(0).gameObject;
            otherLetterImageGO.GetComponent<Image>().sprite = allItems[rndOtherItem];
            Debug.Log("Spawn other letter - " + otherLetterImageGO.GetComponent<Image>().sprite.name + " - " + rndOtherItem);
        }

        Debug.Log("SpawnOthersLetters Complete");
    }

    private void RandomPosition()
    {
        int countCells = levels[_whatIsLevel]._countLines * levels[_whatIsLevel]._countPilars;
        int rndIndex = Random.Range(0, countCells);
        questGO.transform.SetSiblingIndex(rndIndex);
        Debug.Log("Change index quest - " + rndIndex);
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

        if(_whatIsLevel == levels.Length - 1)
            RestartLevels();

        othersIndex.Clear();

        StartCoroutine("GetQuestIE");
    }

    public void ClickOtherLetterButton()
    {
        Debug.Log("Click other letter button");
    }

    private void RestartLevels()
    {
        UIControll.RestartLevelsUI();
    }

    public void RestartLevelsButton()
    {
        for(int i = 0; i < levels.Length; i++)
        {
            levels[i]._isComplete = false;
            levels[i]._INDEX = 0;
        }

        int rndItems = Random.Range(0, ScriptableObjectItems.Length);
        SOItems = ScriptableObjectItems[rndItems];
        allItems = SOItems.allItems;
        levels = SOItems.ScriptableObjectLevels;
        Debug.LogWarning(rndItems);

        StartCoroutine("GetQuestIE");
    }
}
