using UnityEngine;

public class Semaforo : Simulator
{
    [SerializeField] Creadores creadores;
    public enum EstadoSemaforo { Verde, Amarillo, Rojo }
    
    public EstadoSemaforo estadoActual = EstadoSemaforo.Rojo;

    public int duracionVerde = 5;
    public int duracionAmarillo = 2;
    public int duracionRojo = 5;

    private float temporizador;

    public override void AsignarCreador(Creadores creador)
    {
        CreadoresSimulator = creador;
    }

    void Start()
    {
        CambiarEstado(EstadoSemaforo.Rojo); // Arranca en rojo
        AsignarCreador(creadores);
    }

    void Update()
    {
        temporizador -= Time.deltaTime;

        if (temporizador <= 0)
        {
            CambiarAlSiguienteEstado();
        }
    }

    void CambiarEstado(EstadoSemaforo nuevoEstado)
    {
        estadoActual = nuevoEstado;

        switch (estadoActual)
        {
            case EstadoSemaforo.Verde:
                temporizador = duracionVerde;
                Debug.Log("Semáforo en VERDE");
                break;
            case EstadoSemaforo.Amarillo:
                temporizador = duracionAmarillo;
                Debug.Log("Semáforo en AMARILLO");
                break;
            case EstadoSemaforo.Rojo:
                temporizador = duracionRojo;
                Debug.Log("Semáforo en ROJO");
                break;
        }
    }

    void CambiarAlSiguienteEstado()
    {
        switch (estadoActual)
        {
            case EstadoSemaforo.Verde:
                CambiarEstado(EstadoSemaforo.Amarillo);
                break;
            case EstadoSemaforo.Amarillo:
                CambiarEstado(EstadoSemaforo.Rojo);
                break;
            case EstadoSemaforo.Rojo:
                CambiarEstado(EstadoSemaforo.Verde);
                break;
        }
    }
}
