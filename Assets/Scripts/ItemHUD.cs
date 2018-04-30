﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ItemHUD : MonoBehaviour {
    [SerializeField]
    private GameObject itemBox;

    [SerializeField]
    private List<Sprite> itemImg = new List<Sprite>();

    [SerializeField]
    private Text itenAmount;

    [SerializeField]
    private GameObject[] curItem;

    private PlayerMovement plMove;

    public int curWeapon;

	// Use this for initialization
	void Start () {
        plMove = GetComponent<PlayerMovement>();
	}

    private void LateUpdate()
    {
        if (itemImg.Count > 0)
        {
            plMove.activeWeapon = itemImg[curWeapon].name;

            for(int i = 0; i < curItem.Length; i++)
            {
                if(curWeapon == i)
                    curItem[i].SetActive(true);

                else
                    curItem[i].SetActive(false);
            }  
        }
    }

    // Update is called once per frame
    void Update () {
        itenAmount.text = "X" + plMove.ammo;

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && curWeapon < curItem.Length - 1)
            curWeapon += 1;

        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && curWeapon > 0)
            curWeapon -= 1;
    }
}
