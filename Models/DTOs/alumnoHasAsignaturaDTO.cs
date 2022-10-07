namespace proyectoConexionPostgreSQL.Models.DTOs
{
    /*
     * alumnoHasAsignaturaDTO --> Clase que nos permite manipular los datos de la tabla alumnoHasAsignaturasDTO como objetos de C#
     */

    public class alumnoHasAsignaturaDTO
    {

        public int idAha { get; private set; }
        public int idAlumno { get; private set; }
        public int idAsignatura { get; private set; }

        public alumnoHasAsignaturaDTO(int idAha, int idAlumno, int idAsignatura)
        {
            this.idAha = idAha;
            this.idAlumno = idAlumno;
            this.idAsignatura = idAsignatura;
        }

        public override string ToString()
        {
            return String.Format("[AHA] \t{1}\t{2}\t{3}", idAha, idAlumno, idAsignatura);
        }
    }
}
