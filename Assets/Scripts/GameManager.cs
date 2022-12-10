using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public InputAction moveActionLeft;
    public InputAction moveActionRight;
    public float moveSpeed = 10.0f;
    public Vector2 positionLeft;
    public Vector2 positionRight;
    public Transform player1;
    public Transform player2;
    void Start()
    {
        moveActionLeft.Enable();
        moveActionRight.Enable();

    }

    private void MovePlayers()
    {
        var moveDirectionLeft = moveActionLeft.ReadValue<Vector2>();
        var moveDirectionRight = moveActionRight.ReadValue<Vector2>();
        
        Vector2 newPositionLeft = positionLeft + moveDirectionLeft * moveSpeed * Time.deltaTime;
        Vector2 newPositionRight = positionRight + moveDirectionRight * moveSpeed * Time.deltaTime;
        
        if (newPositionLeft.x > -8.9 && newPositionLeft.x < 8.9)
        {
            positionLeft.x = newPositionLeft.x;
            if (newPositionLeft.y < 4 && newPositionLeft.y > -6)
            {
                positionLeft.y = newPositionLeft.y;
            }
        }
        if (newPositionRight.x > -8.9 && newPositionRight.x < 8.9)
        {
            positionRight.x = newPositionRight.x;
            if (newPositionRight.y < 4 && newPositionRight.y > -6)
            {
                positionRight.y = newPositionRight.y;
            }
        }
        player1.position = new Vector3(positionLeft.x,positionLeft.y, player1.position.z);
        player2.position =  new Vector3(positionRight.x,positionRight.y, player2.position.z);
    }
   
    void Update()
    {
        MovePlayers();
    }
}
