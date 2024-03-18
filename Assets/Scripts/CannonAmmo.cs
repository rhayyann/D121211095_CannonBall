using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CannonAmmo : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    public int totalAmmo;
    public int currentAmmo;

    public int CurrentAmmo
    {
        get
        {
            return currentAmmo;
        }
        set
        {
            currentAmmo = value;
            //print("Current ammo : " + currentAmmo);
            ammoText.text = "Ammo : " + currentAmmo + "/" + totalAmmo;
            if(currentAmmo <= 0 && GameManager.Instance.fallenBrickAmount < GameManager.Instance.fallenBrickNeeded)
            {
                GameManager.level = 1;
                print("You lose");
                GameManager.Instance.RestartGame();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.setAmmo += SetAmmo;
    }

    private void OnDisable()
    {
        GameManager.Instance.setAmmo -= SetAmmo;
    }

    private void SetAmmo()
    {
        totalAmmo = (GameManager.Instance.fallenBrickNeeded / 2)-2;
        currentAmmo = totalAmmo;
        ammoText.text = "Ammo : " + currentAmmo + "/" + totalAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
