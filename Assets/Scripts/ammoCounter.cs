using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ammoCounter : MonoBehaviour {

    private int ammo;
    private int carriedAmmo;

    public Text ammoUI;
    public Text reloading;

    public void ammoCounterUI()
    {
        ammo = GameObject.Find("Player Holder").GetComponent<Player>().ammo; //this will get the component of another script 
        carriedAmmo = GameObject.Find("Player Holder").GetComponent<Player>().reloadableAmmo;
        if (ammoUI != null)
        {
            ammoUI.text = ammo.ToString() + " / " + carriedAmmo.ToString();
        }
        
    }

    public void reloadingUI(bool isReloading)
    {
        if (reloading != null && isReloading)
        {
            reloading.text = "Reloading...";
        }else
        {
            reloading.text = " ";
        }
            
    }


    
}
