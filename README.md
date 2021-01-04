# Multiplayer-FPS-Game
<hr>
<a href="https://ibb.co/tKKkj19"><img src="https://i.ibb.co/2hhmVpT/Banner.jpg" style="width:100px; margin-left:auto; margin-right:auto;" alt="Banner" border="0"></a>


Saya membuat repository ini untuk pengalaman belajar saya menggunakan unity dengan C# , tutorial pembuatan game ini terinspirasi dari salah satu youtuber game developer yaitu [Channel Brackeys](https://www.youtube.com/user/Brackeys)



## Penejelasan Codingan
  
 <table style="width:100%">
  <tr>
    <th>Keyword</th>
    <th>Function</th>
  </tr>
  <tr>
    <td>Method Start()</td>
    <td>Akan panggil ketika Game dijalankan satukali</td>
  </tr>
 <tr>
    <td>Method Update()</td>
    <td>Fungsi ini akan dipanggil setiap frame per detik yang dimana akan selalu berubah dan terus mengulangnya sampai game berhenti atau keluar dari game tersebut.</td>
  </tr>
  <tr>
    <td>GetComponent<>()</td>
    <td>Memanggil komponen</td>
  </tr>
  <tr>
    <td>Input.GetAxis()</td>
    <td>Deteksi input</td>
  </tr>
  <tr>
    <td>transform.right</td>
    <td>Memindahkan object ke kanan</td>
  </tr>
  <tr>
    <td>transform.left</td>
    <td>Memindahkan object ke kiri</td>
  </tr>
  <tr>
    <td>[SerializeField]</td>
    <td>Untuk menampilkan UI Inspector di Unity</td>
  </tr>
</table> 
 
 
 
  

### Memanggil Script PlayerMotor

Buat terlebih dahulu script dengan nama ControllerPlayer dan PlayerMotor pada gameobject player


    [RequireComponent(typeof(PlayerMotor))]
    public class PlayerController : MonoBehaviour
    {
    public float speed = 5f;
    private PlayerMotor motor;
    [SerializeField]
    private float lookSensitivity = 3f;
    
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

buat terlebih dahulu variable speed untuk perubahan velocity pada player dan tentunya kita konekan ControllerPlayer dengan PlayerMotor dengan membuat private variable dan tuliskan nama script yaitu PlayerMotor dan gunakan nama alias motor
Lalu pada method Start kita panggil scriptnya dengan cara : GetComponent<>();

### Deteksi Input Keyboard

    float _xMove = Input.GetAxis("Horizontal");
    float _zMove = Input.GetAxis("Vertical");
    
Disini kita buat variabel xMove untuk horizontal dan zMove untuk vertical, untuk settings, <b>Edit > Project Settings > Input Manager</b> Didalam Input Manager kita bisa melihat banyak isi dari Axes salah satunya adalah Horizontal dan Vertical , jika kita ingin set positiveButton dan negativeButton , default pada Input Horizontal adalah
  

<table style="width:100%">
  <tr>
    <th colspan="2">Horizontal</th>
    <th colspan="2">Vertical</th>
  </tr>
  <tr>
    <th>Input</th>
    <th>Button</th>
    <th>Input</th>
    <th>Button</th>
  </tr>
  <tr>
    <td>Ke Kiri</td>
    <td>A</td>
     <td>Ke Depan</td>
    <td>W</td>
  </tr>
  <tr>
    <td>Ke Kanan</td>
    <td>D</td>
    <td>Ke Belakang</td>
    <td>S</td>
  </tr>
 <table/>

### Membuat Velocity
Velocity adalah sama seperti speed tetapi yang membedakan kalau speed itu tidak adanya vektor sedangkan velocity adanya arah vektor , tujuan pembuatan velocity ini berfungsi ketika kita memencet tombol input maka akan terjadi perpindahan sebesar velocitynya


    Vector3 _movHoriz = transform.right * _xMove;
    Vector3 _movVerti = transform.forward * _zMove;
    Vector3 _velocity = (_movHoriz + _movVerti)* speed;
    motor.Move(_velocity);

<table style="width:100%">
  <tr>
    <th>Keyword</th>
    <th>Function</th>
  </tr>
  <tr>
    <th>Vector3</th>
    <th>Merepresentasikan Vector 3D dan point</th>
  </tr>
 <table/>
  
Sekarang kita buat input yang sudah kita buat menjadi bergerak, dengan cara melakukan transform yaitu dengan mengkalikan transform (perpindahan) dengan input
lalu kita buat velocity dengan menambahkan vertikal dan horizontal dan dikalikan dengan speed yang sudah kita buat diawal dengan value 5f, jika kita ingin menambahkan kecepatan , tentunya kita tinggal menambahkan value speed.
Setelah itu kita pass variable ke MotorPlayer yang nanti akan kita panggil di script Motor Player ,dengan cara membuat sebuah function pada MotorPlayer seperti berikut :

     public void Move(Vector3 _velocity)
    {
        velocity = _velocity; 
    }


ada 2 velocity disini , velocity yang menggunakan underscore merupakan variable yang dipass dari PlayerController ke variable velocity yang ada di MotorController

    void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity *Time.fixedDeltaTime);
        }
    }
Setelah itu tentunya harus kita ubah posisi dengan memanfaatnkan velocity yang sudah kita buat tadi ,dengan mengubah rigitbody movePosition yang mana posisi rigidbody ditambahkan dengan velocity dikalikan fixedDeltaTime

