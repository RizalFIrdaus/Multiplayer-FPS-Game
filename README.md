# Multiplayer-FPS-Game
<hr>
<a href="https://ibb.co/tKKkj19"><img src="https://i.ibb.co/2hhmVpT/Banner.jpg" style="width:100px; margin-left:auto; margin-right:auto;" alt="Banner" border="0"></a>


Saya membuat repository ini untuk pengalaman belajar saya menggunakan unity dengan C# , tutorial pembuatan game ini terinspirasi dari salah satu youtuber game developer yaitu [Channel Brackeys](https://www.youtube.com/user/Brackeys)


### Persiapan Component Networking

Dalam Unity sudah disediakan Package Multiplayer Game yang bisa kita gunakan , jadi kita bisa membuat game kita menjadi multiplayer dengan cukup mudah , caranya dengan import component network ke prefebs player yang sudah kita buat sebelumnya. Tetapi sebelum itu kita harus import package terlebih dahulu kedalam project kita 
dengan cara klik <b>Window > Package Manager > MultiplayeHLAPI</b> jika sudah menemukan packagenya , install dengan menekan tombol kanan bawah, jika sudah maka kita sudah siap import Component networknya.

<a href="https://imgbb.com/"><img src="https://i.ibb.co/BgxFyCP/Capture.jpg" alt="Capture" border="0"></a>

Jika sudah langkah selanjutnya kita import Component Networking untuk Player yaitu <b>NetworkTransform , NetworkIdentity, NetworkTransformChild</b>


<b>NetworkTransform</b>

<a href="https://imgbb.com/"><img src="https://i.ibb.co/cJtfKrX/image.png" alt="image" border="0"></a>

Component ini berguna untuk melakukan translasi transformasi dari prefebs player


<b>NetworkIdentity</b>

<a href="https://imgbb.com/"><img src="https://i.ibb.co/vD7hgJm/image.png" alt="image" border="0"></a>

Componen ini berguna untuk mengidentifikasi local player, dan pada component ini harus melakukan centang pada Local Player Authority untuk membedakan player dengan local player


<b>NetworkTransformChild</b>

<a href="https://imgbb.com/"><img src="https://i.ibb.co/312VZjM/image.png" alt="image" border="0"></a>

Componen ini berguna untuk melakukan transform pada childenya , karena object player ini memiliki child seperti camera , modelplayer , dan tentunya senjata agar berpindah relative terhadap parentnya. Pada target masukkan object camera yang merupakan child dari player atau kata lain camera untuk senjatanya.


### Membuat Network Manager


<a href="https://imgbb.com/"><img src="https://i.ibb.co/7r2KhzC/image.png" alt="image" border="0"></a>

Pertama kita buat empty object dan pada child nya kita buat juga empty object yang nantinya akan diberikan NetworkStartPosition yang berutujuan untuk merespown spot dari player , jika sudah , pada Object <b>_NetworkManager</b> kita masukkan Component <b>NetworkManager dan NetworkManagerUHD</b>

<b>NetworKManager</b>

<a href="https://imgbb.com/"><img src="https://i.ibb.co/PwdX7SV/image.png" alt="image" border="0"></a>

Component ini berguna untuk memanagement network seperti respawn prefebs , ataupun network info sperti ip dan semacamnya , pada Spawn Info kita import Player agar pada saat game dimulai , Player akan kepanggil kedalam game

<b>NetworKManagerHUD</b>

<a href="https://imgbb.com/"><img src="https://i.ibb.co/qxFMw5r/image.png" alt="image" border="0"></a>

Component ini berguna untuk menampilkan GUI Manager , seperti tombol start host , dan start client seperti pada gambar dibawah

<a href="https://imgbb.com/"><img src="https://i.ibb.co/XYsjmVQ/image.png" alt="image" border="0"></a>

Jika dijalankan maka akan tampil seperti pada gambar diatas , untuk mencoba apakah sudah bisa multiplayer atau tidak , kita bisa melakukan build and run game dengan resolusi 800x600 ,kita bisa settings di player settings yang terdapat pada build project 

