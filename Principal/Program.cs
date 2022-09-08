using Datos;
using Datos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal
{
    internal class Program
    {
        //declarar objeto
        public static Class1 _class1 = null;
        static void Main(string[] args)
        {
            
            //objeto
            Program program = null;
            program = new Program();

            //inicializar
            _class1 = new Class1();

            //CRUD

            //llamar metodo
            program.Create(); 
            program.Read();
            program.Update();
            program.Delete();

        }

        //Metodo
        private void Create()
        {
            Categoria categoria = null;
            categoria = new Categoria();

            Console.WriteLine("Dime el nombre del nuevo registro");
            string texto = Console.ReadLine();
            if (texto != null)
            {
                categoria.CategoryName = texto;
            }

            Console.WriteLine("Dime la descripcion del nuevo registro");
            texto = Console.ReadLine();
            if (texto != null)
            {
                categoria.Description = texto;
            }


            //categoria.CategoryName = "Chisme";
            //categoria.Description = "Utensilio cuya utilidad no se ha demostrado de momento";

            bool ok = false;
            ok = _class1.Create(categoria);
            ok = _class1.GuardarCambios();

            Console.WriteLine("El resultado de create a sido: " + ok);

            Console.ReadLine();
        }


        private void Read()
        {
            IList<Categoria> categorias = null;

            Console.WriteLine("Dime el id del registro a mostrar");
            string texto = Console.ReadLine();
            if (texto == null || texto == "")
            {
                categorias = _class1.Read(null);
            }
            else
            {
                int id = 0;
                if (int.TryParse(texto, out id) == true)
                {
                    id = int.Parse(texto);
                }
                categorias = _class1.Read(id);
            }

            foreach (Categoria categoria in categorias)
            {
                Console.WriteLine(categoria.CategoryID + " " + categoria.CategoryName);
            }
            Console.ReadLine();
        }



        private void Update()
        {
            Console.WriteLine("Dime el ID del registro a modificar");
            string texto = Console.ReadLine();
            if (texto != null && texto != "")
            {
                int id = 0;
                if (int.TryParse(texto, out id) == true)
                {
                    id = int.Parse(texto);
                    Console.WriteLine("Dime el nuevo NOMBRE del registro");
                    texto = Console.ReadLine();
                }
                if (texto != null && texto != "")
                {
                    bool ok = false;
                    ok = _class1.Update(id, texto);
                    if (ok == true)
                    {
                        ok = _class1.GuardarCambios();
                    }
                    Console.WriteLine("El resultado de Update ha sido: " + ok);
                    Console.ReadLine();
                }
            }

        }


        private void Delete()
        {
            Console.WriteLine("Dime el ID o el nombre del registro a eliminar");
            string texto = Console.ReadLine();
            if (texto != null && texto != "")
            {
                int id = 0;
                if (int.TryParse(texto, out id) == true)
                {
                    id = int.Parse(texto);
                    
                }
                
                
                  
                    bool ok = false;
                    ok = _class1.Delete(id, texto);
                    if (ok == true)
                    {
                        ok = _class1.GuardarCambios();
                    }
                    Console.WriteLine("El resultado de Update ha sido: " + ok);
                    Console.ReadLine();
                  
                    
                
            }



        }









    }
}
