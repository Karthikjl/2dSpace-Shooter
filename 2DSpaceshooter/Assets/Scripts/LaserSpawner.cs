using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserSpawner : MonoBehaviour
{
    public GameObject Laser;

    public float TimeBtwshoot;
    private float timeShoot;

    public int reloadTime;
    public int ammo;
    public int maxAmmo;
    public Text ammoTxt;
    public bool reloading = false;

    private void Start()
    {
        ammo = maxAmmo;
        ammoTxt.text = ammo.ToString();
    }
    
        
    private void Update()
    {
        if(ammo > 0 && reloading == false){
            if (Input.GetKey(KeyCode.Space))
            {
                if (Time.time >= timeShoot)
                {
                    ammo--;
                    ammoTxt.text = ammo.ToString();
                    Shoot();               
                    timeShoot = Time.time + TimeBtwshoot;              
                }                  
            }
        }
        else if(ammo <= 0 && reloading == false)
        {
            reloading = true;
            ammoTxt.text = "Reloading...";            
            StartCoroutine("reloadLaser");
        }
        
    }

    IEnumerator reloadLaser()
    {
        yield return new WaitForSeconds(reloadTime);
        ammoRefiner();
        reloading = false;
    }
    
    void ammoRefiner(){
        ammo = maxAmmo;
        ammoTxt.text = ammo.ToString();
    }

    void Shoot(){
        Instantiate(Laser,transform.position,Quaternion.identity);
    }


}
