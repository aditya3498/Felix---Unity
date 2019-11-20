using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck8 : MonoBehaviour
{
    Transform trans;
    Vector3 pos;
    Vector3 pos_new;
    Vector3 rot;
    public float speed = 1.0f;
    public Color newColor = new Color(1.0F, 0.0F, 0.0F, 1.0F);
    public bool destructible = true;
    public Tree_Damage treeScript;


    void Start()
    {
        trans = GetComponent<Transform>();

        pos = trans.position;
        rot = trans.rotation.eulerAngles;
        pos_new = new Vector3(pos.x + 9 * Mathf.Sin(Mathf.Deg2Rad * rot.y), pos.y, pos.z + 9 * Mathf.Cos(Mathf.Deg2Rad * rot.y));
        GameObject theTree = GameObject.Find("Tree8");

        treeScript = theTree.GetComponent<Tree_Damage>();


    }

    void Update()
    {

        //trans.position = new Vector3(pos.x - Mathf.PingPong(Time.time * 10.0f, 10.0f * Mathf.Cos(rot.y)), pos.y, pos.z - Mathf.PingPong(Time.time * 10.0f, 10.0f * Mathf.Cos(rot.y)));
        if (treeScript.count < 5 && destructible)
        {
            transform.position = Vector3.Lerp(pos, pos_new, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
        }

        else if (treeScript.count >= 5)
        {
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.material.color = newColor;
            transform.position = pos_new;
            destructible = false;
        }

    }
}
