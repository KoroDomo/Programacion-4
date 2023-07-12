// See https://aka.ms/new-console-template for more information
Console.WriteLine("********************* INGRESO DE ESTUDIANTES**************\n\n");

int opcion = 0;

// Declaracion de la lista que contendra a los objetos estudiantes
List<Estudiante> lista = new List<Estudiante>()
{
    //new Estudiante(100149677, "Dioris", "Arias", 30, 90),
    //new Estudiante(123456789, "Oflo", "Santos", 36, 100),
    //new Estudiante(999999999, "Melvin", "Quinones", 35, 95),
    //new Estudiante(484848489, "Fulano", "Detal", 25, 80),
    //new Estudiante(565656567, "Sutaneja", "Perez", 24, 88),
};


opcion = MostrarMenu();




foreach(Estudiante e in lista)
{
    Console.WriteLine(e.ToString());
}


int MostrarMenu()
{
    Escribir("1- Añadir Estudiante: ");
    Escribir("2- Editar Estudiante: ");
    Escribir("3- Eliminar Estudiante: ");
    Escribir("4- Buscar Estudiante: ");
    Escribir("5- Buscar Estudiante: ");
    Escribir("6- Desplegar Estudiantes con promedio > 70 y < 90: ");
    Escribir("7- Desplegar Estudiantes que tengan edades comprendidas entre 12 y 15 años.: ");
    Escribir("8- Desplegar Estudiantes por Promedio (Descendente): ");
    Escribir("9- Desplegar todos los Estudiantes: ");

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










public class Estudiante
{
    // Campos o Atributos
    private int matricula;
    private string nombre;
    private string apellidos;
    private int edad;
    private int promedio;

    //Constructor
    public Estudiante(int m, string n, string a, int e, int pm)
    {
        matricula = m;
        nombre = n;
        apellidos = a;
        edad = e;
        promedio = pm;
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
        return "Matricula: " + matricula + "\nNombre: " + nombre + "\nApellidos: " + apellidos
            + "\nEdad: " + edad + "\nPromedio: " + promedio + "\n";
    }
}