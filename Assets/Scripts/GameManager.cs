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

   
    void Update()
    {
        var moveDirectionLeft = moveActionLeft.ReadValue<Vector2>();
        var moveDirectionRight = moveActionRight.ReadValue<Vector2>();
        Vector2 newPositionLeft = positionLeft + moveDirectionLeft * moveSpeed * Time.deltaTime;
        Vector2 newPositionRight = positionRight + moveDirectionRight * moveSpeed * Time.deltaTime;
        if (newPositionLeft.x > -Screen.width / 2 && newPositionLeft.x < Screen.width/2)
        {
            positionLeft.x = newPositionLeft.x;
            if (newPositionLeft.y < Screen.height / 2 && newPositionLeft.y > -Screen.height / 2)
            {
                positionLeft.y = newPositionLeft.y;
            }
        }
        if (newPositionRight.x > -Screen.width / 2 && newPositionRight.x < Screen.width/2)
        {
            positionLeft.x = newPositionRight.x;
            if (newPositionRight.y < Screen.height / 2 && newPositionRight.y > -Screen.height / 2)
            {
                positionLeft.y = newPositionRight.y;
            }
        }
        player1.position = new Vector3(positionLeft.x,positionLeft.y, player1.position.z);
        player2.position =  new Vector3(positionRight.x,positionRight.y, player2.position.z);
    }
}
