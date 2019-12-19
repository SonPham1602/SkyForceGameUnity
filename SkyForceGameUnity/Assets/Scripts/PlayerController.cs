using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TypeControllerGame
{
    Mouse,
    GamePad,
    Keyboard
}
public class PlayerController : MonoBehaviour
{
    public GameObject target;
    public GameObject bullet;
    public int numberBullet = 1;
    private float hp;// hp cua may bay
    public float speedShip = 100f;

    private float radius;
    private float lastTimeFire = 0;

    public GameObject[] planeChild;
    private Rigidbody2D rb;
    Vector2 direction;
    private bool isMove;
    public TypeControllerGame typeControllerGame;
    [SerializeField] GameObject hitLayer;

    public bool canMove;

    public float HP
    {

        get => hp;
        set
        {
            hp = value;
            if (hp <= 30)
            {

                hitLayer.GetComponent<Animator>().SetTrigger("ShowLowHealth");

            }
            else if (hp <= 0)
            {
                FindObjectOfType<GameManager>().gameOver();
            }
        }
    }

    struct BulletPos
    {
        public Vector2 pos1;
        public Vector2 pos2;
    };

    struct ValueEquation
    {
        public float x1;
        public float x2;
    };

    // Start is called before the first frame update
    void Start()
    {
        radius = Vector3.Magnitude(target.transform.position - gameObject.transform.position);
        this.HP = 100;
        rb = GetComponent<Rigidbody2D>();
        typeControllerGame = GameSetting.typeControllerGame;
    }
    private void OnMouseOver()
    {
        isMove = false;
        Debug.Log("Move false");
    }
    /// <summary>
    /// Called when the mouse is not any longer over the GUIElement or Collider.
    /// </summary>
    void OnMouseExit()
    {
        isMove = true;
        Debug.Log("Move true");
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (typeControllerGame == TypeControllerGame.Mouse && canMove == true)
        {
            if (Mathf.Abs(mousePosition.x) <= 28 && Mathf.Abs(mousePosition.y) <= 16)
            {

                direction = (mousePosition - new Vector2(transform.position.x, transform.position.y)).normalized;
                // Debug.Log(direction.x+ "   " + direction.y);
                Debug.Log(mousePosition.x + "   " + mousePosition.y + "   " + transform.position.x + "  " + transform.position.y);
                if (isMove != false)
                {
                    rb.velocity = new Vector2(direction.x * speedShip, direction.y * speedShip);
                }
                else
                {
                    rb.velocity = Vector2.zero;
                    gameObject.transform.Translate((mousePosition - new Vector2(gameObject.transform.position.x, gameObject.transform.position.y)) * Time.deltaTime * speedShip);
                }
            }
            else
            {

                if (((mousePosition.x) > 28))
                {
                    mousePosition.x = 26;
                    isMove = false;
                }
                else if (mousePosition.x < -28)
                {
                    mousePosition.x = -26;
                    isMove = false;
                }
                if (((mousePosition.y) > 16))
                {
                    mousePosition.y = 14;
                    isMove = false;
                }
                else if (mousePosition.y < -16)
                {
                    mousePosition.y = -14;
                    isMove = false;
                }
                direction = (mousePosition - new Vector2(transform.position.x, transform.position.y)).normalized;
                if (isMove != false)
                {
                    rb.velocity = new Vector2(direction.x * speedShip, direction.y * speedShip);
                }
                else
                {
                    if (Mathf.Abs(mousePosition.x) > 24 || Mathf.Abs(mousePosition.y) > 12)
                    {
                        rb.velocity = Vector2.zero;
                        gameObject.transform.Translate((mousePosition - new Vector2(gameObject.transform.position.x, gameObject.transform.position.y)) * Time.deltaTime * speedShip);
                    }
                    else
                    {
                        rb.velocity = new Vector2(direction.x * speedShip, direction.y * speedShip);
                    }

                }
            }

            if (Input.GetMouseButton(0) && Time.time - lastTimeFire >= 0.2f)
            {
                lastTimeFire = Time.time;
                CreateBullet(bullet);
            }


            //rb.velocity = Vector2.zero;
        }
        else if (typeControllerGame == TypeControllerGame.GamePad && canMove == true)
        {
            float translationY = Input.GetAxis("Vertical") * speedShip * Time.deltaTime;
            float translationX = Input.GetAxis("Horizontal") * speedShip * Time.deltaTime;
            if (Mathf.Abs(transform.position.x) > 28)
            {
                speedShip = 0;
            }

            if (Mathf.Abs(transform.position.y) > 16)
            {
                speedShip = 16;
            }

            transform.Translate(translationX, translationY, 0);



            if (Input.GetKeyDown("joystick button 0") && Time.time - lastTimeFire >= 0.2f)
            {
                lastTimeFire = Time.time;
                CreateBullet(bullet);
            }
        }


        // check low health of player

    }

