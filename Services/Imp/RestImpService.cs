using NotificationService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Services.Imp
{
    public interface RestImpService
    {
        List<Feature> GetForDay(DateTime day);
        Feature GetRegion(Geometry geometry);
    }
}
