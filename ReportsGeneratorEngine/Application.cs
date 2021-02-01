using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReportsGeneratorEngine.Mediator;
using ReportsGeneratorEngine.Requests;

namespace ReportsGeneratorEngine
{
    public class Application
    {
        private readonly IMediatorContext _mediator;
        private readonly List<string> _parameters;

        public Application(IMediatorContext mediator)
        {
            _mediator = mediator;
            _parameters = new List<string> { "1", "2", "3", "4", "5" };
        }

        public void Run()
        {
            var listOfTasks = new List<Task>();

            foreach (var item in _parameters)
            {
                var weeklyStrategy = new WeeklyStrategy(item);
                var weeklyRequest  = new GenerateReportRequest(weeklyStrategy);
                listOfTasks.Add(_mediator.Send(weeklyRequest));

                var monthlyStrategy = new MonthlyStrategy(item);
                var monthyrequest   = new GenerateReportRequest(monthlyStrategy);
                listOfTasks.Add(_mediator.Send(monthyrequest));
            }
            Task.WaitAll(tasks: listOfTasks.ToArray());
        }
    }
}
