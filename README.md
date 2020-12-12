# android-game
2d android game project

movement script 
public class Character_move : MonoBehaviour {

    public static int playerSpeed = 10;

    // Update is called once per frame
    void FixedUpdate () {
        gameObject.transform.Translate(Vector3.right * playerSpeed * Time.fixedDeltaTime);
        }
}

-------------------------------------------------------------------------------------------------------------------------------------------------

Player Controls 
public class Player_Controlls : MonoBehaviour{

    public static float jetPackFuel = 1.5f;
    public float jetPackForce = 10.0f;

     // Update is called once per frame
    void Update() {
        if (Input.GetButton("Jump") && jetPackFuel >= 0.001f){
            BoostUp();
        }
      }

        void BoostUp () {
        jetPackFuel = Mathf.MoveTowards(jetPackFuel, 0, Time.fixedDeltaTime);
        GetComponent<Rigidbody>().AddForce(new Vector3(0, jetPackForce));
    }

    void OnCollisionEnter (Collision Col){
        if (Col.gameObject.tag == "Ground") {
            jetPackFuel = 1.5f;
        }
    }
}

------------------------------------------------------------------------------------------------------------------------------------------------------------------------


Player collider

public class Player_Col : MonoBehaviour {

    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "Enemy"){
            PlayerDies();
        }

    }

    void OnTriggerEnter(Collider trig){
        if (trig.gameObject.tag == "Coin") {
            //increase score
            //increase coin collection
            //play audio affect
            Destroy(trig.gameObject);
        }
    }

    void PlayerDies () {
        //play death audio
        //save acore
        //activate UI for restarting game
        Application.LoadLevel("Main");

    }
}

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

Camera Follow
public class Camera_Follows : MonoBehaviour{

    private GameObject player;
    public float cameraSpeed = 5.0f;

// Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
         }

    // Update is called once per frame
    void FixedUpdate () {
        //X position follow
        Vector3 camPos = transform.position;
        camPos.x = player.transform.position.x - -9.0f;
        transform.position = Vector3.Lerp(transform.position, camPos, 3 * Time.fixedDeltaTime);

        // position follow
        camPos.y = player.transform.position.y + 2;
        transform.position = Vector3.Lerp(transform.position, camPos, 7.0f * Time.fixedDeltaTime);
        }
}

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Object Spawner 
public class Object_Spawner : MonoBehaviour {

    public GameObject Player;
    public GameObject[] coins;
    public GameObject[] trees;
    public GameObject enemy;
    private float coinSpawnTimer = 7.0f;
    private float enemySpawnTimer = 10.0f;
    private float treeSpawnTimer = 0.5f;

    // Update is called once per frame
    void Update() {
        coinSpawnTimer -= Time.deltaTime;
        enemySpawnTimer -= Time.deltaTime;
        treeSpawnTimer -= Time.deltaTime;

        if (coinSpawnTimer < 0.01) {
            SpawnCoins();
        }
        if (enemySpawnTimer < 0.01) {
            SpawnEnemy();
        }
        if (treeSpawnTimer < 0.01) {
            SpawnTrees();

        }
    }

    void SpawnCoins () {
        Instantiate(coins [(Random.Range (0, coins.Length ))], new Vector3 (Player.transform.position.x + 30, Random.Range(2, 8), 0), Quaternion.identity);
        coinSpawnTimer = Random.Range(1.0f, 3.0f);
    }

    void SpawnEnemy() {
        enemy.transform.localScale = new Vector3(Random.Range(1, 1.5f), Random.Range(1, 1.5f), Random.Range(1, 1.5f));
        Instantiate (enemy, new Vector3 (Player.transform.position.x + 30, Random.Range (1, 9), 0), Quaternion.identity);
        enemySpawnTimer = Random.Range (1, 3);
    }

    void SpawnTrees () {
        Instantiate(trees[(Random.Range(0, trees.Length))], new Vector3(Player.transform.position.x + 70, 0, Random.Range(5, 22)), Quaternion.identity);
        treeSpawnTimer = 0.5f;
    }

}

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Object Rotate
public class Rotate_Object : MonoBehaviour
{
    public int rotateSpeed;

 // Update is called once per frame
    void FixedUpdate () {
        transform.Rotate(Vector3.up * rotateSpeed * Time.fixedDeltaTime);
    }
}

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Audio 
public class AudioFX : MonoBehaviour {

    public AudioClip death, jetPack, coinCollect;

    // Update is called once per frame
    void Update() {
        if (Input.GetButton ("Jump") && Player_Controlls.jetPackFuel >= 0.01f) {
            GetComponent<AudioSource>().PlayOneShot (jetPack, 1.0f);

        }
        
    }

    void OnCollisionEnter (Collision col){
        if (col.gameObject.tag == "Enemy") {
            GetComponent<AudioSource>().PlayOneShot (death, 1.0f);

        }
    }

    void OnTriggerEnter(Collider trig){
        if (trig.gameObject.tag == "Coin") {
            GetComponent<AudioSource>().PlayOneShot (coinCollect, 1.0f);

        }
    }
}
