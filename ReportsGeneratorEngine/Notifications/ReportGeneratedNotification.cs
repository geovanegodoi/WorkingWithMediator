using ReportsGeneratorEngine.Models;

namespace ReportsGeneratorEngine.Notifications
{
    public class ReportGeneratedNotification : NotificationBase
    {
        public ReportModel Report { get; private set; }

        public ReportGeneratedNotification() {}

        public ReportGeneratedNotification(ReportModel report)
        {
            Report = report;
        }

        public ReportGeneratedNotification WithReport(ReportModel report)
        {
            Report = report;
            return this;
        }
    }
}
