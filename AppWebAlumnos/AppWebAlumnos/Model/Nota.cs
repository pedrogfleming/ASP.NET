namespace AppWebAlumnos.Model
{
    public class Nota
    {
        public enum EEstado {abandonada,cursando,finalizada};
        private Alumno alumno;
        private Materia materia;
        private short nota1;
        private short nota2;
        private short nota3;
        private float promedio;
        private bool estado;

    }
}
