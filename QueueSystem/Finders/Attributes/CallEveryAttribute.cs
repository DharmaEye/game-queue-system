using System;

namespace QueueSystem.Finders.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CallEveryAttribute : Attribute
    {
        private readonly int _interval;
        private readonly TimeIntervalType _timeIntervalType;

        public CallEveryAttribute(int interval, TimeIntervalType timeIntervalType)
        {
            _interval = interval;
            _timeIntervalType = timeIntervalType;
        }
    }
}