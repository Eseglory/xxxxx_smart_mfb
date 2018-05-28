using Smart.MFB.ERP.Common;
using Smart.MFB.ERP.Common.Contracts;
using Smart.MFB.ERP.Common.Core;
using Smart.MFB.ERP.Integration.AuditTrail.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Smart.MFB.ERP.Integration.AuditTrail
{
    public class DataContext : DbContext
    {
        const string SOLUTION_NAME = "CORE";

        public DataContext()
            : base("name=LagetronixSchoolDB")
        {
            Database.SetInitializer<DataContext>(null);
        }

        public DataContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer<DataContext>(null);
        }

        //Core

        public List<AuditTrail> auditTrailList = new List<AuditTrail>();

        public DbSet<AuditTrail> AuditTrailSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Ignore<PropertyChangedEventHandler>();
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();

            //Fintrak.Shared.SystemCore.Entities.AuditTrail
            modelBuilder.Entity<AuditTrail>().HasKey<long>(e => e.AuditTrailId).Ignore(e => e.EntityId);
            modelBuilder.Entity<AuditTrail>().Property(c => c.RowVersion).IsRowVersion();
            modelBuilder.Entity<AuditTrail>().ToTable("cor_audittrail");
        }

        public override int SaveChanges()
        {
            try
            {
                if (auditTrailList.Count > 0)
                {
                    foreach (var audit in auditTrailList)
                    {
                        //add all audits 
                        AuditTrailSet.Add(audit);
                    }

                    auditTrailList.Clear();
                }

                return base.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                var innerEx = e.InnerException;
                while (innerEx.InnerException != null)
                    innerEx = innerEx.InnerException;

                throw new Exception(innerEx.Message);
            }
            catch (DbEntityValidationException e)
            {
                var sb = new StringBuilder();

                foreach (var entry in e.EntityValidationErrors)
                {
                    foreach (var error in entry.ValidationErrors)
                    {
                        sb.AppendLine(string.Format("{0}-{1}-{2}", entry.Entry.Entity, error.PropertyName, error.ErrorMessage));
                    }
                }

                throw new Exception(sb.ToString());
            }
            catch (Exception e)
            {
                var innerEx = e.InnerException;
                while (innerEx.InnerException != null)
                    innerEx = innerEx.InnerException;

                throw new Exception(innerEx.Message);
            }

        }

        public AuditTrail AuditTrailFactory(DbEntityEntry entry, string userName)
        {
            AuditTrail audit = new AuditTrail();

            audit.RevisionStamp = DateTime.Now;
            audit.TableName = entry.Entity.GetType().Name;
            audit.UserName = userName;
            audit.IPAddress = AuditIPAddress.GetIPAddress();
            audit.Deleted = false;
            audit.CreatedBy = userName;
            audit.CreatedOn = DateTime.Now;
            audit.UpdatedBy = userName;
            audit.UpdatedOn = DateTime.Now;

            if (entry.State == EntityState.Added)
            {
                //entry is Added 

                var model = (EntityBase)entry.Entity;
                model.CreatedBy = "";
                model.CreatedOn = DateTime.Now;
                model.UpdatedBy = "";
                model.UpdatedOn = DateTime.Now;

                audit.NewData = GetEntryValueInString(entry, false);
                audit.Actions = AuditAction.C;
            }
            else if (entry.State == EntityState.Deleted)
            {
                //entry in deleted
                audit.OldData = GetEntryValueInString(entry, true);
                audit.Actions = AuditAction.D;
            }
            else
            {
                //entry is modified
                var model = (EntityBase)entry.Entity;
                model.UpdatedBy = "";
                model.UpdatedOn = DateTime.Now;

                audit.OldData = GetEntryValueInString(entry, true);
                audit.NewData = GetEntryValueInString(entry, false);
                audit.Actions = AuditAction.U;

                IEnumerable<string> modifiedProperties = entry.CurrentValues.PropertyNames;
                //assing collection of mismatched Columns name as serialized string 
                audit.ChangedColumns = XMLSerializationHelper.XmlSerialize(modifiedProperties.ToArray());
            }

            auditTrailList.Add(audit);

            return audit;
        }

        public string GetEntryValueInString(DbEntityEntry entry, bool isOrginal)
        {
            if (entry.Entity is EntityBase)
            {
                object target = CloneEntity(entry.Entity);

                IEnumerable<string> properties = null;
                if (isOrginal)
                    properties = entry.OriginalValues.PropertyNames;
                else
                    properties = entry.CurrentValues.PropertyNames;

                foreach (string propName in properties)
                {
                    object setterValue = null;
                    if (isOrginal)
                    {
                        //Get orginal value 
                        setterValue = entry.OriginalValues[propName];
                    }
                    else
                    {
                        //Get orginal value 
                        setterValue = entry.CurrentValues[propName];
                    }
                    //Find property to update 
                    PropertyInfo propInfo = target.GetType().GetProperty(propName);
                    //update property with orgibal value 
                    if (setterValue == DBNull.Value)
                    {//
                        setterValue = null;
                    }
                    propInfo.SetValue(target, setterValue, null);

                }//end foreach

                XmlSerializer formatter = new XmlSerializer(target.GetType());
                XDocument document = new XDocument();

                using (XmlWriter xmlWriter = document.CreateWriter())
                {
                    formatter.Serialize(xmlWriter, target);
                }
                return document.Root.ToString();
            }
            return null;
        }

        public object CloneEntity(object obj)
        {
            DataContractSerializer dcSer = new DataContractSerializer(obj.GetType());
            MemoryStream memoryStream = new MemoryStream();

            dcSer.WriteObject(memoryStream, obj);
            memoryStream.Position = 0;

            object newObject = dcSer.ReadObject(memoryStream);
            return newObject;
        }

    }
}
