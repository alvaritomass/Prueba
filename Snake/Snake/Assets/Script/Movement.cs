using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector2 direccion = Vector2.right;
    public float velocidad= 5;
    public Transform segmentoPrefab;
    List<Transform> tama�oserpiente = new List<Transform>();

    private void Start()
    {
        tama�oserpiente.Add(transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direccion = Vector2.up ;
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            direccion = Vector2.down ;
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            direccion = Vector2.right ;
        }

        else if(Input.GetKeyDown(KeyCode.A))
        {
            direccion = Vector2.left;
        }

        
    }

    private void FixedUpdate()
    {

        for (int i = tama�oserpiente.Count - 1; i > 0; i--)
        {
            tama�oserpiente[i].position = tama�oserpiente[i - 1].position;
        }


        transform.position = new Vector3(Mathf.Round(transform.position.x) + direccion.x * velocidad,
            Mathf.Round(transform.position.y ) + direccion.y * velocidad,
            0.0f * velocidad);

        
    }

    private void Reset()
    {
        transform.position = Vector3.zero;
        for (int i = 1; i < tama�oserpiente.Count; i++)
        {
            Destroy(tama�oserpiente[i].gameObject);
        }
        tama�oserpiente.Clear();
        tama�oserpiente.Add(transform);
    }
    void Crecer()
    {
        Transform segmentoNuevo = Instantiate(segmentoPrefab);
        segmentoNuevo.position = tama�oserpiente[tama�oserpiente.Count - 1].position;
        tama�oserpiente.Add(segmentoNuevo);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Pared"))
        {
            Reset();

        }
        if(collision.CompareTag("Comida"))
        {
            Crecer();
        }
        
    }
    
    
}