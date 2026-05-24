using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clase3Mov : MonoBehaviour
{
    //DIRECCION
    private int movimientoHorizontal = 0;
    private int movimientoVertical = 0;
    //No es necesario definir mov como variable global, ya que solo se utiliza dentro del FixedUpdate, por lo que se puede definir como una variable local dentro de ese método. De esta manera, se evita la posibilidad de que otras partes del código modifiquen accidentalmente el valor de mov, lo que podría causar errores en el movimiento del personaje.
    //private Vector2 mov = new Vector2(0, 0);

    //VELOCIDAD Y SRPINT O CARRERA - defino tres variables para la velocidad normal, la velocidad de sprint y la velocidad actual, que se inicializa con la velocidad normal. Luego, en el método Update, se verifica si el jugador está presionando la tecla de sprint (por ejemplo, Shift) y se actualiza la velocidad actual en consecuencia. Finalmente, en el método FixedUpdate, se utiliza la velocidad actual para calcular la fuerza que se aplica al Rigidbody2D del personaje.
    //[SerializeField] private float speed = 10;
    [SerializeField] private float velocidadNormal = 5f;
    [SerializeField] private float velocidadSprint = 10f;
    private float velocidadActual;

    private Rigidbody2D rb;
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();//quiero acceder a las propiedades del RigidBody de mi objeto, para eso lo asigno a una variable
      velocidadActual = velocidadNormal; //inicializo la velocidad actual con la velocidad normal
                                         
    }

    // Update is called once per frame
    void Update()
    {
       //MOVIMIENTO VERTICAL
        if (Input.GetKey(KeyCode.W)) 
        { movimientoVertical = 1; }
        else if (Input.GetKey(KeyCode.S)) 
        { movimientoVertical = (-1); }
        else
        { movimientoVertical = 0; } //puesto en el else
        //MOVIMIENTO HORIZONTAL
        if (Input.GetKey(KeyCode.D)) 
        { movimientoHorizontal = 1; }
        else if (Input.GetKey(KeyCode.A))
        { movimientoHorizontal = (-1); }
        else { movimientoHorizontal = 0; }//puesto en el else

        //SPRINT
        if (Input.GetKey(KeyCode.LeftShift)) 
        { velocidadActual = velocidadSprint; }
        else
        { velocidadActual = velocidadNormal; }  
    }
    void FixedUpdate()
    {
        Vector2 mov = new Vector2(movimientoHorizontal, movimientoVertical);

        mov = mov.normalized;

        //rb.AddForce(mov * speed   * Time.fixedDeltaTime);
        //rb.AddForce(mov * velocidadActual * Time.fixedDeltaTime);
        rb.velocity = mov * velocidadActual; //asigno directamente la velocidad al Rigidbody2D, en lugar de aplicar una fuerza. Esto se hace para que el personaje se mueva de manera más precisa y controlada, ya que al aplicar una fuerza, el movimiento puede ser afectado por la masa del objeto y otras fuerzas externas.

    }
}