<a href="https://ibb.co/30rQqW1"><img src="https://i.ibb.co/LCkHW6S/image.png" alt="image" border="0"></a>

Jika sudah coba build and run , nanti kita kaan coba panggil player 1 dan player 2 pada game , untuk player 1 sebagai host dan player 2 sebagai client,yang sudah kita build and run tadi kita bisa jadikan dia client dan host nanti kita coba digame didalam editor unitynya, jika berhasil maka akan tampil seperti pada gambar dibawah ini

<a href="https://ibb.co/hmvwxpL"><img src="https://i.ibb.co/Nyzbgwt/image.png" alt="image" border="0"></a>

Tetapi ada kendala disini yaitu ketika player host mergerak , maka local player pun ikut bergerak. Ini dikarenakan local player itu memiliki script dari player host , untuk mengatasi hal ini kita harus melakukan disable beberapa script seperti <b>PlayerController , PlayerMotor , Camera senjata , dan audio </b> supaya tidak terjadinya duplikasi audio

Untuk itu kita buat terlebih dahulu script PlayerSetup, lalu import ke dalam Object Player

    using UnityEngine.Networking;

Untuk memulai kita harus memanggil package Networking agar kita bisa melakukan pemanggilan Component Network , jika sudah tidak lupa kita ubah <b>MonoBehaviour ke NetworkBehaviour </b> supaya bisa dihandle oleh network.

    [SerializeField]
    Behaviour[] componentToDisable;
    Camera cam;

Setelah itu kita buat Inspector UI dengan mengetikan SerializeField lalu kita ketika <b>Behaviour</b>, untuk memberitahu bahwa akan dihandle oleh network dan tentunya kita beri tipe data array , karena kita ingin melakukan disable lebih banyak dari satu script , dan diakhir kita instansiasi camera untuk nanti menonaktifkan main camera

    void Start()
    {

        if (!isLocalPlayer)
        {
            DisableComponent();
        }
        else
        {
            cam = Camera.main;
            if(cam != null)
            {
                cam.gameObject.SetActive(false);
            }
        }


    }
    
Pada method Start , kita akan melakukan disable. Tentunya tidak semuanya kita disable , yang akan kita disable adalah yang bukan local machine player yaitu dengan melakukan pengecekan jika bukan localplayer maka kita akan disable yang mana itu ada player 2 akan terdisable , lalu kita buat function DisableComponentnya 
 
    void DisableComponent()
    {
        for(int i = 0; i < componentToDisable.Length; i++)
        {
            componentToDisable[i].enabled = false;
        }
    }

Untuk melakukan disable kita menggunakan enable dan diberikan value false , tetapi karena kita ingin mendisable lebih dari satu script, kita lakukan pengulangan dengan for seperti diatas , Jika sudah semua kita coding , jangan lupa kita harus import script dan object yang akan kita disable di script Setup ini seperti pada gambar dibawah

<a href="https://imgbb.com/"><img src="https://i.ibb.co/g7Hv8Tr/image.png" alt="image" border="0"></a>

Terdapat 4 element yang akan kita disable , yaitu <b>PlayerController , PlayerMotor , Camera , Audio Camera</b>
Jika sudah maka coba run and build kembali lalu mulai jalankan game multiplayer , jika berhasil maka , ketika player 1 digerakan yang terjadi adalah player 2 akan tetap diam karena kita melakukan disable script pada player 2 ,sedakngkan player 2 ketika ingin bergerak maka player 1 tidak mengikuti pergerakan dari player 2.



## Fitur FPS Game
  1. [Pergerakan Player (Movement)](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game/tree/Movement-Player)
  2. [Networking Multiplayer](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game/tree/Networking)
  3. Melakukan Singkronisasi Player dengan Localplayer (Syncing Movement) (Soon)
  4. Membuat Player Terbang (Flying / Jump) (Soon)
  5. Menembak Player (Debugging Shot) (Soon)
  6. Hit Damage Player (Include Hit Point) (Soon)
  7. Respawn player ketika start game (Respawning Player) (Soon)
  8. Membuat Model pada Player (Make a Model Player) (Soon)
  9. Titik Tembak (CrossHair) (Soon)
  
