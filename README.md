# Multiplayer-FPS-Game
<hr>
<a href="https://ibb.co/tKKkj19"><img src="https://i.ibb.co/2hhmVpT/Banner.jpg" style="width:100px; margin-left:auto; margin-right:auto;" alt="Banner" border="0"></a>


Saya membuat repository ini untuk pengalaman belajar saya menggunakan unity dengan C# , tutorial pembuatan game ini terinspirasi dari salah satu youtuber game developer yaitu [Channel Brackeys](https://www.youtube.com/user/Brackeys)


### Debug Shoot
Pertama kita tambahkan tembakan pada pistol kita , tetapi terlebih dahulu kita uji coba apakah berhasil atau tidak dengan melakukan debug terlebih dahulu sebelum kita berikan effect peluru , muzzle flash , dan impact shoot. Langkah pertama kita buat terlebih dahulu script untuk weapon kita disini saya berikan nama filenya yaitu PlayerWeapon , dan import komponen script itu ke dalam prebs player kita.Setelah itu kita buat nama weapon , jangakauan weapon , dan damage weapon.

Sebelum itu karna saya membuat script ini untuk informasi weapon yang akan tampil didalam inspector unity yaitu dengan menggunakan System.Serializable

        [System.Serializable]
        public class PlayerWeapon : MonoBehaviour
        {
            public string weapName = "Pistol-M53";
            public float weapRange = 100f;
            public float damage = 20f;

        }
 
Jika sudah membuat script diatas , sekarang kita buat lagi script untuk menembak si player , disini saya berikan nama PlayerShoot , jika sudah dibuat kita hubungakan script ini dengan script PlayerWeapon dan tidak lupa kita using networking

        using UnityEngine.Networking;
        [RequireComponent(typeof(PlayerWeapon))]
        
Jika sudah terhubung langkah selanjutnya kita ubah monobehaviour menjadi networkbehavior

        using UnityEngine.Networking;
        [RequireComponent(typeof(PlayerWeapon))]
        
        public class PlayerShoot : NetworkBehaviour
        {
            public PlayerWeapon currentWeapon;
            [SerializeField]
            private LayerMask mask;
            [SerializeField]
            private Camera cam;
        }
Kita masukkan beberapa variable , pertama PlayerWeapon kita instansiasi kedalam script ini karena kita membutuhkan weapRangenya untuk raycasthit
setelah itu kita LayerMask untuk mendeteksi layer , dan camera untuk memposisikan raycast dan tembakan kedepan , terlebih dahulu kita cek kondisi ketika camera tidak dimasukkan kedalam inspect unity dengan melakukan debug.log pada void start

           void Start()
            {

                if ( cam == null)
                {
                    Debug.LogError("Tidak tersedianya kamera untu referensi");
                    this.enabled = false;
                }

            }

Dari codingan diatas kita mengecek jika cam tidak ada maka kita berikan debug error , dan camera kita disable
Jika sudah kita buat deteksi dari player ketika player menembak dengan menggunakan mouse kiri 

        void Update()
            {

                if ( Input.GetButtonDown("Fire1"))
                {
                    Shoot();
                }

            }

Kita gunakan method update kerena kita akan memanggil method ini berkali kali , lalu pada method ini kita berikan pengecekan jika mouse kiri ditekan = "Fire1" , untuk default Fire1 itu merupaakn click kiri dari mouse , jika ingin diubah tentunya kita bisa pergi ke input manager, tetapi saya menggunakan default dari unitynya menggunakan click kiri mouse. Jika mouse diklik maka player akan melakukan shoot, setelah itu kita buat method shoot
        
           private void Shoot()
            {
                RaycastHit _hit;

                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, currentWeapon.weapRange, mask))
                {
                    Debug.Log("Player telah menembak " + _hit.collider.name);

                }
            }
Disini saya buat fitur menembak dengan menggunakan Raycashhit atau semacam sensor yaitu dengan memanggil RaycasHit dan berikan nama var nya untuk menampung raycastnya , jika sudah kita gunakan kondisi jika Physics.Raycast , terdapat 5 parameter 

 <table style="width:100%">
  <tr>
    <th>Parameter</th>
    <th>Referensi</th>
    <th>Fungsi</th>
  </tr>
  <tr>
    <td>Parameter 1</td>
    <td>posisi camera pistol</td>
    <td>posisi sensor</td>
  </tr>
 <tr>
    <td>Parameter 2</td>
    <td>Arah camera pistol dan berikan arah kedepan/forward</td>
    <td>Arah sensor</td>
  </tr>
  <tr>
    <td>Parameter 3</td>
    <td>_hit</td>
    <td>output raycast</td>
  </tr>
   <tr>
    <td>Parameter 4</td>
    <td>WeapRange</td>
    <td>Jangkauan sensor </td>
  </tr>
  <tr>
    <td>Parameter 5</td>
    <td>Mask</td>
    <td>Layer yang bisa ditembak</td>
  </tr>
</table> 

jika sudah kita lakukan debug , jika berhasil ketika kita click mouse kiri akan tampil seperti pada gambar dibawah ini

<a href="https://imgbb.com/"><img src="https://i.ibb.co/PQz14zW/image.png" alt="image" border="0"></a>




## Fitur FPS Game
  1. [Pergerakan Player (Movement)](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game/tree/Movement-Player)
  2. [Networking Multiplayer](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game/tree/Networking)
  3. [Membuat Player Terbang (Flying / Jump)](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game/tree/Jump)
  4. Menembak Player (Debugging Shot) (Soon)
  5. Hit Damage Player (Include Hit Point) (Soon)
  6. Respawn player ketika start game (Respawning Player) (Soon)
  7. Membuat Model pada Player (Make a Model Player) (Soon)
  8. Titik Tembak (CrossHair) (Soon)
  
