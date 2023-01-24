using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

/// <summary>
/// 鼠标悬停于按钮上显示介绍的基类
/// </summary>
public class BtnHoverBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	HUD hud;

	public GameObject tipsBg;
	TextMeshProUGUI tipsName;
	TextMeshProUGUI instruction;


	Transform tipsParent;
	Transform tipsParentParent;

	bool isSetValue = false;

	private void Awake()
	{
		hud = FindObjectOfType<HUD>();

		tipsName = tipsBg.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
		instruction = tipsBg.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

		tipsParent = tipsBg.transform.parent;
		tipsParentParent = tipsParent.parent;
	}

	public void SetValue()
	{

		int i = tipsParent.gameObject.GetComponent<SkillButton>().ButtonNumber;

		tipsName.text = hud.selectedSkills[i].upgradeName;
		instruction.text = hud.selectedSkills[i].upgradeIntroduction;

		isSetValue = true;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		SetValue();

        if (isSetValue)
        {
			tipsBg.SetActive(true);
			tipsBg.transform.SetParent(tipsParentParent);
			tipsBg.transform.SetAsLastSibling();
		}

	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tipsBg.SetActive(false);
		tipsBg.transform.SetParent(tipsParent);

		isSetValue = false;
	}
}
