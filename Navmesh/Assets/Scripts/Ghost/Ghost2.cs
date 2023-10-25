using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost2 : MonoBehaviour
{
    public Transform[] puntoRutas;

    public float speed;

    public int indice = 0;

    public int direcion = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(moverPersonaje());
    }

    // Update is called once per frame

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }

    IEnumerator moverPersonaje()
    {
        while (true)
        {
            Vector3 siguientePunto = puntoRutas[indice].position;

            while (transform.position != siguientePunto)
            {
                transform.position = Vector3.MoveTowards(transform.position, siguientePunto, speed * Time.deltaTime);
                //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(siguientePunto), 2f * Time.deltaTime);
                yield return null;
            }
            indice += direcion;

            if (indice >= puntoRutas.Length || indice < 0)
            {
                direcion *= -1;
                indice += direcion * 2;
            }

        }
    }
}
