using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform targetPoint;
    [SerializeField] GameObject rock;
    [SerializeField] float jumpPower;
    [SerializeField] float jumpDuration;


    public float timeBetweenSpawns;



    float timer = 0;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenSpawns)
        {
            timer = 0;

            GameObject go = Instantiate(rock, spawnPoint.position, spawnPoint.rotation) as GameObject;

            go.transform.DOJump(targetPoint.transform.position, jumpPower, 1, jumpDuration).SetEase(Ease.InQuint);
            
        }

    }
}
