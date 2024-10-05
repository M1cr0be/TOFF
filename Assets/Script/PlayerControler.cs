using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private CharacterController characterController;

    public GameObject AttachCameraPoint;

    private Vector2 Turn;
    public float Sensitivity = 5f;
    public float Speed = 5f;
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Charactere mouvements
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(move*Time.deltaTime*Speed);

        //Camera rotation
        Turn.x += Input.GetAxis("Mouse X") * Sensitivity;
        Turn.y += Input.GetAxis("Mouse Y") * Sensitivity;
        Turn.y = Mathf.Clamp(Turn.y, -75, 75);
        AttachCameraPoint.transform.localRotation = Quaternion.Euler(-Turn.y, Turn.x, 0);
    }
}
