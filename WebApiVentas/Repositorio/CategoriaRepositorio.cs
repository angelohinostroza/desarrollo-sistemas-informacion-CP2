using Microsoft.EntityFrameworkCore;
using WebApiVentas.Modelos;

namespace WebApiVentas.Repositorio
{
    public class CategoriaRepositorio
    {
        dbventasDbContext db = new dbventasDbContext();

        public List<Categoria> getAll()
        {
            List<Categoria> lst = db.Categoria.ToList();
            return lst;
        }
        public List<Categoria> getAllComplete()
        {
            List<Categoria> lst = 
                db.Categoria
                .Include(x => x.Producto)
                .ToList();
            return lst;
        }
        public Categoria getById(int id)
        {
            Categoria registro = db.Categoria.Find(id);
            return registro;
        }
        public Categoria create(Categoria request)
        {
            db.Categoria.Add(request);
            db.SaveChanges();
            return request;
        }
        public Categoria update(Categoria request)
        {
            db.Categoria.Update(request);
            db.SaveChanges();
            return request;
        }

        public int delete(int id)
        {
            Categoria registro = db.Categoria.Find(id);
            db.Categoria.Remove(registro);
            return db.SaveChanges();
        }
    }
}

