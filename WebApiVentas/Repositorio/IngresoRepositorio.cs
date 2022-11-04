using WebApiVentas.Modelos;

namespace WebApiVentas.Repositorio
{
    public class IngresoRepositorio
    {
        dbventasDbContext db = new dbventasDbContext();

        public List<Ingreso> getAll()
        {
            List<Ingreso> lst = db.Ingreso.ToList();
            return lst;
        }
        public Ingreso getById(int id)
        {
            Ingreso registro = db.Ingreso.Find(id);
            return registro;
        }
        public Ingreso create(Ingreso request)
        {
            db.Ingreso.Add(request);
            db.SaveChanges();
            return request;
        }
        public Ingreso update(Ingreso request)
        {
            db.Ingreso.Update(request);
            db.SaveChanges();
            return request;
        }

        public int delete(int id)
        {
            Ingreso registro = db.Ingreso.Find(id);
            db.Ingreso.Remove(registro);
            return db.SaveChanges();
        }
    }
}
