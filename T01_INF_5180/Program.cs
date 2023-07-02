using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        /*Variables a utilizar: las usuario# corresponden a los nombres de usuario a ingresar, los tRecorrido guardaran el tiempo de inicio de sesion enformato String
         * mientras que los tElapsados contaran con el tiempo transcurrido hacinedo uso del String.Format*/
        string usuario1, usuario2, usuario3;
        string tRecorrido1, tRecorrido2, tRecorrido3, tElapsado1, tElapsado2, tElapsado3;

        //Se instancian los stop watches y los objetos de hilo
        Stopwatch sw1 = new Stopwatch();
        Thread hiloUsuario1 = new Thread(SesionUsuario1);

        Stopwatch sw2 = new Stopwatch();
        Thread hiloUsuario2 = new Thread(SesionUsuario2);

        Stopwatch sw3 = new Stopwatch();
        Thread hiloUsuario3 = new Thread(SesionUsuario3);


        //Se pide el nombre de la primera sesion
        Console.WriteLine("Ingrese el nombre del usuario 1: ");
        usuario1 = Console.ReadLine();
        sw1.Start();
        DateTime tiempoUsuario1 = DateTime.Now;

        /*Se comienzan el hilo correspondiente seguido del Join, para que una vez se llame la funcion conteniendo el Thread.Sleep, esta lo haga antes de la finalizacion
         * del hilo principal*/
        hiloUsuario1.Start();
        hiloUsuario1.Join();
        sw1.Stop();
        DateTime finalTiempoUsuario1 = DateTime.Now;

        //El TimeSpan nos guarda el tiempo transcurrido en el stopwatch desde que inicia hasta que se detiene con su funcion .Stop();
        TimeSpan ts1 = sw1.Elapsed;

        //Se le da el formato correspondiente al tiempo transcurrido y al tiempo de inicio de sesion
        tElapsado1 = String.Format("{0:0} minutos y {1:00} segundos", ts1.Minutes, ts1.Seconds);
        tRecorrido1 = tiempoUsuario1.ToString("h:mm:ss tt");

        //Inicia segunda sesion
        Console.WriteLine("Ingrese el nombre del usuario 2: ");
        usuario2 = Console.ReadLine();
        sw2.Start();
        DateTime tiempoUsuario2 = DateTime.Now;
        hiloUsuario2.Start();
        hiloUsuario2.Join();
        sw2.Stop();
        DateTime finalTiempoUsuario2 = DateTime.Now;
        TimeSpan ts2 = sw2.Elapsed;
        tElapsado2 = String.Format("{0:0} minutos y {1:00} segundos", ts2.Minutes, ts2.Seconds);
        tRecorrido2 = tiempoUsuario2.ToString("h:mm:ss tt");

        //Inicia Tercera sesion
        Console.WriteLine("Ingrese el nombre del usuario 3: ");
        usuario3 = Console.ReadLine();
        sw3.Start();
        DateTime tiempoUsuario3 = DateTime.Now;
        hiloUsuario3.Start();
        hiloUsuario3.Join();
        sw3.Stop();
        DateTime finalTiempoUsuario3 = DateTime.Now;
        TimeSpan ts3 = sw3.Elapsed;
        tElapsado3 = String.Format("{0:0} minutos y {1:00} segundos", ts3.Minutes, ts3.Seconds);
        tRecorrido3 = tiempoUsuario3.ToString("h:mm:ss tt");

        //Se imprime el tiempo de inicio y finalizacion de las sesiones
        Console.WriteLine("\nUsuario: " + usuario1 + "\t\tInicio sesion a las " + tRecorrido1 + "\t\tFinaliza sesion a las " + finalTiempoUsuario1.ToString("h:mm:ss tt"));
        Console.WriteLine("Usuario: " + usuario2 + "\t\tInicio sesion a las " + tRecorrido2 + "\t\tFinaliza sesion a las " + finalTiempoUsuario2.ToString("h:mm:ss tt"));
        Console.WriteLine("Usuario: " + usuario3 + "\t\tInicio sesion a las " + tRecorrido3 + "\t\tFinaliza sesion a las " + finalTiempoUsuario3.ToString("h:mm:ss tt"));

        //Se imprime el calculo del timepo transcurrido entre sesiones
        Console.WriteLine("\nLa sesion ha terminado.");
        Console.WriteLine("\nUsuario: " + usuario1 + "\t\tTiempo de sesion: " + tElapsado1);
        Console.WriteLine("Usuario: " + usuario2 + "\t\tTiempo de sesion: " + tElapsado2);
        Console.WriteLine("Usuario: " + usuario3 + "\t\tTiempo de sesion: " + tElapsado3);

    }

    //Metodos para determinar cuanto tiempo dura cada sesion dependiendo del usuario 
    static void SesionUsuario1()
    {

        Thread.Sleep(60000);

    }

    static void SesionUsuario2()
    {

        Thread.Sleep(90000);

    }

    static void SesionUsuario3()
    {

        Thread.Sleep(120000);

    }
}
