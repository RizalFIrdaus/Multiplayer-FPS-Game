# Multiplayer-FPS-Game
<hr>
<a href="https://ibb.co/tKKkj19"><img src="https://i.ibb.co/2hhmVpT/Banner.jpg" style="width:100px; margin-left:auto; margin-right:auto;" alt="Banner" border="0"></a>


Saya membuat repository ini untuk pengalaman belajar saya menggunakan unity dengan C# , tutorial pembuatan game ini terinspirasi dari salah satu youtuber game developer yaitu [Channel Brackeys](https://www.youtube.com/user/Brackeys)


### Graphics Player Model 

Pertama kita berikan graphics untuk player model , kita bisa ambil assets free dari website atau membuat sendiri.Tetapi saya disini menggunakan assets dari https://devassets.com/assets/multiplayer-fps-assets/ , dalam assets tersebut saya hanya menggunakan modelling player dan texturenya , jika sudah didownload kita drag and drop saja ketempat project kita diunity. Jika sudah langkah selanjutnya kita buat telebih dahulu hirarki seperti pada gambar dibawah

<a href="https://imgbb.com/"><img src="https://i.ibb.co/QDwMcXF/image.png" alt="image" border="0"></a>

pada player model kita reset transform agar posisi model sama dengan parentnya yaitu Graphics dan berikan textrurenya yang nanti akan tampil seperti pada gambar dibawah

<a href="https://imgbb.com/"><img src="https://i.ibb.co/qdX00f2/image.png" alt="image" border="0"></a>


### Graphics Weapon

Jika sudah memberikan model pada player , langkah selanjutnya kita beri graphics pada weaponnya dengan menggunakan assets yang diambil dari website secara gratis atau membuat sendiri. Pada project ini saya mengambil dari  https://devassets.com/assets/modern-weapons/  download lalu setelah itu import filenya kedalam project unity.
masukkan preferb senjatannya kedalam gameobject weapon holder dan tentunya kita reset transform agar posisi dan rotasi menyesuaikan dari parentnya dan tidak lupa berikan texture nantinya akan tampil seperti pada gambar dibawah 

<a href="https://imgbb.com/"><img src="https://i.ibb.co/yQjP1yc/image.png" alt="image" border="0"></a>


## Menghilakan graphic yang menghalangi camera

Jika kalian play , maka disini kita dapat kendala yaitu player model akan menghalangin pandangan player untuk menembak. disini kita hilangkan padangan graphics player pada camera kita , tetapi tetap bisa diliat oleh player lainnya ketika multiplayer 

<a href="https://ibb.co/hF63y7f"><img src="https://i.ibb.co/gZ2k3jV/image.png" alt="image" border="0"></a>

kita bisa diliat diatas , player model mengganggu pandangan player, untuk mengatasi ini kita pertama kita buat terlebih dahulu layer dengan nama bebas tetapi untuk merepresentasikannya saya memberikan nama dontDraw 

<a href="https://imgbb.com/"><img src="https://i.ibb.co/G2HPCPL/image.png" alt="image" border="0"></a>

dan kita matikan layer dontDraw culling mask pada camera

<a href="https://imgbb.com/"><img src="https://i.ibb.co/6r6w3cf/image.png" alt="image" border="0"></a>

setelah itu kita coding pada playersetup

        [SerializeField]
        GameObject PlayerGraphics;
        [SerializeField]
        string dontDrawLayerName = "dontDraw";

Pertama kita buat terlebih dahulu gameobject yang nantinya akan kita masukkan graphics model playernya yang akan kita disable.
setelah itu kita buat variable untuk string dontDraw

    void SetLayerRecursively(GameObject obj , int newLayer)
    {
        obj.layer = newLayer;
        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }

Disini kita buat recursive atau penganggilan method itu sendiri bertujuan untuk menghilangkan childnya juga pada modelnya 
setelah itu kita panggil method ini pada start method

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
                    //Panggil method tadi disini
                    SetLayerRecursively(PlayerGraphics,LayerMask.NameToLayer(dontDrawLayerName));
                }
            }

jika sudah maka hasilnya seperti pada gambar dibawah

<a href="https://ibb.co/LnFYh5n"><img src="https://i.ibb.co/2g9WYNg/image.png" alt="image" border="0"></a>

Pada gambar diatas sudah kita hilangkan model player pada camera dan tentunya kita tidak bisa melihat bayangan pada model player tetapi player lain bisa melihat model player kita


## Fitur FPS Game
  1. [Pergerakan Player (Movement)](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game/tree/Movement-Player)
  2. [Networking Multiplayer](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game/tree/Networking)
  3. [Membuat Player Terbang (Flying / Jump)](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game/tree/Jump)
  4. Menembak Player (Debugging Shot)
  5. Graphics Modelling

  
