using Datos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{ 
    public class Class1
    {
        public static NorthWindTuneadoDbContext _dbContext = null;

        //constructor
        public Class1()
        {
            if (_dbContext == null)
            {
                _dbContext = new NorthWindTuneadoDbContext();
            }
        }

        //metodo
        public bool Create (Categoria categoria)
        {
            _dbContext.Categoria.Add(categoria);
            return true;
        }


        //metodo
        public bool GuardarCambios()
        {
            bool ok = false;

            try
            {
                int resultado = 0;
                resultado = _dbContext.SaveChanges();
                if (resultado > 0)
                {
                    ok = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return ok;
        }

        public IList<Categoria> Read(int? id)
        {
            
            IList<Categoria> categorias = null; 
            categorias = _dbContext.Categoria.ToList();

            if (id != null && id > 0)
            {
            categorias= categorias.Where(x=> x.CategoryID == id).ToList();
            }


            return categorias;

        }


        public bool Update (int id, string texto)
        {

            if (id != null && id > 0)
            {
                Categoria categoria = _dbContext.Categoria.Where(x => x.CategoryID == id).FirstOrDefault();
                categoria.CategoryName = texto;
                return true;
            }


            return false;

        }



        public bool Delete(int id, string texto)
        {

            if (id > 0)
            {
                Categoria categoria = _dbContext.Categoria.Where(x => x.CategoryID == id).FirstOrDefault();
                _dbContext.Categoria.Remove(categoria);
                return true;
            }
            else
            {
                IList<Categoria> categorias = null;
                categorias = _dbContext.Categoria.ToList();
                categorias = categorias.Where(x => x.CategoryName == texto).ToList();
                foreach (Categoria categoria in categorias)
                    {
                        _dbContext.Categoria.Remove(categoria);
                    }
                return true;
            }

            

        }


    }
}
