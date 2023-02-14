using NetCoreLinkToSqlInject.Models;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace NetCoreLinkToSqlInject.Repositories
{
    public class RepositoryDoctorOracle : IRepositoryDoctor
    {
        private OracleConnection cn;
        private OracleCommand com;
        private OracleDataAdapter adapter;
        private DataTable tablaDoctores;

        public RepositoryDoctorOracle()
        {
            string connectionString = @"Data Source=LOCALHOST:1521/XE;Persist Security Info=True;User ID=SYSTEM;Password=oracle";
            this.cn = new OracleConnection(connectionString);
            this.com = new OracleCommand();
            this.com.Connection = this.cn;
            string oracle = "SELECT * FROM DOCTOR";
            this.adapter = new OracleDataAdapter(oracle, connectionString);
            this.tablaDoctores = new DataTable();
            adapter.Fill(this.tablaDoctores);
        }

        public List<Doctor> GetDoctores()
        {
            var consulta = from datos in this.tablaDoctores.AsEnumerable()
                           select new Doctor
                           {
                               HOSPITAL_COD = int.Parse(datos.Field<Int32>("HOSPITAL_COD").ToString()),
                               DOCTOR_NO = int.Parse(datos.Field<Int32>("DOCTOR_NO").ToString()),
                               APELLIDO = datos.Field<string>("APELLIDO"),
                               ESPECIALIDAD = datos.Field<string>("ESPECIALIDAD"),
                               SALARIO = int.Parse(datos.Field<Int32>("SALARIO").ToString()),
                           };
            return consulta.ToList();
        }

        private int GetMaximoIdDoctor()
        {
            var maximo = (from datos in this.tablaDoctores.AsEnumerable()
                           select datos).Max(z => z.Field<Int32>("DOCTOR_NO")) + 1;
            return maximo;
        }

        public void DeleteDoctor(int id)
        {

        }

        public void InsertDoctor(int hospitalcod, string apellido, string especialidad, int salario)
        {
            string sql = "INSERT INTO DOCTOR VALUES (:DOCTOR_NO, :HOSPITAL_COD, :APELLIDO, :ESPECIALIDAD, :SALARIO)";
            int maximo = GetMaximoIdDoctor();
            OracleParameter pamid = new OracleParameter(":DOCTOR_NO", Convert.ToInt32(maximo));
            OracleParameter pamhospital = new OracleParameter(":HOSPITAL_COD", Convert.ToInt32(hospitalcod));
            OracleParameter pamapellido = new OracleParameter(":APELLIDO", apellido);
            OracleParameter pamespecialidad = new OracleParameter(":ESPECIALIDAD", especialidad);
            OracleParameter pamsalario = new OracleParameter(":SALARIO", Convert.ToInt32(salario));
            this.com.Parameters.Add(pamid);
            this.com.Parameters.Add(pamhospital);
            this.com.Parameters.Add(pamapellido);
            this.com.Parameters.Add(pamespecialidad);
            this.com.Parameters.Add(pamsalario);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.com.ExecuteReader();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

    }
}
