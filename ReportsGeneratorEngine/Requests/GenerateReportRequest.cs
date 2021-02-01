using System;
using MediatR;
using Microsoft.VisualBasic;

namespace ReportsGeneratorEngine.Requests
{
    public class GenerateReportRequest : IRequest
    {
        private IStrategy _strategy;
        public string Query { get; private set; }

        public GenerateReportRequest(IStrategy strategy)
        {
            SetStrategy(strategy);
        }

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
            Query = strategy.GetQuery();
        }
    }

    public interface IStrategy
    {
        string GetQuery();
    }

    public class WeeklyStrategy : IStrategy
    {
        private readonly string _conditions;

        public WeeklyStrategy(string conditions)
        {
            _conditions = conditions;
        }

        public string GetQuery()
        {
            if (!TodayIsFriday())
            {
                //throw new Exception("Relatorio semanal só pode ser gerado na sexta-feira");
            }
            // Monta query para o relatório semanal
            return $"SELECT * FROM WEEKLY_TABLE WHERE {_conditions}";
        }

        private bool TodayIsFriday() => DateTime.Now.Day == (int)DayOfWeek.Friday;
    }

    public class MonthlyStrategy : IStrategy
    {
        private readonly string _conditions;

        public MonthlyStrategy(string conditions)
        {
            _conditions = conditions;
        }

        public string GetQuery()
        {
            if (!TodayIsDayOne())
            {
                //throw new Exception("Relatorio mensal só pode ser gerado dia 1");
            }
            // Monta query para o relatório mensal
            return $"SELECT * FROM MONTHLY_TABLE WHERE {_conditions}";
        }

        private bool TodayIsDayOne() => DateTime.Now.Day == 1;
    }
}
