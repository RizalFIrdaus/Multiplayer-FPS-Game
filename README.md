# Multiplayer-FPS-Game
<hr>
<a href="https://ibb.co/tKKkj19"><img src="https://i.ibb.co/2hhmVpT/Banner.jpg" style="width:100px; margin-left:auto; margin-right:auto;" alt="Banner" border="0"></a>


Saya membuat repository ini untuk pengalaman belajar saya menggunakan unity dengan C# , tutorial pembuatan game ini terinspirasi dari salah satu youtuber game developer yaitu [Channel Brackeys](https://www.youtube.com/user/Brackeys)


## Penejelasan Codingan
  
  <table style="width:100%">
  <tr>
    <th>Keyword</th>
    <th>Fungsi</th>
  </tr>
  <tr>
    <td>Method Start()<td/>
    <td>Akan panggil ketika Game dijalankan satukali</td>
  </tr>
  <tr>
    <td>Method Update()<td/>
    <td>Fungsi ini akan dipanggil setiap frame per detik yang dimana akan selalu berubah dan terus mengulangnya sampai game berhenti atau keluar dari game tersebut.</td>
  </tr>
  <tr>
    <td>GetComponent<>()<td/>
    <td>Memanggil komponen </td>
  </tr>
  <tr>
    <td>Input.GetAxis()<td/>
    <td>Deteksi input keyboard</td>
  </tr>
  <tr>
    <td>transform.right<td/>
    <td>Memindahkan object kekanan/td>
  </tr>
   <tr>
     <td>transform.left<td/>
    <td>Memindahkan object kekiri/td>
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



