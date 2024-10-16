using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector2 direccion = Vector2.right;
    public float velocidad= 5;
    public Transform segmentoPrefab;
    List<Transform> tamaņoserpiente = new List<Transform>();

    private void Start()
    {
        tamaņoserpiente.Add(transform);
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

        for (int i = tamaņoserpiente.Count - 1; i > 0; i--)
        {
            tamaņoserpiente[i].position = tamaņoserpiente[i - 1].position;
        }


        transform.position = new Vector3(Mathf.Round(transform.position.x) + direccion.x * velocidad,
            Mathf.Round(transform.position.y ) + direccion.y * velocidad,
            0.0f * velocidad);

        
    }

    private void Reset()
    {
        transform.position = Vector3.zero;
        for (int i = 1; i < tamaņoserpiente.Count; i++)
        {
            Destroy(tamaņoserpiente[i].gameObject);
        }
        tamaņoserpiente.Clear();
        tamaņoserpiente.Add(transform);
    }
    void Crecer()
    {
        Transform segmentoNuevo = Instantiate(segmentoPrefab);
        segmentoNuevo.position = tamaņoserpiente[tamaņoserpiente.Count - 1].position;
        tamaņoserpiente.Add(segmentoNuevo);
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