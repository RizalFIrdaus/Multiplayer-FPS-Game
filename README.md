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
    
Disini kita buat variabel xMove untuk horizontal dan zMove untuk vertical, untuk settings tombol yaitu dengan <b>Edit > Project Settings > Input Manager</b> Didalam Input Manager kita bisa melihat banyak isi dari Axes salah satunya adalah Horizontal dan Vertical , jika kita ingin set positiveButton dan negativeButton , default pada Input Horizontal adalah
  

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

## Membuat Velocity
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



## Fitur FPS Game
  1. [Pergerakan Player (Movement)](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game)
  2. [Networking Multiplayer](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game)
  3. [Melakukan Singkronisasi Player dengan Localplayer (Syncing Movement)](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game)
  4. [Membuat Player Terbang (Flying / Jump)](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game)
  5. [Menembak Player (Debugging Shot)](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game)
  6. [Hit Damage Player (Include Hit Point)](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game)
  7. [Respawn player ketika start game (Respawning Player)](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game)
  8. [Membuat Model pada Player (Make a Model Player)](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game)
  9. [Titik Tembak (CrossHair)](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game)


