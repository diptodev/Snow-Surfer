using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{ 
    [SerializeField] float torqueAmount=10f;
    [SerializeField] float baseSpeed=15f;
    [SerializeField] float boostSpeed=20f;
    bool canControolPlayer=true;
    SurfaceEffector2D surfaceEffector2D;
    InputAction moveAction;
    float previousRotation;
    float currentRotation;
    float totalRotation;
    int totalFlip;
 
 Vector2 moveVector;
    Rigidbody2D myRigidBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         
        moveAction=InputSystem.actions.FindAction("Move");
        myRigidBody=GetComponent<Rigidbody2D>();
        surfaceEffector2D=FindAnyObjectByType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector=moveAction.ReadValue<Vector2>();
  if (canControolPlayer)
  {
     rotatePlayer();
   boostPlayer();
   
 //  Debug.Log(totalRotation);
  }
   
   flipCount();
   
    }
    void rotatePlayer()
    {
         
    
    if (moveVector.x>0)
    {
        myRigidBody.AddTorque(-torqueAmount);
    }else if (moveVector.x<0)
        {
            myRigidBody.AddTorque(torqueAmount);
        }
    }
    void boostPlayer()
    {
        if (moveVector.y>0)
        {
        //TODO
        surfaceEffector2D.speed=boostSpeed;
        }else
        {
            surfaceEffector2D.speed=baseSpeed;
        }
    }
   public  void disablePlayerControl()
    {
        canControolPlayer=false; 
    }
    public void flipCount()
    {
        currentRotation=transform.rotation.eulerAngles.z;
        totalRotation+=Mathf.DeltaAngle(previousRotation,currentRotation);
        previousRotation=currentRotation;
        if (totalRotation>340 || totalRotation<-340)
        {
            totalFlip+=1;
            totalRotation=0;
        }
        Debug.Log(totalFlip);
    }
}
