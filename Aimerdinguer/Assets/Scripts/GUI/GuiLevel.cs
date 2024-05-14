using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuiLevel : MonoBehaviour
{
    public Player player;
    //GUI
    public TMP_Text guiHealthAmount;
    public TMP_Text guiAmmoAmount;
    public TMP_Text guiReloadTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            if (player.weaponReloadTime <= 0f)
            {
                guiReloadTime.text = "";
            }
            else
            {
                guiReloadTime.text = "Reloading: " + player.weaponReloadTime.ToString("F" + 2);
            }

            guiAmmoAmount.text = player.weaponBullets.ToString();
            guiHealthAmount.text = player.playerHealth.ToString();
        
    }
}
