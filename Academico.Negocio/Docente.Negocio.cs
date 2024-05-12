using Academico.Datos;
using Academico.Entidad;
using Academico.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.Negocio
{
    public class Docente : IDocenteRepositorio
    {
		AcademicoContextoBD db = new AcademicoContextoBD();

        public void ActualizarD(Docente docente)
        {
			db.Entry(docente).State = EntityState.Modified;
			db.SaveChanges();
		}

        public void AgregarD(Docente docente)
        {
            db.Docente.Add(docente);
			db.SaveChanges();
		}

        public Docente BuscarD(int Id)
        {
			var busqueda = db.Docente.Find(Id);
			return busqueda;
		}

        public List<Docente> ListarDocente()
        {
			var query = from x in db.Docente
						orderby x.Id
						select x;
			return query.ToList();
			//return db.Estudiante.ToList();
		}

		public List<Docente> ListarDocenteXNombre(string Nombre)
        {
				var query = from x in db.Docente
							orderby x.Nombre.Contains(Nombre)
							select x;
				return query.ToList();
				//return db.Estudiante.ToList();
		}
	}	
}
