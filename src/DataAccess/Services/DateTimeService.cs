using mediatR.Business.Common.Interfaces;
using System;

namespace mediatR.DataAccess.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
