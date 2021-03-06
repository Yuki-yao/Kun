﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModuleInfo : MonoBehaviour {

  public static ModuleInfo instance = null;
  [HideInInspector]
  public Module[] moduleList;
  public const int TOT = 9;

  public Dictionary<ModuleType, string> modImgMap;
  private GameObject moduleSlotPanel;

  // Use this for initialization
  void Awake () {
		if(instance == null)
    {
      instance = this;
    }
    else if(instance != this)
    {
      Destroy(gameObject);
    }

    DontDestroyOnLoad(gameObject);

    moduleList = new Module[TOT];
    modImgMap = new Dictionary<ModuleType, string>();
    modImgMap.Add(ModuleType.Core, "001");
    modImgMap.Add(ModuleType.Energy, "002");
    modImgMap.Add(ModuleType.Battery, "003");
    modImgMap.Add(ModuleType.Armor, "004");
    modImgMap.Add(ModuleType.Computation, "005");
    modImgMap.Add(ModuleType.Weapon, "007");
    modImgMap.Add(ModuleType.Power, "009");
    modImgMap.Add(ModuleType.Repair, "010");
    modImgMap.Add(ModuleType.None, "");
    modImgMap.Add(ModuleType.Locked, "");

    moduleSlotPanel = GameObject.Find("ModuleSlotPanel");
  }

  private void Start()
  {/*
    if(moduleList[0] != null)
    {
      for (int i = 0; i < TOT; i++)
      {
        Image img = moduleSlotPanel.transform.GetChild(i).GetComponent<Image>();
        img.sprite = Resources.Load<Sprite>("Images/" + modImgMap[moduleList[i].type]);
      }
    }*/
  }

  // Update is called once per frame
  void Update () {
		
	}

  public bool checkModules()
  {
    if (moduleSlotPanel == null)
    {
      Debug.Log("panel not found");
      return false;
    }

    int coreCount = 0;
    for(int i = 0; i < TOT; i ++)
    {
      GameObject slot = moduleSlotPanel.transform.GetChild(i).gameObject;
      moduleList[i] = Module.sample(slot.GetComponent<DragAndDrop>().moduleType);
      if (moduleList[i].type == ModuleType.Core)
        coreCount++;
    }

    return coreCount == 1;
  }
}
