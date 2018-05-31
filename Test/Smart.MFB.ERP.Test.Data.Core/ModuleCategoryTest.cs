using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smart.MFB.ERP.Data.Core;
using System.Linq;
using Smart.MFB.ERP.Common.Core.Entities;

namespace Smart.MFB.ERP.Test.Data.Core
{
    [TestClass]
    public class ModuleCategoryTest
    {
        [TestMethod]
        public void GetAllTestMethod()
        {
            var repo = new ModuleCategoryRepository();

            var entities = repo.Get();

            Assert.AreEqual(entities.Count(),2);
        }

        [TestMethod]
        public void GetByFilterTestMethod()
        {
            var repo = new ModuleCategoryRepository();

            var entities = repo.Get().Where(c=>c.Code == "Test2");

            Assert.AreEqual(entities.Count(), 1);
        }

        [TestMethod]
        public void CreateTestMethod()
        {
            var repo = new ModuleCategoryRepository();

            var entity = new ModuleCategory()
            {
                Code="Test1",
                Name="Test 1",
                Alias = "Test 1",
                Active = true,
                Deleted = false,
                CreatedBy = "Test",
                CreatedOn = DateTime.Now,
                UpdatedBy = "Test",
                UpdatedOn = DateTime.Now 
            };

            var newEntity = repo.Add(entity);

            entity = new ModuleCategory()
            {
                Code = "Test2",
                Name = "Test 2",
                Alias = "Test 2",
                Active = true,
                Deleted = false,
                CreatedBy = "Test",
                CreatedOn = DateTime.Now,
                UpdatedBy = "Test",
                UpdatedOn = DateTime.Now
            };

            repo.Add(entity);

            Assert.AreEqual(newEntity.EntityId, 1);
        }

        [TestMethod]
        public void UpdateTestMethod()
        {
            var repo = new ModuleCategoryRepository();

            var entity = repo.Get(1);

            entity.Alias = "Just Updated";

            var newEntity = repo.Update(entity);

            Assert.AreEqual(newEntity.Alias , "Just Updated");
        }

        [TestMethod]
        public void DeleteTestMethod()
        {
            var repo = new ModuleCategoryRepository();

            var entity = repo.Get(1);
             repo.Remove(entity);

            entity = repo.Get(1);

            Assert.IsNull(entity);
        }
    }
}
