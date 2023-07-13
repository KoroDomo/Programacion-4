// See https://aka.ms/new-console-template for more information
Console.WriteLine("********************* INGRESO DE ESTUDIANTES**************\n\n");

int opcion, matricula, edad, promedio;
string nombre, apellidos;

// Declaracion de la lista que contendra a los objetos estudiantes
List<Estudiante> lista = new List<Estudiante>()
{
    new Estudiante(100149677, "Dioris",  "Arias", 30, 90),
    new Estudiante(123456789, "Oflo", "Santos", 36, 100),
    new Estudiante(999999999, "Melvin", "Quinones", 35, 95),
    new Estudiante(484848489, "Fulano", "Detal", 25, 80),
    new Estudiante(565656567, "Sutaneja", "Perez", 14, 88),
};
//List<Estudiante> lista = new List<Estudiante>
//{
//    new Estudiante(){Matricula = 100149677, Nombre ="Dioris", Apellidos = "Arias", Edad = 30, Promedio = 90},
//    new Estudiante(){Matricula = 123456789, Nombre ="Oflo", Apellidos = "Santos", Edad = 36, Promedio =  100 },
//    new Estudiante(){Matricula = 999999999, Nombre ="Melvin", Apellidos =  "Quinones", Edad =  35, Promedio =  95 },
//    new Estudiante(){Matricula = 484848489, Nombre = "Fulano", Apellidos =  "Detal", Edad =  25, Promedio =  80 },
//    new Estudiante(){Matricula = 565656567, Nombre = "Sutaneja", Apellidos =  "Perez", Edad =  24, Promedio =  88 },
//};

do
{
    opcion = MostrarMenu();
    switch (opcion)
    {
        case 1:
            Agregar();
            break;
        case 2:
            Editar(lista);
            break;
        case 3:
            Eliminar(lista);
            break;
        case 4:
            Buscar(lista);
            break;
        case 5:
            BuscarMatricula(lista);
            break;
        case 6:
            DesplegarSetentaNoventa(lista);
            break;
        case 7:
            DesplegarDoceQuince(lista);
            break;
        case 8:
            DesplegarDescendente(lista);
            break;
        case 9:
            DesplegarEstudiantes(lista);
            break;
    }

    
}while(opcion != 0);


// 1- Agregar Estudiante
void Agregar()
{
    Escribir("\n");
    Escribir("Ingrese Matricula: ");
    matricula = LeerEntero();
    Escribir("Ingrese Nombre: ");
    nombre = Leer();
    Escribir("Ingrese Apellidos: ");
    apellidos = Leer();
    Escribir("Ingrese Edad: ");
    edad = LeerEntero();
    Escribir("Ingrese Promedio: ");
    promedio = LeerEntero();

    lista.Add(new Estudiante(matricula, nombre, apellidos, edad, promedio));

    Escribir("\nEstudiante agregado. Presione cualquier tecla para regresar...");
    Leer();
    Console.Clear();
}

// 2- Editar Estudiante (Edad o Promedio)

void Editar(List<Estudiante> alumno)
{
    int x, z, i = 0;
    //Mostrando Nombre de Estudiantes guardados usando LinQ
    alumno.ForEach(alu => Console.WriteLine(++i + ": " + alu.Nombre));

    Escribir("\nIngrese el numero del Estudiante a editar: ");
    z = LeerEntero();

    Escribir("\nQue desea editar? 1. Edad / 2. Promedio: ");
    x = LeerEntero();

    if (x == 1)
    {
        Escribir("\nEdad Actual: " + alumno[z - 1].Edad + ". Ingrese nueva Edad: ");
        alumno[z - 1].Edad = LeerEntero();
    }
    else if (x == 2)
    {
        Escribir("\nIngrese nuevo Promedio: ");
        alumno[z - 1].Promedio = LeerEntero();
    }
    else
        Escribir("\n*******ERROR: La Opcion ingresada es incorrecta.");

    Escribir("\nEstudiante editado. Presione cualquier tecla para regresar...");
    Leer();
    Console.Clear();

}

// 3- Eliminar Estudiante

void Eliminar(List<Estudiante> alumno) {
    int z, i = 0;
    //Mostrando Nombre de Estudiantes guardados usando LinQ y metodo ToString para desplegar todos los datos
    
    alumno.ForEach(alu => Console.WriteLine(++i + ": " + alu.ToString()));

    Escribir("\nIngrese la Matricula del Estudiante a eliminar: ");
    z = LeerEntero();
    //Eliminando Estudiantes cuya matricula sea igual a la ingresada usando LinQ
    alumno.RemoveAll(mat => mat.Matricula == z);

    Escribir("\nEstudiante eliminado. Presione cualquier tecla para regresar...");
    Leer();
    Console.Clear();
}

// 4- Buscar Estudiante (Por Nombre)
void Buscar(List<Estudiante> alumno)
{
    string nombre;
 
    Escribir("\nIngrese el Nombre del Estudiante a Buscar: ");
    nombre = Leer();
    // Buscando nombre dentro de lista Alumno usando LinQ. Si existe, retorna booleano
    bool existe = alumno.Any(nom => nom.Nombre ==  nombre);

    if (existe)
    {
        // Se instancia una variable con el nombre encontrado y se imprimen sus datos
        Estudiante encontrado = alumno.Find(e => e.Nombre == nombre);
        Escribir("ESTUDIANTE ENCONTRADO: ");
        Escribir(encontrado.ToString());
    }
    else
        Escribir("ESTUDIANTE NO ENCONTRADO...");

    Escribir("\nPresione cualquier tecla para regresar...");
    Leer();
    Console.Clear();
}

