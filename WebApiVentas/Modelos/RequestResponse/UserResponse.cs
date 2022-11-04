namespace WebApiVentas.Modelos.RequestResponse
{
    public class UserResponse
    {
        public int id { get; set; }
        public int id_person { get; set; }
        public string username { get; set; }
        public bool change_password { get; set; }
        public short id_perfil { get; set; }
        public short id_status { get; set; }

    }
}
