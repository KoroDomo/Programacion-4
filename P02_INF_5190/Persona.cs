using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_INF_5190
{
    internal class Persona
    {
        /* Campos o Atributos.  Tienen modificador de acceso private debdio a encapsulamiento de datos. Accedemos
         * a estos a traves de las propiedades (getters y setters) */
        private string nombre;
        private string apellidos;
        private string sexo;
        private byte edad;
        private double cedula;

        // Metodo Constructor, inicializamos los atributos creados
        public Persona()
        {
            nombre = "";
            apellidos = "";
            sexo = "";
            edad = 0;
            cedula = 0;
        }

        //Getters y Setters
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public string Sexo
        {
            get { return sexo; }
            //utilizamos el metodo Setter para validar el sexo ingresado, si es incorrecto le asigna el valor "Indefinido" 
            set {
                if (String.Equals(value, "M") || String.Equals(value, "F"))
                    sexo = value;
                else
                {
                    Console.WriteLine("El sexo es incorrecto");
                    sexo = "Indefinido";
                }                                     
            }
        }

        public byte Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public double Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }

        // Overload del metodo ToString para imprimir contenido de los objetos personas
        public override string ToString()
        {
            //esSexoCorrecto();
            return "Nombre: " + Nombre + " | Apellidos: " + Apellidos + " | Sexo: " + Sexo + " | Edad: " + Edad + " | Es Mayor de edad?: " + esMayor() + " | Cedula: " + Cedula;
        }

        // Metodo para identificar si la persona es mayor de edad
        public bool esMayor() => Edad >= 18 ? true : false;

        //public void esSexoCorrecto()
        //{
        //    if String.Equals("M")
        //        Console.WriteLine("El sexo ingresado \"{0}\" es incorrecto.", Sexo);
        //}
    }
}
