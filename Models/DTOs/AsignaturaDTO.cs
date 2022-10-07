﻿namespace proyectoConexionPostgreSQL.Models.DTOs
{
    public class AsignaturaDTO
    {

        public int IdAsignatura { get; private set; }
        public string Nombre { get; private set; }
        public string idProfesor { get; private set; }

        public AsignaturaDTO(int idAsignatura, string nombre, string idProfesor)
        {
            IdAsignatura = idAsignatura;
            Nombre = nombre;
            idProfesor = idProfesor;               
                
        }

        public override string ToString()
        {
            return String.Format("[ASIGNATURA]\t{1}\t{2}\t{3}", IdAsignatura, Nombre, idProfesor);
        }

    }
}
