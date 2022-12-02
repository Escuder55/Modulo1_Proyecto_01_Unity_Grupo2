using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] bool isAlive;
    [SerializeField] int score;
    [SerializeField] float health , speed, gravity;
    [SerializeField] string characterName;
    [SerializeField] CharacterController characterController;
    [SerializeField] Collider myCollider;

    Vector3 verticalSpeed;
    Vector2 screenCenter;
    [SerializeField] float rotationSpeed, minmousseMovement;

    [SerializeField] Animator characterAnimator;

    // Start is called before the first frame update
    void Start()
    {
        screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            characterAnimator.SetBool("isWalking", true);

        }
        else
        {
            characterAnimator.SetBool("isWalking", false);
        }

        verticalSpeed += Physics.gravity * gravity * Time.deltaTime;

        float mousseMovement = Input.mousePosition.x - screenCenter.x;
        if (mousseMovement < -minmousseMovement || mousseMovement > minmousseMovement)
        {
            transform.Rotate(new Vector3(0, rotationSpeed * mousseMovement, 0));
        }       
        
        transform.position += Input.GetAxis("Vertical") * transform.forward * speed * Time.deltaTime + verticalSpeed;        
    }
}
