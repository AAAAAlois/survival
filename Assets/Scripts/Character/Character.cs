using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{
    public int maxHp = 1000;
    public int currentHp = 1000;
    public int armor = 0;

    [SerializeField] StatusBar hpBar;
    [SerializeField] StatusBar experienceBar;

    bool isDead = false;
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] GameObject weapon;
    [SerializeField] TextMeshProUGUI levelCounter;

    public int level = 1;
    int experience = 0;
    int TO_LEVEL_UP
    {
        get { return level * 1000; }
    }

    private void Start()
    {
        hpBar.SetState(currentHp, maxHp);
        experienceBar.SetState(experience, TO_LEVEL_UP);
    }

    public void GetHit(int damage)
    {
        if (isDead) return;

        ApplyArmor(ref damage);  //any changes made to the damage variable inside the ApplyArmor method will also be reflected outside of the method

        currentHp -= damage;

        if(currentHp <= 0)
        {
            isDead = true;
            GameOver(isDead);
            Debug.Log("game over");
        }

        hpBar.SetState(currentHp, maxHp);
    }

    void ApplyArmor(ref int damage)
    {
        damage -= armor;
        if (damage < 0) { damage = 0; }
    }

    public void Heal(int amount)
    {
        if (currentHp <= 0)
        {
            return;
        }
        currentHp += amount;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }

        hpBar.SetState(currentHp, maxHp);
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        experienceBar.SetState(experience, TO_LEVEL_UP);
        CheckLevelUp();
    }

    public void CheckLevelUp()
    {
        if (experience >= TO_LEVEL_UP)
        {
            experience -= TO_LEVEL_UP;
            level++;
            experienceBar.SetState(experience, TO_LEVEL_UP);
            levelCounter.text = "Level: " + level;
        }

    }

    public void GameOver(bool isDead)
    {
        if (isDead)
        {
            gameoverPanel.SetActive(true);
            weapon.SetActive(false);
            GetComponent<PlayerMove>().enabled = false;
        }
    }
}
