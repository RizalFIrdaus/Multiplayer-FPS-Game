# Multiplayer-FPS-Game
<hr>
<a href="https://ibb.co/tKKkj19"><img src="https://i.ibb.co/2hhmVpT/Banner.jpg" style="width:100px; margin-left:auto; margin-right:auto;" alt="Banner" border="0"></a>


Saya membuat repository ini untuk pengalaman belajar saya menggunakan unity dengan C# , tutorial pembuatan game ini terinspirasi dari salah satu youtuber game developer yaitu [Channel Brackeys](https://www.youtube.com/user/Brackeys)


### Menambahkan Jump

Pertama yang dilakukan tentunya mendeteksi input dari user dengan menggunakan Input.GetButton("JUMP"), pada defaultnya unity menggunakan tombol SPACE.

Pertama yang dilakukan adalah membuat thrusterForce atau kekuatan dari lompatannyaa dengan menggunkan tipe data float

        [SerializeField]
        private float thrusterForce = 1000f;

Pada PlayerController kita berikan deteksi pada method Update seperti berikut

        Vector3 _thrusterForce = Vector3.zero;
       if (Input.GetButton("Jump"))
        {
            _thrusterForce = Vector3.up * thrusterForce;
        }
        motor.applyThruster(_thrusterForce);
 
Dari kodingan diatas, kita buat variable thrusterforce menjadi vector zero terlebih dahulu setelah itu terdapat logika if , jika input jump yang mana button SPACE dipencet maka thrusterForce tersebut akan dikalikan dengan vector z keatas , setelah itu kita lakukan pass variable ke method applyThruster yang akan kita buat nanti di PlayerMotor

Jika sudah langkah selanjutnya kita buat variablel thrusterForce pada PlayerMotor yang mana variable ini adalah wadah untuk deteksi input yang ada di PlayerController yang nanti akan kita eksekusi didalam PlayerMotor
        
        private Vector3 thrusterForce = Vector3.zero;

Setelah kita membuatnya kita buat Method applyThruster
 
        public void applyThruster(Vector3 _thrusterForce)
        {
            thrusterForce = _thrusterForce;
        }

jika sudah, kita sudah mendapatkan isi dari thrusterForce dari PlayerController , langkah selanjutnya kita lakukan pengecekan kalau vectornya tidak sama dengan (0,0,0), maka kita akan tambahkan Force pada objectnya pada method PerformMovement yang sudah kita buat sebelumya dalam melakukan pergerakan dari player

        if (thrusterForce != Vector3.zero)
        {
            rb.AddForce(thrusterForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        }

Kita gunakan AddForce untuk pergerakan dari thrusterForce dan menggunakan arah vector Up yang tadi sudah kita buat di dalam PlayerController , pada addforce ini kita hanya menambahkan pergerakan dan kita kalikan dengan Time.FixedDeltaTime yang mana perubahan akan selalu Fix , dan menggunakan ForceMode Acceleration untuk membuat rigidbody memiliki akselerasi yang berkelanjutan dan akan mengabaikan mess dari object tersebut .Jika sudah maka method PerformMovement akan dieksekusi pada method FixedUpdate


### Menambahkan Gravitasi dan Bouncing

Jika dijalankan kita bisa melakukan lompatan seperti yang kita inginkan , tetapi ingat kita hanya membuat object tersebut dengan force up , tidak adanya gerakan kebawah yang artinya ketika kita pencet SPACE maka player akan terbang terus karena memang object tidak kita berikan gravity , lalu solusi dari permasalah ini apa ? 
yaaaaap , kita gunakan <b>Configurable Joint</b> yang mana akan memberikan object tesebut gerakan kebawah dan adanya bouncing, kita import component <b>Configurable Joint</b> pada object player , ada beberapa yang akan kita set dalam Configurable Join

<a href="https://imgbb.com/"><img src="https://i.ibb.co/J7XTCmy/image.png" alt="image" border="0"></a>

Pada Y Drive terdapat <b>Position Spring</b> , <b>Position Damper</b> , <b>Maximum Force</b>

<table width:"100%";>
    <tr>
        <th>Property</th>
        <th>Function</th>
    </tr>
    <tr>
        <td>Position Spring</td>
        <td>Torsi Spring merupakan Rotasi Joint dari posisinya ke posisi yang akan dituju</td>
    </tr>
    <tr>
        <td>Position Damper</td>
        <td>Untuk mengurangi kecepatan dari Torsi Spring dalam meneuju posisi yang dituju</td>
    </tr>
     <tr>
        <td>Maximum Force</td>
        <td>Merupakan maksimum gaya yang akan dikeluarkan</td>
    </tr>
</table>

Lalu setelah kita sudah memberikan gaya kebawah dan adanya boucing ,jika kalian perhatikan dalam position spring terdapat current posisi dengan posisi tujuan , lalu bagaimana kita set posisi tersebut , kita bisa liat dibagian atas dari Y Drive terdapat Angular Z Limit terdapat <b>Target Position</b> dan <b>target velocity</b>

<table width:"100%";>
    <tr>
        <th>Property</th>
        <th>Function</th>
    </tr>
    <tr>
        <td>Target Position</td>
        <td>Terget melakukan posisi yang diinginkan</td>
    </tr>
    <tr>
        <td>Target Velocity</td>
        <td>Untuk melakukan tekanan ketarget yang akan menghasilkan bouncing yang besar jika value diperbesar</td>
    </tr>
</table>

Jika sudah , maka player kita bisa bisa melakukan lompatan dan memiliki gravitasi ketika didasar akan menghasilkan bouncing karena menggunakan Configurable Joint



## Fitur FPS Game
  1. [Pergerakan Player (Movement)](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game/tree/Movement-Player)
  2. [Networking Multiplayer](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game/tree/Networking)
  3. [Membuat Player Terbang (Flying / Jump)](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game/tree/Jump)
  4. Menembak Player (Debugging Shot) (Soon)
  5. Hit Damage Player (Include Hit Point) (Soon)
  6. Respawn player ketika start game (Respawning Player) (Soon)
  7. Membuat Model pada Player (Make a Model Player) (Soon)
  8. Titik Tembak (CrossHair) (Soon)
  
