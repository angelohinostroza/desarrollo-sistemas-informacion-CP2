using WebApiVentas.Modelos;

namespace WebApiVentas.Repositorio
{
    public class ClienteRepositorio
    {
        dbventasDbContext db = new dbventasDbContext();

        public List<Cliente> getAll()
        {
            List<Cliente> lst = db.Cliente.ToList();
            return lst;
        }
        public Cliente getById(int id)
        {
            Cliente registro = db.Cliente.Find(id);
            return registro;
        }
        public Cliente create(Cliente request)
        {
            db.Cliente.Add(request);
            db.SaveChanges();
            return request;
        }
        public Cliente update(Cliente request)
        {
            db.Cliente.Update(request);
            db.SaveChanges();
            return request;
        }

        public int delete(int id)
        {
            Cliente registro = db.Cliente.Find(id);
            db.Cliente.Remove(registro);
            return db.SaveChanges();
        }
    }
}
