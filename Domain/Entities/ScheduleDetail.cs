using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ScheduleDetail
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public int Slot { get; set; }
        public int Status { get; set; }
    }
}
