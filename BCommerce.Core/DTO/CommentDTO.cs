using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCommerce.Core.DTO
{

    public class CommentPageDTO
    {

        public List<CommentDTO> Comments { get; set; }

        public int AllCount { get; set; }

        public bool IsLastPage { get; set; }


    }
   
    public class CommentDTO
    {
        public int Id { get; set; }

        public string Meseage { get; set; }

        public int ProductId { get; set; }


        public DateTime CreateDate { get; set; }
    }
}
