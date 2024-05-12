using Academico.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.Negocio.Interfaces
{
    internal interface IDocenteRepositorio
    {
        void AgregarD(Docente docente);
        void ActualizarD(Docente docente);
        List<Docente> ListarDocente();
        Docente BuscarD(int Id);
        List<Docente> ListarDocenteXNombre(string Nombre);
    }
}
