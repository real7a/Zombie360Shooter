using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

    public int damagePerShot;                
    public float timeBetweenBullets = 0.15f;       
    public float range = 100f;                    

    float timer;                                  
    Ray shootRay;                                   
    RaycastHit shootHit;                           
    int shootableMask;                             
    LineRenderer gunLine;                           
    float effectsDisplayTime = 0.2f;               

    void Awake () {
        shootableMask = LayerMask.GetMask("Shootable");

        gunLine = GetComponent<LineRenderer>();

      damagePerShot = 20; //overrides on GunEnd in Editor
    }
	
	void Update () {

        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
        {
            Shoot();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
    }

    public void DisableEffects()
    {
        gunLine.enabled = false;
    }

    void Shoot()
    {
        timer = 0f;

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;


        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            //EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

            //if (enemyHealth != null)
            //{
            //    enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            //}
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }

    }
}
