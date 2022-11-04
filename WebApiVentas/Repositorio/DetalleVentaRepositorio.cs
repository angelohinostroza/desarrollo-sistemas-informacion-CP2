using WebApiVentas.Modelos;

namespace WebApiVentas.Repositorio
{
    public class DetalleVentaRepositorio
    {
        dbventasDbContext db = new dbventasDbContext();

        public List<DetalleVenta> getAll()
        {
            List<DetalleVenta> lst = db.DetalleVenta.ToList();
            return lst;
        }
        public DetalleVenta getById(int id)
        {
            DetalleVenta registro = db.DetalleVenta.Find(id);
            return registro;
        }
        public DetalleVenta create(DetalleVenta request)
        {
            db.DetalleVenta.Add(request);
            db.SaveChanges();
            return request;
        }
        public DetalleVenta update(DetalleVenta request)
        {
            db.DetalleVenta.Update(request);
            db.SaveChanges();
            return request;
        }

        public int delete(int id)
        {
            DetalleVenta registro = db.DetalleVenta.Find(id);
            db.DetalleVenta.Remove(registro);
            return db.SaveChanges();
        }
    }
}
