using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    public float speed = 5f;
    private PlayerMotor motor;
    [SerializeField]
    private float lookSensitivity = 3f;
    [SerializeField]
    private float thrusterForce = 1000f;


    // memanggil komponen saat game dijalankan
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        //mendeteksi input vertical dan horizontal
        float _xMove = Input.GetAxis("Horizontal");
        float _zMove = Input.GetAxis("Vertical");

        //membuat velocity dan lakukan normalize dikalikan dengan speed player
        Vector3 _movHoriz = transform.right * _xMove;
        Vector3 _movVerti = transform.forward * _zMove;
        Vector3 _velocity = (_movHoriz + _movVerti) * speed;
        motor.Move(_velocity);

        //untuk deteksi input mouse
        float _yBot = Input.GetAxis("Mouse X");
        Vector3 _rotation = new Vector3(0f, _yBot, 0f) * lookSensitivity;
        motor.Rotate(_rotation);


        float _xBot = Input.GetAxis("Mouse Y");
        float _cameraRotationX = _xBot * lookSensitivity;
        motor.RotateCamera(_cameraRotationX);


        Vector3 _thrusterForce = Vector3.zero;
        if (Input.GetButton("Jump"))
        {
            _thrusterForce = Vector3.up * thrusterForce;
        }
        motor.applyThruster(_thrusterForce);
        

    }
}
