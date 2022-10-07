using System;

/*
 * AlumnoDTO --> Clase que nos permite manipular los datos de la tabla Alumnos como objetos de C#
 */


public class AlumnoDTO
{
    //Creamos los campos que vamos a necesitar para extraer los datos
    public int id_alumno { get; private set; }
    //Al añadir al tipo el símbolo ? se admite null en el campo al salir del constructor.
    public string? nombre { get; private set; }
    public string? apellidos { get; private set; }
    public string? email { get; private set; }

    //Constructor AlumnoDTO completo
    public AlumnoDTO(int Id, string Nombre, string Apellidos, string Email)
    {
        id_alumno = Id;
        nombre = Nombre;
        apellidos = Apellidos;
        email = Email;
    }

    public override string ToString()
    {
        return String.Format("[ALUMNO] \t{0}\t{1}\t{2}\t{3}", id_alumno, nombre, apellidos, email);
    }
}
