// See https://aka.ms/new-console-template for more information

int z = 0;
List<string> nombres = new List<string>() { "Pedro el Escamoso", "Chimontrufia Perez", "Juan de los Palotes", "Pepe Pino"};
/*
foreach (string s in nombres)
{
    z++;
    Console.WriteLine("Nombre " + z + ": " + s);
}

// Utilizamos ADD para añadir elementos a la lista

nombres.Add("Esteban");

// Utilizamos Remove para quitar elementos de la lista
nombres.Remove("Juan");

// Utilizamos RemoveAt para quitar elementos en una posicion especifica
nombres.RemoveAt(0);

// Utilizamos Insert para añadir un elemento en una posicion especifica
nombres.Insert(2, "Lucas");

// Utilizamos AddRange para aladir mas de un elemento  a la vez
nombres.AddRange(new string[] { "Juana", "Teresa" });

// Contamos elementos de una lista
int contador = nombres.Count();

// Utilizamos Sort para ordenar los elementos de la A-Z
nombres.Sort();

// Utilizamos Sort para ordenar los elementos de la Z-A
nombres.Reverse();

Console.WriteLine("\n\n************************ Lista Actualizada *********************");

z = 0;
*/

//LinQ 
/*
//Estilo Consulta
var consultaNombre = from nombre in nombres
                     where nombre.Length <= 10 select nombre;

//Estilo Lambda
consultaNombre = nombres.Where(nombre => nombre.Length <= 10);


foreach (var s in consultaNombre)
{
    z++;
    Console.WriteLine("Nombre " + z + ": " + s);
}


List<int> numero = new List<int>() { 1, 2, 4, 8, 16, 32 };
var menorDeDiez = numero.Where(n => n >= 1 && n < 10);

Console.WriteLine("\nNumeros menores de Diez(10)");
foreach (var n in menorDeDiez)
{    
    Console.WriteLine(n);
}*/




List<Persona> gente = new List<Persona>()
{
    new Persona(){ nombre = "Juan", genero = "Masculino", edad = 35 },
    new Persona(){ nombre = "Maria", genero = "Femenino", edad = 20 },
    new Persona(){ nombre = "Teresa", genero = "Femenino", edad = 15 },
};

var mayorDeEdad = gente.Where(mayor => mayor.edad >= 18);

//Para consultar la lilsta ordenando por edad (Ascendente)
var ordenarEdad = gente.OrderBy(porEdad => porEdad.edad).ToList();

//Para consultar la lilsta ordenando por edad (Descendente)
ordenarEdad = gente.OrderByDescending(porEdad => porEdad.edad).ToList();


//Para consultar la lista utilizamos foreach
z = 0;
foreach (Persona g in ordenarEdad)
{
    z++;
    Console.WriteLine("\nPersona " + z
        + "\nNombre: " + g.nombre
        + "\nGenero: " + g.genero
        + "\nEdad: " + g.edad);
}

// Filtrar datos con Select
// ERROR var soloFeminas = gente.Select(mujer => mujer.genero.Equals("Femenino"));

var generos = gente.Select(sexo => sexo.genero);

//Paara que traiga los distintos generos sin repeticiones, utilizamos Distinct

generos = generos.Distinct();

z = 0;
foreach (string g in generos)
{
    z++;
    Console.WriteLine(g);
}


// Filtramos el nombre por genero

var soloFeminas = gente.Where(f => f.genero == "Femenino").Select(n => n.nombre).ToList();

Console.WriteLine("\nNombres de personas con genero femenino: ");
foreach(var s in soloFeminas)
{
    Console.WriteLine(s);
}


// Utilizamos agrupacion para clasificar segun el tipo deseado, para este caso nombre

Console.WriteLine("\nAgrupacion por nombre: ");
var agrupa = gente.GroupBy(g => g.nombre);
foreach(var a in agrupa)
{
    Console.WriteLine(a.Key);
}



class Persona
{
    public string? nombre = null;
    public string? genero = null;
    public int edad;
}