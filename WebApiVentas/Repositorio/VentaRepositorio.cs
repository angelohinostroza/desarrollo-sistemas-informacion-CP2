using WebApiVentas.Modelos;

namespace WebApiVentas.Repositorio
{
    public class VentaRepositorio
    {
        dbventasDbContext db = new dbventasDbContext();

        public List<Venta> getAll()
        {
            List<Venta> lst = db.Venta.ToList();
            return lst;
        }
        public Venta getById(int id)
        {
            Venta registro = db.Venta.Find(id);
            return registro;
        }
        public Venta create(Venta request)
        {
            db.Venta.Add(request);
            db.SaveChanges();
            return request;
        }
        public Venta update(Venta request)
        {
            db.Venta.Update(request);
            db.SaveChanges();
            return request;
        }

        public int delete(int id)
        {
            Venta registro = db.Venta.Find(id);
            db.Venta.Remove(registro);
            return db.SaveChanges();
        }
    }
}
