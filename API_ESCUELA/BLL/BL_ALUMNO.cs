using API_ESCUELA.DAL;
using API_ESCUELA.MODELS.DTO;
using System.Data;
using System.Net.NetworkInformation;

namespace API_ESCUELA.BLL;

public class BL_ALUMNO
{

    public static async Task<IEnumerable<DtoConsulAlumnos>> ListarAlumno(string PCadena)
    {

        IEnumerable<DtoConsulAlumnos> enuAlumnos = [];
        string SQLScript = "SELECT Matricula, Nombre, APaterno, AMaterno, CONCAT_WS(' ',Nombre, APaterno, AMaterno) AS Alumno, IIF(IsActivo=1,'Activo', 'InActivo') AS Estatus,\r\n\t\tFORMAT(FecNaci,'dd/MM/yyyy') AS FecNaci, CONVERT(VARCHAR(10), FecNaci) AS FecNaciF, IsActivo AS IdEstatus FROM ALUMNO";

        var ddParametros = new { };

        DataTable Dt = await Contexto.Funcion_ScriptDB(PCadena, SQLScript, ddParametros);

        if (Dt.Rows.Count > 0)
        {
            enuAlumnos = Dt.AsEnumerable().Select(item => new DtoConsulAlumnos()
            {
                Matricula = item.Field<int>("Matricula"),
                Alumno = item.Field<string>("Alumno"),
                Estatus = item.Field<string>("Estatus"),
                FecNaci = item.Field<string>("FecNaci"),
                FecNaciF = item.Field<string>("FecNaciF"),
                Nombre = item.Field<string>("Nombre"),
                APaterno = item.Field<string>("APaterno"),
                AMaterno = item.Field<string>("AMaterno"),
                IdEstatus = item.Field<Boolean>("IdEstatus"),

            });
        }

        return await Task.FromResult(enuAlumnos);
    }

    public static async Task<IEnumerable<string>> ValidarDatosAlta(DtoAltaAlumno PAlumno)
    {
        List<string> lstValidacion = [];

        if (PAlumno.Nombre.Length <= 2)
            lstValidacion.Add("Debe escibir un nombre valido");

        if (PAlumno.APaterno.Length <= 3)
            lstValidacion.Add("Debe escibir un apellido paterno valido");

        if (PAlumno.AMaterno.Length <= 3)
            lstValidacion.Add("Debe escibir un apellido materno valido");

        if (PAlumno.FecNaci.Length <= 3)
            lstValidacion.Add("Debe seleccionar una fecha de nacimiento");


        return await Task.FromResult(lstValidacion.AsEnumerable());
    }

    public static async Task<IEnumerable<string>> ValidarDatosModificacion(DtoModificarAlumno PAlumno)
    {
        List<string> lstValidacion = [];

        if (PAlumno.Nombre.Length <= 2)
            lstValidacion.Add("Debe escibir un nombre valido");

        if (PAlumno.APaterno.Length <= 3)
            lstValidacion.Add("Debe escibir un apellido paterno valido");

        if (PAlumno.AMaterno.Length <= 3)
            lstValidacion.Add("Debe escibir un apellido materno valido");

        if (PAlumno.FecNaci.Length <= 3)
            lstValidacion.Add("Debe seleccionar una fecha de nacimiento");


        return await Task.FromResult(lstValidacion.AsEnumerable());
    }

    public static async Task<IEnumerable<string>> GuardarAlumno(string PCadena, DtoAltaAlumno PAlumno)
    {
        List<string> lstDatos = [];
        string SQLScript = "INSERT INTO ALUMNO (Nombre,APaterno,AMaterno,FecNaci)\r\n\t\t\tVALUES (@P_Nombre,@P_APaterno,@P_AMaterno,@P_FecNaci)";

        DateTime FNacimiento = new(Convert.ToInt32(PAlumno.FecNaci.Substring(4, 4)), Convert.ToInt32(PAlumno.FecNaci.Substring(2, 2)), Convert.ToInt32(PAlumno.FecNaci[..2]));

        try
        {
            var dpParametros = new
            {
                P_Nombre = PAlumno.Nombre,
                P_APaterno = PAlumno.APaterno,
                P_AMaterno = PAlumno.AMaterno,
                P_FecNaci = FNacimiento
            };

            Contexto.Procedimiento_ScriptDB(PCadena, SQLScript, dpParametros);
            lstDatos.Add("00");
            lstDatos.Add("Alumno registrado con éxito");

        }
        catch (Exception ex)
        {
            lstDatos.Add("14");
            lstDatos.Add(ex.Message);
        }

        return await Task.FromResult(lstDatos);
    }

    public static async Task<IEnumerable<string>> ModificarAlumno(string PCadena, DtoModificarAlumno PAlumno)
    {
        List<string> lstDatos = [];
        string SQLScript = "UPDATE ALUMNO SET Nombre = @P_Nombre,\r\n\t\t\t\t  APaterno = @P_APaterno,\r\n\t\t\t\t  AMaterno = @P_AMaterno,\r\n\t\t\t\t  IsActivo = @P_IsActivo,\r\n\t\t\t\t  FecNaci = @P_FecNaci\r\nWHERE Matricula = @P_Matricula";

        DateTime FNacimiento = new(Convert.ToInt32(PAlumno.FecNaci.Substring(4, 4)), Convert.ToInt32(PAlumno.FecNaci.Substring(2, 2)), Convert.ToInt32(PAlumno.FecNaci[..2]));

        try
        {
            var dpParametros = new
            {
                P_Matricula = PAlumno.Matricula,
                P_Nombre = PAlumno.Nombre,
                P_APaterno = PAlumno.APaterno,
                P_AMaterno = PAlumno.AMaterno,
                P_IsActivo = PAlumno.Estatus,
                P_FecNaci = FNacimiento
            };

            Contexto.Procedimiento_ScriptDB(PCadena, SQLScript, dpParametros);
            lstDatos.Add("00");
            lstDatos.Add("Alumno modificado con éxito");

        }
        catch (Exception ex)
        {
            lstDatos.Add("14");
            lstDatos.Add(ex.Message);
        }

        return await Task.FromResult(lstDatos);

    }

    public static async Task<IEnumerable<string>> BorrarAlumno(string PCadena, int PMatricula)
    {
        List<string> lstDatos = [];
        string SQLScript = "DELETE ALUMNO\r\nWHERE Matricula = @P_Matricula";

        try
        {
            var dpParametros = new
            {
                P_Matricula = PMatricula
            };

            Contexto.Procedimiento_ScriptDB(PCadena, SQLScript, dpParametros);
            lstDatos.Add("00");
            lstDatos.Add("Alumno borrado con éxito");

        }
        catch (Exception ex)
        {
            lstDatos.Add("14");
            lstDatos.Add(ex.Message);
        }

        return await Task.FromResult(lstDatos.AsEnumerable());
    }



}

