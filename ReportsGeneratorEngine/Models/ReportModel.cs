using System.Data;

namespace ReportsGeneratorEngine.Models
{
    public class ReportModel
    {
        public DataTable DataTable { get; private set; }

        public ReportModel(DataTable dataTable)
        {
            DataTable = dataTable;
        }
    }
}
