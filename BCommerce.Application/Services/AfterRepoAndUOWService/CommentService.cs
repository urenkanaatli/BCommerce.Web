using BCommerce.Application.UOWAndRepo;
using BCommerce.Application.UOWAndRepo.Repositories;
using BCommerce.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCommerce.Application.Services.AfterRepoAndUOWService
{
    public class CommentService
    {
        private readonly ICommentRepository commentRepository; 
        private readonly IUnitOfWork unitOfWork;

        public CommentService(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            this.commentRepository = commentRepository;
            this.unitOfWork = unitOfWork;
        }
        public Result SendCommant(string userid, string comment, int productid)
        {

            #region validatition
            //fluentvalidation
            if (userid == null)
            {
                return Result.Error("userid bos olamaz");
            }

            if (comment.Length > 400)
            {
                return Result.Error("comment max 400 olmalıdır.");
            }

            #endregion


            commentRepository.Add(new Core.DomainClasses.Comment
            {
                ProductId = productid,
                UserId = userid,
                Meseage = comment

            });


            unitOfWork.Commit();

            return Result.Success();
        }

    }
}
