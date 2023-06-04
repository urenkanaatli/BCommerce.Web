using BCommerce.Application.Data;
using BCommerce.Application.UOWAndRepo.Repositories;
using BCommerce.Core.DomainClasses;
using BCommerce.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCommerce.Insfrastructure.UOWAndRepo.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        IApplicationDbContext dbContext;

        public CommentRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        //90 .... 80


        public List<Comment> GetCommentWithPage(int productid, int demand, int lastcommentid)
        {

            if (lastcommentid > 0)
            {


                return dbContext.Comments.OrderByDescending(t=>t.CreateDate).Where(t => t.ProductId == productid && t.Id < lastcommentid).Take(demand + 1).ToList();

            }
            else
            {
                return dbContext.Comments.Where(t => t.ProductId == productid).Take(demand + 1).ToList();
            }
        

        }
    }
}
