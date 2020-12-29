using UnityEngine;


[RequireComponent(typeof(PlayerController))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    //rotate x limit
    private float rotateCameraX = 0f;
    private float currentRotateCameraX = 0f;\

    [SerializeField]
    private float camRotateLimit = 85f;
    private Rigidbody rb;

    // include rigidbody
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //pass variable
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity; 
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void RotateCamera(float _rotateCameraX)
    {
        rotateCameraX = _rotateCameraX;
    }


    //memanggil pergerakan dan rotasi 
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity *Time.fixedDeltaTime);
        }
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation *Quaternion.Euler (rotation));

        if(cam != null)
        {

            // set rotasi dan clamp it
            currentRotateCameraX -= rotateCameraX;
            currentRotateCameraX = Mathf.Clamp(currentRotateCameraX, -camRotateLimit, camRotateLimit);
            // apply rotation to our cam
            cam.transform.localEulerAngles = new Vector3(currentRotateCameraX, 0f, 0f);

        }
    }
}
