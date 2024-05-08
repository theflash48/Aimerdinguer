using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    //Inputs and Camera
    float inputCameraX = 0f;
    public float mouseSensitivity = 2f;
    float cameraVerticalRotation = 0f;

    bool lockedCursor = true;

    //Player Data
    public int playerMaxHealth = 100;
    public int playerHealth = 100;
    public float playerSpeed = 5;
    
    //Weapon Data
    public int weaponInUse = 0;
    public float weaponDamage = 0;
    public float weaponRange = 0;
    public int weaponMaxBullets = 0;
    public int weaponBullets = 0;
    public float weaponFireRate = 0;
    public float weaponFireRateCooldown = 0;
    public float weaponReloadMaxTime = 0;
    public float weaponReloadTime = 0f;
    public bool weaponReloading = false;
    public GameObject playerProyectile;
    public Quaternion bulletRotation;

    //GUI
    public TMP_Text guiHealthAmount;
    public TMP_Text guiAmmoAmount;

    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        WeaponNew(0);
    }

    // Update is called once per frame
    void Update()
    {
        MoveAndCamera();
        WeaponReload();
        if (!weaponReloading)
        {
            WeaponShoot();
        }
        GuiUpdate();
    }

    public void MoveAndCamera()
    {
        inputCameraX = Input.GetAxis("Mouse X") * mouseSensitivity;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        }
        transform.Rotate(Vector3.up * inputCameraX);
    }
    
    public void WeaponNew(int newWeapon)
    {
        switch (newWeapon)
        {
            case 0:
                weaponInUse = 0;
                weaponDamage = 1;
                weaponRange = 30;
                weaponMaxBullets = 30;
                weaponBullets = 30;
                weaponFireRate = 1;
                weaponReloadMaxTime = 5;
                break;
            case 1:
                weaponInUse = 0;
                weaponDamage = 1;
                weaponRange = 30;
                weaponMaxBullets = 30;
                weaponBullets = 30;
                weaponFireRate = 5;
                weaponReloadMaxTime = 5;
                break;
            case 2:
                weaponInUse = 0;
                weaponDamage = 1;
                weaponRange = 30;
                weaponMaxBullets = 30;
                weaponBullets = 30;
                weaponFireRate = 5;
                weaponReloadMaxTime = 5;
                break;
            case 3:
                weaponInUse = 0;
                weaponDamage = 1;
                weaponRange = 30;
                weaponMaxBullets = 30;
                weaponBullets = 30;
                weaponFireRate = 5;
                weaponReloadMaxTime = 5;
                break;
            case 4:
                weaponInUse = 0;
                weaponDamage = 1;
                weaponRange = 30;
                weaponMaxBullets = 30;
                weaponBullets = 30;
                weaponFireRate = 5;
                weaponReloadMaxTime = 5;
                break;
        }
        weaponReloading = false;
    }
    

    public void WeaponReload()
    {
        if (Input.GetKey(KeyCode.R))
        {
            weaponReloading = true;
            weaponReloadTime = weaponReloadMaxTime;
        }
        
        if (weaponReloading == true)
        {
            weaponReloadTime -= Time.deltaTime;
            if (weaponReloadTime <= 0f)
            {
                weaponReloading = false;
            }
            if (weaponReloading == false)
            {
                weaponBullets = weaponMaxBullets;
            }
        }
    }
    public void WeaponShoot()
    {
        if (weaponReloading == false)
        {
            if (weaponFireRateCooldown > 0)
            {
                weaponFireRateCooldown -= Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                if(weaponFireRateCooldown <= 0 && weaponBullets > 0)
                {
                    weaponFireRateCooldown = weaponFireRate;
                    weaponBullets--;
                    
                    Instantiate(playerProyectile, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(90, 0, this.transform.rotation.y));
                    Debug.Log("Disparo");
                }
                else
                {
                    Debug.Log("Fallo");
                }

            }
        }
    }

    public void GuiUpdate()
    {
        guiAmmoAmount.text = weaponBullets + "";
        guiHealthAmount.text = playerHealth + "";
    }

}
