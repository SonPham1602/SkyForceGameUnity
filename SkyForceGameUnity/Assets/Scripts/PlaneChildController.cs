﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneChildController : MonoBehaviour
{
    public GameObject target;
    public GameObject bullet;
    public int numberBullet = 1;
    private float speedShip = 20f;

    private int hp;

    private float radius;
    private float lastTimeFire = 0;

    public int HP { get => hp; set => hp = value; }

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
        numberBullet = 1;
        this.HP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time - lastTimeFire >= 0.2f)
        {
            lastTimeFire = Time.time;
            CreateBullet(bullet);
        }
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
}
