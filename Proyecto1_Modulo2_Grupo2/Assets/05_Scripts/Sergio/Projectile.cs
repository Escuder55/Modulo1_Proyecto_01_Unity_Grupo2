using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1;

    Vector3 direction;

    private void Start()
    {
        Destroy(this.gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * speed;
    }

    public void SetDirection(Vector3 _direction)
    {
        direction = _direction;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            Destroy(other.gameObject);

            Destroy(gameObject);
        }
    }
}
