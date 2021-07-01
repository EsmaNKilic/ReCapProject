using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework.cs
{
    public class EfUsersDal : EfEntityRepositoryBase<User, ProjectContext>, IUsersDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ProjectContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
