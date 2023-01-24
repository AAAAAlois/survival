using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;

    [SerializeField] GameObject skillUI;
    [SerializeField] List<UpgradeData> skills;
    [SerializeField] List<SkillButton> skillButtons;
    [SerializeField] List<UpgradeData> selectedSkills;
    [SerializeField] List<UpgradeData> acquiredSkills;
    public int acquiredSkillSlot;

    [SerializeField] TextMeshProUGUI timeCounter;
  

    float timer = 0.0f;
    float lastUITime = 0.0f;

    SkillManager skillManager;

    private void Start()
    {
        skillManager = FindObjectOfType<SkillManager>();

    }

    private void Update()
    {
        CountTime();
        ShowSkillUI();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseUI.activeInHierarchy == false)
            {
                pauseUI.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    void CountTime()
    {

        timer += Time.deltaTime;


        int hour = (int)timer / 3600;
        int minute = (int)(timer - hour * 3600) / 60;
        int second = (int)(timer - hour * 3600 - minute * 60);

        if (hour == 0)
        {
            timeCounter.text = "Time: "+ minute.ToString("D2") + ":" + second.ToString("D2") ;
        }
        else
        {
            timeCounter.text = "Time: " + hour.ToString("D2") + ":" + minute.ToString("D2") + second.ToString("D2");
        }

    }

    void ShowSkillUI()
    {
        float currentTime = Time.time;

        if (currentTime - lastUITime > 10)
        {
            if (selectedSkills == null)
            {
                selectedSkills = new List<UpgradeData>();
            }
            else
            {
                selectedSkills.Clear();
                selectedSkills.AddRange(GetSkills(3));
            }

            FillSkillUI(selectedSkills);
            Time.timeScale = 0f;
            lastUITime = currentTime;
        }
    }

    public List<UpgradeData> GetSkills(int count)
    {
        List<UpgradeData> skillList = new List<UpgradeData>();

        if (count > skills.Count)
        {
            count = skills.Count;
        }

        for(int i = 0; i < count; i++)
        {
            skillList.Add(skills[Random.Range(0, skills.Count)]);
            //Debug.Log("get skill" + skillList[i].upgradeName);
        }


   

        return skillList;
    }

    void FillSkillUI(List<UpgradeData> upgradeDatas)
    {
        for(int i = 0; i < upgradeDatas.Count; i++)
        {
            skillButtons[i].SetSkillData(upgradeDatas[i]);
            //Debug.Log(i + ":" + upgradeDatas[i].upgradeName);
        }
        skillUI.SetActive(true);
    }

    public void Upgrade(int selectedUpgradeID)
    {

        UpgradeData upgradeData = selectedSkills[selectedUpgradeID];

        if(acquiredSkills == null)
        {
            acquiredSkills = new List<UpgradeData>();
        }

        if (acquiredSkills.Count < acquiredSkillSlot)
        {
            skillManager.AddSkill(upgradeData.skillData);

            acquiredSkills.Add(upgradeData);
        }
        else
        {
            Debug.Log("Skill slot is full");
        }
      
        //skills.Remove(upgradeData);
        
    }



}
