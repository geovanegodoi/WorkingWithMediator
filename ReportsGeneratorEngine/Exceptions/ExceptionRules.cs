using System;
namespace ReportsGeneratorEngine.Exceptions
{
    public static class ExceptionRules
    {
        public static bool ThrowException()
        {
            return new Random().Next(minValue: 1, maxValue: 10) % 2 == 0;
        }
    }

    public static class FailureRules
    {
        public const int SUCESS_CODE = 0;
        public const int FAIL_CODE = 1;

        public static bool ThrowFail()
        {
            return new Random().Next(minValue: 1, maxValue: 10) % 2 == 0;
        }
    }
}
