using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{ 
    InputAction moveAction;
    [SerializeField] float torqueAmount=10f;
    Rigidbody2D myRigidBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction=InputSystem.actions.FindAction("Move");
        myRigidBody=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    Vector2 moveVector;
    moveVector=moveAction.ReadValue<Vector2>();
    if (moveVector.x>0)
    {
        myRigidBody.AddTorque(-torqueAmount);
    }else if (moveVector.x<0)
        {
            myRigidBody.AddTorque(torqueAmount);
        }
    }
}