// 5- Buscar Estudiante (Por Matricula)
void BuscarMatricula(List<Estudiante> alumno)
{
    int z;

    Escribir("\nIngrese la Matricula del Estudiante a Buscar: ");
    z = LeerEntero();
    // Buscando matricula dentro de lista Alumno usando LinQ. Si existe, retorna booleano
    bool existe = alumno.Any(mat => mat.Matricula == z);

    if (existe)
    {
        // Se instancia una variable con el nombre encontrado y se imprimen sus datos
        Estudiante encontrado = alumno.Find(m => m.Matricula == z);
        Escribir("ESTUDIANTE ENCONTRADO: ");
        Escribir(encontrado.ToString());
    }
    else
        Escribir("ESTUDIANTE NO ENCONTRADO...");

    Escribir("\nPresione cualquier tecla para regresar...");
    Leer();
    Console.Clear();
}

// 6- Desplegar estudinates con promedio > 70 y < a 90

void DesplegarSetentaNoventa(List<Estudiante> alumno)
{
    int z = 0;
    // Utilizamons Where para retornar lista con estudiantes dentro del promedio buscado
    var setentaNoventa = alumno.Where(entre => entre.Promedio > 70 && entre.Promedio < 90);

    Escribir("Estos son los alumnos con promedio Mayor a 70 y Menor a 90: ");

    foreach(var e in setentaNoventa)
    {
        z++;
        Console.WriteLine(z + ": " + e.ToString() + "\n");  
    }

    Escribir("\nPresione cualquier tecla para regresar...");
    Leer();
    Console.Clear();
}

// 7- Desplegar estudinates con edades entre 12 y 15

void DesplegarDoceQuince(List<Estudiante> alumno)
{
    int z = 0;
    // Utilizamons Where para retornar lista con estudiantes dentro del rango de edad buscado
    var doceQuince = alumno.Where(entre => entre.Edad > 12 && entre.Edad < 15);

    Escribir("Estos son los alumnos con edades entre 12 y 15 años: ");

    foreach (var e in doceQuince)
    {
        z++;
        Console.WriteLine(z + ": " + e.ToString() + "\n");
    }

    Escribir("\nPresione cualquier tecla para regresar...");
    Leer();
    Console.Clear();
}

// 8- Desplegar estudinates por Promedio Descendiente

void DesplegarDescendente(List<Estudiante> alumno)
{
    int z = 0;
    var descendente = alumno.OrderByDescending(e => e.Promedio).ToList();

    Escribir("Estos son los alumnos ordenados por Promedios (Descendente): ");

    foreach (var e in descendente)
    {
        z++;
        Console.WriteLine(z + ": " + e.ToString() + "\n");
    }

    Escribir("\nPresione cualquier tecla para regresar...");
    Leer();
    Console.Clear();
}

// 9- Desplegar Todos los Estudiantes

void DesplegarEstudiantes(List<Estudiante> alumno)
{
    int i = 0;
    alumno.ForEach(alu => Console.WriteLine(++i + ": " + alu.ToString()));

    Escribir("\nPresione cualquier tecla para regresar...");
    Leer();
    Console.Clear();
}

int MostrarMenu()
{
    Escribir("1- Añadir Estudiante");
    Escribir("2- Editar Estudiante");
    Escribir("3- Eliminar Estudiante");
    Escribir("4- Buscar Estudiante (Por Nombre)");
    Escribir("5- Buscar Estudiante (Por Matricula)");
    Escribir("6- Desplegar Estudiantes con promedio > 70 y < 90");
    Escribir("7- Desplegar Estudiantes que tengan edades comprendidas entre 12 y 15 años");
    Escribir("8- Desplegar Estudiantes por Promedio (Descendente)");
    Escribir("9- Desplegar todos los Estudiantes");
    Escribir("0- Salir");

    Escribir("\n\nQue opcion desea realizar? (Digite el numero)");

    return Convert.ToInt32(Leer());
}



//Metodo para reemplazar Console.WriteLine
void Escribir(string mensaje)
{
    Console.WriteLine(mensaje);
}
// Metodo para reemplazar Console.ReadLine
string Leer()
{
    return Console.ReadLine();
}

int LeerEntero()
{
    return Convert.ToInt32(Console.ReadLine());
}










public class Estudiante
{
    // Campos o Atributos
    /*private int matricula;
    private string nombre;
    private string apellidos;
    private int edad;
    private int promedio;*/

    //Constructor
    
    public Estudiante(int m, string n, string a, int e, int pm)
    {
        Matricula = m;
        Nombre = n;
        Apellidos = a;
        Edad = e;
        Promedio = pm;
    }

    // Getters y Setters
    public int Matricula 
    {
        get;

        // El setter impone la nomeclatura de que la matricula a digitar deba ser de 9 digitos para poder ser guardada
        set;
        
            //while(value < 100000000 && value > 999999999)
            //{
            //    Console.Write("La matricula debe tener 9 digitos: ");
            //    value = Convert.ToInt32(Console.ReadLine());
            //}
            
        
    }
    public string Nombre { get; set; }

    public string Apellidos { get; set; }

    public int Edad { get; set; }

    public int Promedio { get; set;}

    // Metodo para mostrar menu
    public override string ToString()
    {
        return "Matricula: " + Matricula + "\nNombre: " + Nombre + "\nApellidos: " + Apellidos
            + "\nEdad: " + Edad + "\nPromedio: " + Promedio + "\n";
    }
}