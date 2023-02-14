using NetCoreLinkToSqlInject.Models;

namespace NetCoreLinkToSqlInject.Repositories
{
    public interface IRepositoryDoctor
    {
        List<Doctor> GetDoctores();
        void DeleteDoctor(int id);
        void InsertDoctor(int hospitalcod, string apellido, string especialidad, int salario);
    }
}
