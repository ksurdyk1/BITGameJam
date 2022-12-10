using UnityEngine;
using UnityEngine.InputSystem;

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

        positionLeft += moveDirectionLeft * moveSpeed * Time.deltaTime;
        positionRight += moveDirectionRight * moveSpeed * Time.deltaTime;

        player1.position = new Vector3(positionLeft.x,positionLeft.y, player1.position.z);
        player2.position =  new Vector3(positionRight.x,positionRight.y, player2.position.z);
    }
}
