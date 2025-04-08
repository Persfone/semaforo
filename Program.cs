using System;
public class Semaforo
{
    private enum Estado
    {
        Rojo,
        RojoAmarillo,
        Amarillo,
        Verde
    }

    private Estado estadoActual;
    private bool intermitente;
    private bool amarilloVisible;
    


    public Semaforo(string colorInicial)
    {
 
        switch (colorInicial)
        {
            case "rojo":
                estadoActual = Estado.Rojo;
                break;
            case "verde":
                estadoActual = Estado.Verde;
                break;
            default:
                estadoActual = Estado.Amarillo;
                break;
             
        }

        
        intermitente = false;
        amarilloVisible = true;
       
    }

    public void PasoDelTiempo(int segundos)
    {
        if (intermitente) return;

        while (segundos > 0)
        {
            switch (estadoActual)
            {
                case Estado.Rojo:
                    if (segundos >= 30)
                    {
                        estadoActual = Estado.RojoAmarillo;
                        segundos -= 30;
                    }
                    else
                    {
                        segundos = 0; 
                    }
                    break;

                case Estado.RojoAmarillo:
                    if (segundos >= 2)
                    {
                        estadoActual = Estado.Verde;
                        segundos -= 2;
                    }
                    else
                    {
                        segundos = 0;  
                    }
                    break;

                case Estado.Verde:
                    if (segundos >= 20)
                    {
                        estadoActual = Estado.Amarillo;
                        segundos -= 20;
                    }
                    else
                    {
                        segundos = 0;  
                    }
                    break;

                case Estado.Amarillo:
                    if (segundos >= 2)
                    {
                        estadoActual = Estado.Rojo;
                        segundos -= 2;
                    }
                    else
                    {
                        segundos = 0; 
                    }
                    break;
            }
        }
    }


    public string MostrarColor()
    {
        if (intermitente)
        {
            amarilloVisible = !amarilloVisible;
            return amarilloVisible ? "Apagado" : "Amarillo";
        }

        switch (estadoActual)
        {
            case Estado.Rojo:
                return "Rojo";
            case Estado.RojoAmarillo:
                return "Rojo-Amarillo";
            case Estado.Verde:
                return "Verde";
            case Estado.Amarillo:
                return "Amarillo";
            default:
                return "Desconocido";
        }
    }
    public void PonerEnIntermitente()
    {
        intermitente = true;
        amarilloVisible = true;
       
    }

    public void SacarDeIntermitente()
    {
        intermitente = false;
        amarilloVisible = false;
    }
}




public class Program
{
    public static void Main()
    {
        // Crear semáforo inicializado en Rojo
        Semaforo semaforo = new Semaforo("Amarillo");

        Console.WriteLine("Semáforo recién creado:");
        Console.WriteLine(semaforo.MostrarColor());

        // Simular paso del tiempo
        Console.WriteLine("\nSimulando 42 segundos:");
        semaforo.PasoDelTiempo(42);
        Console.WriteLine(semaforo.MostrarColor());

        // Probar modo intermitente
        Console.WriteLine("\nActivando modo intermitente:");
        semaforo.PonerEnIntermitente();

        // Simular 5 segundos en modo intermitente
        for (int i = 0; i < 5; i++)
        {
            semaforo.PasoDelTiempo(1);
            Console.WriteLine(semaforo.MostrarColor());
        }

        // Desactivar intermitente
        Console.WriteLine("\nDesactivando modo intermitente:");
        semaforo.SacarDeIntermitente();
        Console.WriteLine(semaforo.MostrarColor());
    }
}