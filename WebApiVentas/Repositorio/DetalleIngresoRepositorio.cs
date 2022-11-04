using WebApiVentas.Modelos;

namespace WebApiVentas.Repositorio
{
    public class DetalleIngresoRepositorio
    {
        dbventasDbContext db = new dbventasDbContext();

        public List<DetalleIngreso> getAll()
        {
            List<DetalleIngreso> lst = db.DetalleIngreso.ToList();
            return lst;
        }
        public DetalleIngreso getById(int id)
        {
            DetalleIngreso registro = db.DetalleIngreso.Find(id);
            return registro;
        }
        public DetalleIngreso create(DetalleIngreso request)
        {
            db.DetalleIngreso.Add(request);
            db.SaveChanges();
            return request;
        }
        public DetalleIngreso update(DetalleIngreso request)
        {
            db.DetalleIngreso.Update(request);
            db.SaveChanges();
            return request;
        }

        public int delete(int id)
        {
            DetalleIngreso registro = db.DetalleIngreso.Find(id);
            db.DetalleIngreso.Remove(registro);
            return db.SaveChanges();
        }
    }
}
