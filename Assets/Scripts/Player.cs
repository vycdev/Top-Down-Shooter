using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    // variables

    public float movementSpeed;
    private int frames;

    public GameObject camera;
    public GameObject playerObj;

    public GameObject bulletSpawnPoint;
    public float waitTime;
    public GameObject bullet;

    private int maxReloadableAmmo = 16; //cat poti da relaod
    public float reloadTime = 1f; // cat dureaza sa dai relaod
    public int maxAmmo = 42; // cat ammo poti sa cari
    public int ammo; //ammo care poate fi folosit 
    public int reloadableAmmo; //ammo care il ai si nu e inca loaded
    private bool isReloading = false;
    public ammoCounter ammoCounter;


    
    

    // methods
    private void Start()
    {
        ammo = maxReloadableAmmo;
        reloadableAmmo = 32;
        ammoCounter.ammoCounterUI();
        ammoCounter.reloadingUI(isReloading);
    }

    void Update()
    {

        //player facing mouse

        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitDist = 0.0f;

        if (playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 7f * Time.deltaTime);
        }


        // movement

        if (Input.GetKey(KeyCode.W))
           transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
           transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
           transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
           transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);


        //shooting
        frames++;
        if (Input.GetMouseButton(0))
        {
            if (isReloading)
            {
                return;
            }
            if(ammo <= 0)
            {
                if (reloadableAmmo > 0)
                StartCoroutine(reload());
                ammoCounter.ammoCounterUI();


            }
            if (frames % 7 == 0 && ammo > 0)
            {
                Shoot();
                frames = 0;
                ammo--;
                ammoCounter.ammoCounterUI();


            }
        }
            
           
    }
    // also shooting
    void Shoot()
    {
        
        Instantiate(bullet.transform, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation );


        
    }

    IEnumerator reload()
    {
        
            isReloading = true;
            ammoCounter.reloadingUI(isReloading);

            if (reloadableAmmo >= maxReloadableAmmo)
            {
                ammo = maxReloadableAmmo;
                reloadableAmmo = reloadableAmmo - maxReloadableAmmo;
                yield return new WaitForSeconds(reloadTime);


            }
            else
            {
                ammo = reloadableAmmo;
                reloadableAmmo = 0;
                yield return new WaitForSeconds(reloadTime);


            }

            isReloading = false;
            ammoCounter.reloadingUI(isReloading);
    }
}





