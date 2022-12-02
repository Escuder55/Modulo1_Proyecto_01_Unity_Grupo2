using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TurretAttack : MonoBehaviour
{
    //Head of the Turret
    [SerializeField] Transform turretHead;

    //Checking the Target
    bool targetVisible = false;

    //Target Variables
    Transform targetTransform;
    Quaternion initialRotation;

    [Header("Attack")]
    //Attack
    [SerializeField] float timeBetweenShots;
    [SerializeField] Transform spawner;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject chargingProjectile;
    [SerializeField] float timeParticlesOff = 0.15f;


    float timer = 0;
 
    private void Start()
    {
        initialRotation = turretHead.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetVisible)
        {
            turretHead.LookAt(targetTransform.position);

            timer += Time.deltaTime;
            if (timer > timeBetweenShots - timeParticlesOff && timer < timeBetweenShots)
            {
                chargingProjectile.SetActive(false);
            }
            else if (timer > timeParticlesOff && timer < timeBetweenShots - timeParticlesOff)
            {
                chargingProjectile.SetActive(true);
            }
            else if (timer >= timeBetweenShots)
            {
                timer = 0;

                GameObject projGO = Instantiate(projectile, spawner.position, spawner.rotation) as GameObject;

                projGO.GetComponent<Projectile>().SetDirection(turretHead.forward);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            targetVisible = true;
            targetTransform = other.transform;

            chargingProjectile.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            targetVisible = false;
            targetTransform = null;

            turretHead.DORotate( initialRotation.eulerAngles, 0.75f);

            timer = 0;

            chargingProjectile.SetActive(false);
        }
    }
}
