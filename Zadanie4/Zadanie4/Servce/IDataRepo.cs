﻿using System.Collections.Generic;

namespace Servce
{
    public interface IDataRepo
    {
        void AddReason(ReasonS reasonS);
        void UpdateReason(ReasonS reasonS, int id);
        void DeleteReason(int id);
        ReasonS GetSalesReason(int id);
        IEnumerable<ReasonS> GetAllReasons();

    }
}
