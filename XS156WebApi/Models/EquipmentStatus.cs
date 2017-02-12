using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XS156WebApi.Models
{
    public enum EquipmentStatus
    {
        Active=0,
        Loan=1,
        Repaired=2,
        Maintenance=3,
        Inactive=4,
        Disposed=5
    }
}