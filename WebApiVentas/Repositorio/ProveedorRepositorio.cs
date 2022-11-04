using WebApiVentas.Modelos;

namespace WebApiVentas.Repositorio
{
    public class ProveedorRepositorio
    {
        dbventasDbContext db = new dbventasDbContext();

        public List<Proveedor> getAll()
        {
            List<Proveedor> lst = db.Proveedor.ToList();
            return lst;
        }
        public Proveedor getById(int id)
        {
            Proveedor registro = db.Proveedor.Find(id);
            return registro;
        }
        public Proveedor create(Proveedor request)
        {
            db.Proveedor.Add(request);
            db.SaveChanges();
            return request;
        }
        public Proveedor update(Proveedor request)
        {
            db.Proveedor.Update(request);
            db.SaveChanges();
            return request;
        }

        public int delete(int id)
        {
            Proveedor registro = db.Proveedor.Find(id);
            db.Proveedor.Remove(registro);
            return db.SaveChanges();
        }
    }
}
