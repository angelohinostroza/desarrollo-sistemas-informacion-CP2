using Microsoft.EntityFrameworkCore;
using WebApiVentas.Modelos;

namespace WebApiVentas.Repositorio
{
    public class ProductoRepositorio
    {
        dbventasDbContext db = new dbventasDbContext();

        public List<Producto> getAll()
        {
            List<Producto> lst = db.Producto.ToList();
            return lst;
        }
        public List<Producto> getAllComplete()
        {
            List<Producto> lst =
                db.Producto
                .Include(x => x.CategoriaIdcategoriaNavigation)
                .ToList();
            return lst;
        }
        public Producto getById(int id)
        {
            Producto registro = db.Producto.Find(id);
            return registro;
        }
        public Producto create(Producto request)
        {
            db.Producto.Add(request);
            db.SaveChanges();
            return request;
        }
        public Producto update(Producto request)
        {
            db.Producto.Update(request);
            db.SaveChanges();
            return request;
        }

        public int delete(int id)
        {
            Producto registro = db.Producto.Find(id);
            db.Producto.Remove(registro);
            return db.SaveChanges();
        }
    }
}
