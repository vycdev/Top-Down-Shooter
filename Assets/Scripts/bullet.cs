using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {


    //variebles
    public float speed;
    public float maxDistance;

    private int frames;

    private GameObject trigerrignEnemy;
    public float damage;

    

    

    
    //methods
	void Update () {
     

     
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
       

        maxDistance += 1 * Time.deltaTime;


        if(maxDistance >= 5)
        {
            Destroy(this.gameObject);
        }
        

	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            trigerrignEnemy = other.gameObject;
            trigerrignEnemy.GetComponent<Enemy>().health -= damage;
            Destroy(this.gameObject);
            
        }
    }
 
}
