using Smart.MFB.ERP.Common.Core.Entities;
using Smart.MFB.ERP.Common.Extensions;
using Smart.MFB.ERP.Common.ServiceModel;
using Smart.MFB.ERP.Data.Core.Contract;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Smart.MFB.ERP.Data.Core
{
    [Export(typeof(IUserRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UserRepository : DataRepositoryBase<User>, IUserRepository
    {
        public UserRepository()
        {
           //_connection = DataConnectionEnum.Common;
        }
        protected override User AddEntity(CoreContext entityContext, User entity)
        {
            return entityContext.Set<User>().Add(entity);
        }
        protected override User UpdateEntity(CoreContext entityContext, User entity)
        {
            return (from e in entityContext.Set<User>()
                    where e.UserId == entity.UserId
                    select e).FirstOrDefault();
        }
        protected override IEnumerable<User> GetEntities(CoreContext entityContext)
        {
            return from e in entityContext.Set<User>()
                   select e;
        }
        protected override User GetEntity(CoreContext entityContext, long id)
        {
            var query = (from e in entityContext.Set<User>()
                         where e.UserId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }
        public IEnumerable<UserInfo> GetAllUser()
        {
            using (CoreContext entityContext = new CoreContext())
            {
                var query = from a in entityContext.UserSet
                            select new UserInfo()
                            {
                                User = a,
                            };

                return query.ToFullyLoaded();
            }
        }
        public User GetByLogin(string loginID)
        {
            using (CoreContext entityContext = new CoreContext())
            {
                var query = from a in entityContext.UserSet
                            where a.LoginID == loginID
                            select a;

                return query.FirstOrDefault();
            }
        }
    }
}
