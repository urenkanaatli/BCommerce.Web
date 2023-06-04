using Microsoft.AspNetCore.Mvc.Filters;

namespace BCommerce.Web.Filters
{
    public class UIExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {

         

            //burada exception herhangi bir veri tabanına kaydedilir.
            //stack trace bilgisi bizi hangi sınıf için hangi line hata oldugunu sçyle
            base.OnException(context);
        }
    }
}