<table style="width:100%">
  <tr>
    <th>Keyword</th>
    <th>Function</th>
  </tr>
  <tr>
    <th>Vector3.zero</th>
    <th>Membuat Vektor menjadi (x,y,z) = (0,0,0)</th>
  </tr>
  <tr>
    <th>Rigidbody.MovePosition()</th>
    <th>Membuat rigidbody berpindah</th>
  </tr>
   <tr>
    <th>Time.fixedDeltaTime</th>
    <th>Interval/detik secara smooth</th>
  </tr>
 <table/>
  
 
 ### Deteksi Input Mouse
 
 Setelah kita bisa melakukan pergerakan dari playernya , sekarang kita lakukan pergerakan camera untuk menembak
       
    float _yBot = Input.GetAxis("Mouse X");
    Vector3 _rotation = new Vector3(0f, _yBot, 0f) * lookSensitivity;
    motor.Rotate(_rotation);
 
    float _xBot = Input.GetAxis("Mouse Y");
    float _cameraRotationX = _xBot * lookSensitivity;
    motor.RotateCamera(_cameraRotationX);

Pertama kita input mouse horizontal dengan menggunakan GetAxis Mouse X dan tentunya kita buat vector3 (x,y,z) (0,yBot,0) dan kita kalikan dengaan Sesitifitas dari mouse dengan membuat variable lookSensitivity lalu isi variable tersebut dengan 3f , setelah itu buat Rotate method pada PlayerMotor untuk melakukan eksekusi rotasi

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }


Setelah itu kita input mouse Vertical dengan menggunakan input axis Mouse Y dan kita kalikan dengan sesitifitas tadi.
   
    float _xBot = Input.GetAxis("Mouse Y");
    float _cameraRotationX = _xBot * lookSensitivity;
    motor.RotateCamera(_cameraRotationX);

Setelah itu pass variable ke PlayerMotor dengan method RotateCamera
  
    public void RotateCamera(float _rotateCameraX)
    {
        rotateCameraX = _rotateCameraX;
    }
    
 Jika sudah kita buat PerformRotationnya untuk melakukan eksekusi rotasinya
 
    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (cam != null)
        {
            currentRotateCameraX -= rotateCameraX;
            currentRotateCameraX = Mathf.Clamp(currentRotateCameraX, -camRotateLimit, camRotateLimit);
            cam.transform.localEulerAngles = new Vector3(currentRotateCameraX, 0f, 0f);
        }
    }

Untuk melakukan eksekusi tentunya kita merotasi rigidbody dengan menggunakan MoveRotation dan menggunakan Quaternion.Euler
lalu dilakukan pengecekan ketika cam (Camera Lobby bukan cam player) ada , maka rotasisekarang akan dikurangi dengan rotateCameraX yang sudah kita cari di ControllerPlayer , maka dari iut currentRotateCameraX berisi minesnya dari rotateCameraX , dan kita lakukan pembatasan rotasi pada horizontal agar camera tidak kebelakang badan dengan melakukan Math.Clap, dimana pada parameter kedua adalah minimum rotasi ,dan parameter ketiga ada maximum rotasi limit yang mana var tersebut diinstansiasi di awal.

setelah kita transform rotasi relative terhadap parentnya , karena cam termasuk child dari player tentunya kita ingin mengubah rotate juga pada parentnya agar sama-sama berotasi dengan childnya dengan menggunakan transform.localEulerAngles

<table style="width:100%">
  <tr>
    <th>Keyword</th>
    <th>Function</th>
  </tr>
  <tr>
    <th>Rigidbody.MoveRotation()</th>
    <th>Untu melakukan rotasi pada rigidbody</th>
  </tr>
  <tr>
    <th>Quaternion.Euler()</th>
    <th>Membuat rigidbody berpindah</th>
  </tr>
 <table/>
  
 Setelah itu, jangan lupa kita eksekusi dengan method FixedUpdate, sebelum itu kita harus tau bedanya Method Update
 
<table style="width:100%">
  <tr>
    <th>Keyword</th>
    <th>Function</th>
  </tr>
  <tr>
    <th>Update</th>
    <th>fungsi ini akan dipanggil setiap frame per detik yang dimana akan selalu berubah dan terus mengulangnya sampai game berhenti atau keluar dari game tersebut.</th>
  </tr>
  <tr>
    <th>fixedUpdate</th>
    <th>fungsi ini sama dengan Update namun frame per detik (fps) akan tetap atau tidak berubah selama permainan.</th>
  </tr>
  <tr>
    <th>lateUpdate</th>
    <th>fungsi ini akan dipanggil setelah semua script Update selesai.</th>
  </tr>
 <table/>
  
  Berikut kita menggunakan FixedUpdate karna kita ingin melakukan pemanggilan methodnya secara konstan dan tidak akan berubah , kita tambahkan 2 method yaitu movement dan rotation
  
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }
    
 Berikut adalah hasilnya 
 
<a href="https://ibb.co/RBb5wZb"><img src="https://i.ibb.co/cC3mnM3/2020-12-29-21-32-58.gif" alt="2020-12-29-21-32-58" border="0"></a>
  

## Fitur FPS Game
  1. [Pergerakan Player (Movement)](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game/tree/Movement-Player)
  2. [Networking Multiplayer](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game/tree/Networking)
  3. [Membuat Player Terbang (Flying / Jump)](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game/tree/Jump)
  4. Menembak Player (Debugging Shot) (Soon)
  5. Hit Damage Player (Include Hit Point) (Soon)
  6. Respawn player ketika start game (Respawning Player) (Soon)
  7. Membuat Model pada Player (Make a Model Player) (Soon)
  8. Titik Tembak (CrossHair) (Soon)


