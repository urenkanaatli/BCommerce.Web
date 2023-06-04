using AutoMapper;
using BCommerce.Application.UOWAndRepo.Repositories;
using BCommerce.Core.DomainClasses;
using BCommerce.Core.DTO;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BCommerce.Application.Services
{
    public class CheckoutService
    {

        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;
        public CheckoutService(IBasketRepository basketRepository, IMapper mapper)
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
        }


        public Result<BankLoginResponse> LoginBank()
        {


            var client = new RestClient("https://localhost:7082/api/Autentication/Login", configureSerialization: s => s.UseNewtonsoftJson());
            var request = new RestRequest();
            request.Method = Method.Post;

            request.AddJsonBody(new
            {

                userName = "eecommerceUser!123*0",
                password = "eecommercePass!123*0"
            });

            RestResponse<BankLoginResponse> response = client.Execute<BankLoginResponse>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {

                return Result<BankLoginResponse>.Error("Beklenmedik hata");
            }


            return Result<BankLoginResponse>.Success(response.Data);
        }



        public Result<BankPayResponse> CreditCartPay(decimal amount, string ccNumber, int cvv, string token, int lastDate)
        {

            var client = new RestClient("https://localhost:7082/api/Payment/Pay", configureSerialization: s => s.UseNewtonsoftJson());
            var request = new RestRequest();
            request.Method = Method.Post;



            request.AddJsonBody(new
            {
                tokenText = token,
                ccNumber = ccNumber,
                cvv = cvv,
                lastDate = lastDate,
                amount = amount

            });

            RestResponse<BankPayResponse> response = client.Execute<BankPayResponse>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {

                return Result<BankPayResponse>.Error(response.Data.Error);
            }

            return Result<BankPayResponse>.Success();



        }




        public async Task<Result<int>> CreateOrder(string userid, CheckOutDTO checkoutmodel)
        {

            // ilgili sepeti bul
            //tutarı bul
            //** Bankaya login ol
            //cekim yaptır
            //order tablolarına sepeti yaz. 
            //sepeti bosalt


            //todo : generic repo ınclude eklenmeli
            // var userBasket = basketRepository.GetAll(t => t.UserId == userid, t => t.BasketItems, t => t.BasketItems.Select(t => t.Product)).FirstOrDefault();

            var userBasket = await basketRepository.GetUserBasket(userid);

            if (userBasket == null)
            {
                return Result<int>.Error("Sepet bulunamadı");
            }


            var total = userBasket.BasketItems.Sum(t => t.Count * t.Product.Price);



            var loginResult = LoginBank();

            if (!loginResult.IsSuccess)
            {
                return Result<int>.Error("Beklenmedik hata");

            }

            var payResult = CreditCartPay(total, checkoutmodel.CCNumber, checkoutmodel.Cvv, loginResult.Data.Token, checkoutmodel.LastDate);


            if (!payResult.IsSuccess)
            {
                return Result<int>.Error(payResult.Errors[0]);
            }

            Order order = await basketRepository.CreateOrerFromBasket(userBasket.Id, checkoutmodel.Country, checkoutmodel.City, checkoutmodel.PostCode, checkoutmodel.Description,checkoutmodel.Street);



            var result = Result<int>.Success();
            result.Data = order.Id;
            result.IsSuccess = true;
            return result;
        }

    }
}
