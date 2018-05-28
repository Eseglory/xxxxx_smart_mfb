
using Smart.MFB.ERP.Common.Contracts;
using System;
using System.Collections.Generic;

namespace Smart.MFB.ERP.Integration.AuditTrail
{
    public interface IAuditTrailRepository : IDataRepository<AuditTrail>
    {
        IEnumerable<AuditTrail> GetByDate(DateTime fromDate, DateTime toDate);

        //IEnumerable<AuditTrail> GetByAction(AuditAction action, DateTime fromDate, DateTime toDate);

        IEnumerable<AuditTrail> GetByTable(string tableName, DateTime fromDate, DateTime toDate);

        IEnumerable<AuditTrail> GetByLoginID(string loginID, DateTime fromDate, DateTime toDate);

        IEnumerable<AuditTrail> GetAuditTrailByTab(AuditAction action);

        List<AuditTrail> GetByAction(string action, DateTime fromDate, DateTime toDate);

    }
}