    //Create bullet
    void CreateBullet(GameObject bullet)
    {
        float Goc = 0.1f;
        BulletPos bulletPos;
        int dem = numberBullet;

        if (numberBullet % 2 == 1)
        {
            CreateOneBullet(target.transform.position, bullet, 10);
            Goc = 0.1f;
            dem--;
        }
        else
        {
            Goc = 0.06f;
        }

        for (int i = 1; i <= dem / 2; i++)
        {
            setBulletPos(out bulletPos, Goc * i);
            CreateOneBullet(bulletPos.pos1, bullet, 10);
            CreateOneBullet(bulletPos.pos2, bullet, 10);
        }
    }

    void CreateOneBullet(Vector3 pos, GameObject bullet, float speed)
    {
        GameObject b = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        b.GetComponent<BulletController>().targetPosition = pos;
        b.GetComponent<BulletController>().moveSpeed = speed;
        b.GetComponent<BulletController>().Power = 50;
    }

    private void setBulletPos(out BulletPos pos, float goc)
    {
        Vector3 shipPos = new Vector3(transform.position.x, transform.position.y, 0);
        Vector3 targetPos = new Vector3(target.transform.position.x, target.transform.position.y, 0);
        //hệ số phương trình khoảng cách |ax + by +c|=d
        Vector4 heSo = new Vector4(shipPos.y - targetPos.y, targetPos.x - shipPos.x,
                                    -1 * ((shipPos.y - targetPos.y) * shipPos.x + (targetPos.x - shipPos.x) * shipPos.y),
                                    radius * Mathf.Sin(goc) * Mathf.Sqrt(Mathf.Pow(shipPos.y - targetPos.y, 2.0f) + Mathf.Pow(targetPos.x - shipPos.x, 2.0f)));
        Vector3 heSoPtBac2 = new Vector3();
        Vector3 temp1, temp2;
        //giải tìm tọa độ
        float d = heSo.w;
        ValueEquation nghiem;
        heSoPtBac2.x = Mathf.Pow(heSo.y / heSo.x, 2) + 1;
        heSoPtBac2.y = 2 * ((-1 * heSo.y / heSo.x) * ((d - heSo.z) / heSo.x - shipPos.x) - shipPos.y);
        heSoPtBac2.z = Mathf.Pow((d - heSo.z) / heSo.x - shipPos.x, 2.0f) + Mathf.Pow(shipPos.y, 2.0f) - Mathf.Pow(radius, 2.0f);
        giaiPt(heSoPtBac2, out nghiem);
        temp1 = new Vector3((d - heSo.z - heSo.y * nghiem.x1) / heSo.x, nghiem.x1, 0);
        temp2 = new Vector3((d - heSo.z - heSo.y * nghiem.x2) / heSo.x, nghiem.x2, 0);
        if (Vector3.Magnitude(temp1 - targetPos) < Vector3.Magnitude(temp2 - targetPos))
        {
            pos.pos1 = temp1;
        }
        else
        {
            pos.pos1 = temp2;
        }

        d = -1 * heSo.w;
        heSoPtBac2.x = Mathf.Pow(heSo.y / heSo.x, 2) + 1;
        heSoPtBac2.y = 2 * ((-1 * heSo.y / heSo.x) * ((d - heSo.z) / heSo.x - shipPos.x) - shipPos.y);
        heSoPtBac2.z = Mathf.Pow((d - heSo.z) / heSo.x - shipPos.x, 2.0f) + Mathf.Pow(shipPos.y, 2.0f) - Mathf.Pow(radius, 2.0f);
        giaiPt(heSoPtBac2, out nghiem);
        temp1 = new Vector3((d - heSo.z - heSo.y * nghiem.x1) / heSo.x, nghiem.x1, 0);
        temp2 = new Vector3((d - heSo.z - heSo.y * nghiem.x2) / heSo.x, nghiem.x2, 0);
        if (Vector3.Magnitude(temp1 - targetPos) < Vector3.Magnitude(temp2 - targetPos))
        {
            pos.pos2 = temp1;
        }
        else
        {
            pos.pos2 = temp2;
        }
    }

    private void giaiPt(Vector3 heSoPtBac2, out ValueEquation nghiem)
    {
        nghiem.x1 = 0;
        nghiem.x2 = 0;
        float delta = Mathf.Pow(heSoPtBac2.y, 2.0f) - 4 * heSoPtBac2.x * heSoPtBac2.z;
        if (delta == 0)
        {
            nghiem.x1 = nghiem.x2 = -heSoPtBac2.y / (2 * heSoPtBac2.x);
        }
        else if (delta > 0)
        {
            nghiem.x1 = (-heSoPtBac2.y + Mathf.Sqrt(delta)) / (2 * heSoPtBac2.x);
            nghiem.x2 = (-heSoPtBac2.y - Mathf.Sqrt(delta)) / (2 * heSoPtBac2.x);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bulletEnemy")
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "enemy")
        {
            hitLayer.GetComponent<Animator>().SetTrigger("ShowOneHit");
        }

    }

}
