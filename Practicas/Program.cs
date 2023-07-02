// See https://aka.ms/new-console-template for more information

string usuario = "Dioris";
string resultado, alumno = "";
string encabezado = "/************************************************************************/\r\n/* PROGRAMA PARA CALIFICAR ALUMNOS DE ESCUELA BASICA */\r\n/************************************************************************/";
byte curso, promedio = 0;
byte[] notas = new byte[5];
string continuar = "";

do
{
    Console.WriteLine(encabezado);

    Console.WriteLine("Bienvenido, " + usuario);

    Console.WriteLine("\nIngrese el nombre del alumno: ");
    alumno = Console.ReadLine();

    Console.WriteLine("\nIngrese el curso del alumno: ");
    curso = Convert.ToByte((Console.ReadLine()));

    Console.WriteLine("\n/************************************************************************/");

    notas = Menu(curso);

    promedio = CalcularPromedio(notas);

    resultado = CalcularResultado(promedio);

    Console.Clear();

    Console.WriteLine(encabezado);

    Console.WriteLine("Estudiante: " + alumno + "\t\tCodigo de curso: " + curso);

    imprimirResultados(notas);

    Console.WriteLine("\nEl alumno ha sido: " + resultado + "\n");
    Console.WriteLine("Su promedio fue de " + promedio + " puntos\n");

    if (resultado == "RECUPERACION")
    {
        Console.WriteLine("\n/************************************************************************/\r\n/* RECUPERACION: INGRESE NUEVAS CALIFICACIONES */\r\n/************************************************************************/\n");
        notas = Menu(curso);
        promedio = CalcularPromedio(notas);

        if (promedio > 70)
        {
            Console.WriteLine();
            imprimirResultados(notas);
            Console.WriteLine("\nSu promedio fue de {0} puntos", promedio);
            resultado = "\nAPROBADO";

        }
        else
        {
            Console.WriteLine();
            imprimirResultados(notas);
            Console.WriteLine("\nSu promedio fue de {0} puntos", promedio);
            resultado = "\nREPROBADO";
        }
    }

    Console.WriteLine(resultado);
    Console.WriteLine("¿Desea continuar calificando? S/Si");
    continuar = Console.ReadLine().ToUpper();
    if (continuar == "S" || continuar == "Si")
        Console.Clear();
} while (continuar == "S" || continuar == "Si");



byte[] Menu(byte x)
{
    byte[] nota = new byte[5];

    if(x >= 1 && x <= 4)
    {
        nota = new byte[4];
        notas = new byte[4];
        Console.WriteLine("Calificación para la asignatura Lengua Española: ");
        nota[0] = LectorBytes();
        Console.WriteLine("Calificación para la asignatura Matematicas: ");
        nota[1] = LectorBytes();
        Console.WriteLine("Calificación para la asignatura Ciencias Sociales: ");
        nota[2] = LectorBytes();
        Console.WriteLine("Calificación para la asignatura Ciencias Naturales: ");
        nota[3] = LectorBytes();
    }
    if(x >= 5 &&  x <= 8) 
    {
        Console.WriteLine("Calificación para la asignatura Ingles: ");
        nota[0] = LectorBytes();
        Console.WriteLine("Calificación para la asignatura Moral y Civica: ");
        nota[1] = LectorBytes();
        Console.WriteLine("Calificación para la asignatura Educacion Fisica: ");
        nota[2] = LectorBytes();
        Console.WriteLine("Calificación para la asignatura Manualidades: ");
        nota[3] = LectorBytes();
        Console.WriteLine("Calificación para la asignatura Musica: ");
        nota[4] = LectorBytes();
    }
    return nota;
}

byte LectorBytes()
{
    return Convert.ToByte((Console.ReadLine()));
}

byte CalcularPromedio(byte[] promediando)
{
    int prom = 0;
    byte cantidad = Convert.ToByte(promediando.Length);
    for(byte i = 0; i < cantidad; i++)
    {
        prom += promediando[i];        
    }
    
    return (byte)(prom / cantidad);
}

string CalcularResultado(byte prom)
{
    if(prom >= 70)
    {
        return "APROBADO";
    }
    else if(prom >= 60)
    {
        return "RECUPERACION";
    }
    else if(prom < 60)
    {
        return "REPROBADO";
    }
    else
    {
        return "ERROR: PROMEDIO INVALIDO";
    }
}

void imprimirResultados(byte[] x)
{
    if (x.Length == 4)
    {
        Console.WriteLine("\nLengua Española: " + x[0]);
        Console.WriteLine("Matematicas: " + x[1]);
        Console.WriteLine("Ciencias Sociales: " + x[2]);
        Console.WriteLine("Ciencias Naturales: " + x[3]);
    }
    else
    {
        Console.WriteLine("Ingles: " + x[0]);
        Console.WriteLine("Moral y Civica: " + x[1]);
        Console.WriteLine("Educacion Fisica: " + x[2]);
        Console.WriteLine("Manualidades: " + x[3]);
        Console.WriteLine("Musica: " + x[4]);
    }
}