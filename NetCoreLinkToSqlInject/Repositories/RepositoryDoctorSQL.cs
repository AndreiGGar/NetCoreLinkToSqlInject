using NetCoreLinkToSqlInject.Models;
using System.Data;
using System.Data.SqlClient;

namespace NetCoreLinkToSqlInject.Repositories
{
    public class RepositoryDoctorSQL : IRepositoryDoctor
    {
        private DataTable tablaDoctores;
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryDoctorSQL()
        {
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;User ID=sa;Password=";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            string sql = "SELECT * FROM DOCTOR";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connectionString);
            this.tablaDoctores = new DataTable();
            adapter.Fill(this.tablaDoctores);
        }

        public List<Doctor> GetDoctores()
        {
            var consulta = from datos in this.tablaDoctores.AsEnumerable()
                           select datos;
            List<Doctor> doctores = new List<Doctor>();
            foreach (var row in consulta)
            {
                Doctor doctor = new Doctor
                {
                    HOSPITAL_COD = int.Parse(row.Field<string>("HOSPITAL_COD")),
                    DOCTOR_NO = int.Parse(row.Field<string>("DOCTOR_NO")),
                    APELLIDO = row.Field<string>("APELLIDO"),
                    ESPECIALIDAD = row.Field<string>("ESPECIALIDAD"),
                    SALARIO = row.Field<int>("SALARIO"),
                };
                doctores.Add(doctor);
            }
            return doctores;
        }

        public void DeleteDoctor(int id)
        {
            string sql = "DELETE FROM DOCTOR WHERE DOCTOR_NO=@ID";
            SqlParameter pamid = new SqlParameter("@ID", id);
            this.com.Parameters.Add(pamid);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

        private int GetMaximoIdDoctor()
        {
            var consulta = from datos in this.tablaDoctores.AsEnumerable()
                           select datos;
            if (consulta.Count() == 0)
            {
                return 1;
            }
            else
            {
                return consulta.Max(z => int.Parse(z.Field<string>("DOCTOR_NO"))) + 1;
            }
        }

        public void InsertDoctor(int hospitalcod, string apellido, string especialidad, int salario)
        {
            string sql = "INSERT INTO DOCTOR VALUES (@DOCTOR_NO, @HOSPITAL_COD, @APELLIDO, @ESPECIALIDAD, @SALARIO)";
            int maximo = GetMaximoIdDoctor();
            SqlParameter pamid = new SqlParameter("@DOCTOR_NO", maximo);
            SqlParameter pamhospital = new SqlParameter("@HOSPITAL_COD", hospitalcod);
            SqlParameter pamapellido = new SqlParameter("@APELLIDO", apellido);
            SqlParameter pamespecialidad = new SqlParameter("@ESPECIALIDAD", especialidad);
            SqlParameter pamsalario = new SqlParameter("@SALARIO", salario);
            this.com.Parameters.Add(pamid);
            this.com.Parameters.Add(pamhospital);
            this.com.Parameters.Add(pamapellido);
            this.com.Parameters.Add(pamespecialidad);
            this.com.Parameters.Add(pamsalario);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

    }
}
