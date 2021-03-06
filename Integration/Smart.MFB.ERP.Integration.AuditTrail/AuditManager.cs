﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace Smart.MFB.ERP.Integration.AuditTrail
{
    public class AuditManager
    {
        private DataContext _context;

        public AuditManager()
        {
            _context = new DataContext();
        }


        public AuditManager(string connection)
        {
            _context = new DataContext(connection);
        }

        public void AddAudit(DbEntityEntry entry, string loginName)
        {
            _context.AuditTrailFactory(entry, loginName);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public AuditTrail Get(long id)
        {
            var repo = new AuditTrailRepository();
            return repo.Get(id);
        }

        public IEnumerable<AuditTrail> Get()
        {
            var repo = new AuditTrailRepository();
            return repo.Get();
        }

        public IEnumerable<AuditTrail> GetByDate(DateTime fromDate, DateTime toDate)
        {
            var repo = new AuditTrailRepository();
            return repo.GetByDate(fromDate, toDate);
        }

        public IEnumerable<AuditTrail> GetAuditTrailByTab(AuditAction action)
        {
            var repo = new AuditTrailRepository();
            return repo.GetAuditTrailByTab(action);
        }

        public IEnumerable<AuditTrail> GetByTable(string tablename, DateTime fromDate, DateTime toDate)
        {
            var repo = new AuditTrailRepository();
            return repo.GetByTable(tablename, fromDate, toDate);
        }

        public IEnumerable<AuditTrail> GetByLoginID(string loginID, DateTime fromDate, DateTime toDate)
        {
            var repo = new AuditTrailRepository();
            return repo.GetByLoginID(loginID, fromDate, toDate);
        }

        public List<AuditTrail> GetByAction(string action, DateTime fromDate, DateTime toDate)
        {
            var repo = new AuditTrailRepository();
            return repo.GetByAction(action, fromDate, toDate);
        }
    }
}
