using FrieghtManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrieghtManagment.Repositories
{
    internal interface IScheduleRepository
    {
        IList<Schedule> GetSchedules();
    }
}
