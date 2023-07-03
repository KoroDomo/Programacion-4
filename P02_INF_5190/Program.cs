// See https://aka.ms/new-console-template for more information
using P02_INF_5190;
using System.Collections;

//Declaracion de Variables
string nombre, apellidos, sexo, seguir;
byte edad;
double cedula;

do
{
    //Arraylisy donde se guardaran las personas
    ArrayList personas = new ArrayList();
    
    //Objetos de personas
    Persona persona1 = new Persona();
    Persona persona2 = new Persona();
    Persona persona3 = new Persona();


    Console.WriteLine("***********************INGRESE DATOS DE PERSONAS*******************\n");
    /* Utilizamos el metodo capturador() parar crear los objetos con los datos ingresados por teclados a traves de las propiedades (getters/setters)
     * Luego, los agregamos al ArrayList */
    personas.Add(capturador(persona1));
    personas.Add(capturador(persona2));
    personas.Add(capturador(persona3));

    // Bucle para recorrer cada persona denetro del arraylist e imprimir sus datos haciendo uso del toString()
    foreach (Persona persona in personas)
    {
        Console.WriteLine(persona.ToString());
    }

    //Confirmamos si deseamos agregar nuevas personas
    Console.WriteLine("\nDesea agregar 3 personas mas? (Si \\ No)");
    seguir = Console.ReadLine().ToLower();
} while (String.Equals(seguir, "si"));


// Metodo para capturar los datos de las personas. Acepta el objeto Persona instanciado y lo retorna con los datos capturados
Persona capturador(Persona persona)
{
    Console.Write("Ingrese Nombre: ");
    persona.Nombre = Console.ReadLine();

    Console.Write("Ingrese Apellidos: ");
    persona.Apellidos = Console.ReadLine();

    Console.Write("Ingrese Sexo (M\\F): ");
    persona.Sexo = Console.ReadLine().ToUpper();

    Console.Write("Ingrese Edad: ");
    persona.Edad = Convert.ToByte(Console.ReadLine());

    Console.Write("Ingrese Cedula: ");
    persona.Cedula = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine();

    return persona;
}
