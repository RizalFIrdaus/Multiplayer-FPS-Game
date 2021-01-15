# Multiplayer-FPS-Game
<hr>
<a href="https://ibb.co/tKKkj19"><img src="https://i.ibb.co/2hhmVpT/Banner.jpg" style="width:100px; margin-left:auto; margin-right:auto;" alt="Banner" border="0"></a>


Saya membuat repository ini untuk pengalaman belajar saya menggunakan unity dengan C# , tutorial pembuatan game ini terinspirasi dari salah satu youtuber game developer yaitu [Channel Brackeys](https://www.youtube.com/user/Brackeys)


### Weapon Manager

Pada kesempatan kali ini  ,saya membuat weapon manager untuk memanagement senjata.Kita akan lakukan instansiate otomatis senjata kepada player dengan menggunakan primary weapon dan current weapon , pada primary weapon nantinya kita berikan object dan object tersebut nantinya akan dipass ke current weapon atau weapon yang sedang digunakan.

Pertama kita lepas terlebih dahulu senjata dari weapon holder dengan melakukan save prefab variant agar material dan texture tidak hilang

<a href="https://imgbb.com/"><img src="https://i.ibb.co/smK6gmD/image.png" alt="image" border="0"></a>

jika sudah , maka prefb player kita sudah tidak memegang senjata. kita akan masukkan senjata tersebut dengan otomatis dengan memanfaatkan management weapon , pertama kita buat terlebih dahulu object graphics pada PlayerWeapon yang nantinya akan diimport object graphics senjatanya didalam variable tersebut

        using UnityEngine;

        [System.Serializable]
        public class PlayerWeapon
        {

            public string weapName = "Pistol-M53";
            public float weapRange = 100f;
            public float damage = 20f;
            public GameObject graphics;


        }
jika sudah ditambahan gameobject pada PlayerWeapon , langkah selanjutnya kita buat script baru dengan WeaponManager pada preferb player

        using UnityEngine;
        using UnityEngine.Networking;
        
        [System.Obsolete]
        public class WeaponManager : NetworkBehaviour 
        {
            private PlayerWeapon currentWeapon;
            
            [SerializeField]
            private PlayerWeapon primaryWeapon;
            [SerializeField]
            private Transform weaponHolder;
            

            void Start()
            {
                EquipWeapon(primaryWeapon);
            }


            void EquipWeapon(PlayerWeapon _weap)
            {
                currentWeapon = _weap;

               GameObject _weaponIns = (GameObject)Instantiate(_weap.graphics, weaponHolder.position, weaponHolder.rotation);
                _weaponIns.transform.SetParent(weaponHolder);
            }


            public PlayerWeapon getCurrentWeapon()
            {
                return currentWeapon;
            }

        }

Kita buat WeaponManager menggunakan NetworkBehaviour karena akan dieksekusi juga kedalam server , dengan begitu tentunya kita using unity networking
Setelah itu kita buat primary weapon untuk mengambil graphics weapon dan weapon holder untuk merespawn location dan rotation pada weaponya

Lalu pada method start kita buat method Equip Weapon yang mana terdapat parameter berupa primaryWeapon , setelahnya kita buat method tersebut dengan parameter yang mereferensi dari PlayerWeapon , didalam method tersebut kita swap primarry weapon ke current weapon , laiu instansiate graohics yang diambil dari graphics dari yang sudah kita import nanti , dan untuk parameter kedua itu merupakan posisi dari graphics dan parameter ke3 itu merupakan rotasi dari weapon holder , pada position dan rotation kita gunakan object weaponHolder.
Jika sudah lakukan transform terhadap parent weapon holder

lalu kita beralih ke PlayerShoot , dimana terdapat method start , didaamnya kita instansiasi component weapon manager

         void Start()
            {

                if ( cam == null)
                {
                    Debug.LogError("Tidak tersedianya kamera untu referensi");
                    this.enabled = false;
                }
                weapManager = GetComponent<WeaponManager>();
            }
            
setelah itu pada update kita eksekusi pass primary weapon dengan current weapon
        
        currentWeapon = weapManager.getCurrentWeapon();

### Rapid Fire

Sekarang kita yang kilakukan adalah melakukan sistem penembakan beredet dan shotgun , pertama kita buat pada weapon manager sebuah variable fireRate untuk kecepatan dari tembakan nanti kita akan berikan fireRate= 0 untuk shotgun , sedangkan beredet akan diberikan fire rate diatas 0.

Pertama kita ubah pada update pada file PlayerShoot



## Fitur FPS Game
  1. [Pergerakan Player (Movement)](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game/tree/Movement-Player)
  2. [Networking Multiplayer](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game/tree/Networking)
  3. [Membuat Player Terbang (Flying / Jump)](https://github.com/RizalFIrdaus/Multiplayer-FPS-Game/tree/Jump)
  4. Menembak Player (Debugging Shot)
  5. Graphics Modelling
  6. Rapid Fire

  
