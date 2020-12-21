using AutoMapper;
using ContactReport.Core;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Services;
using Project.CartAPI.Services;
using Project.Data.Entities.DTOs;

namespace Project.CartAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly ICartSessionService _cartSessionService;
        private readonly IMapper _mapper;

        public CartController(IProductService productService, ICartService cartService, ICartSessionService cartSessionService, IMapper mapper)
        {
            _productService = productService;
            _cartService = cartService;
            _cartSessionService = cartSessionService;
            _mapper = mapper;
        }

        [HttpPost]
        public ApiResult<CartDto> AddToCart(int productId)
        {
            var cart = _cartSessionService.GetCart();

            var productToBeAdded = _productService.GetById(productId, cart);

            _cartService.AddToCart(cart, productToBeAdded);

            _cartSessionService.SetCart(cart);

            ApiResult<CartDto> result = new ApiResult<CartDto>()
            {
                Data = _mapper.Map<CartDto>(cart),
                Success = true,
                StatusCode = Response.StatusCode,
                Message = "Sepete 1 ürün eklediniz."
            };

            return result;
        }

        [HttpDelete]
        [Route("{productId:int}")]
        public ApiResult<CartDto> RemoveToCart(int productId)
        {
            var cart = _cartSessionService.GetCart();

            _cartService.RemoveFromCart(cart, productId);

            _cartSessionService.SetCart(cart);

            ApiResult<CartDto> result = new ApiResult<CartDto>()
            {
                Data = _mapper.Map<CartDto>(cart),
                Success = true,
                StatusCode = Response.StatusCode,
                Message = "Sepetten 1 ürün kaldırdınız."
            };

            return result;
        }

        [HttpGet]
        public ApiResult<CartDto> GetAllCart()
        {
            ApiResult<CartDto> result = new ApiResult<CartDto>();
            result.Success = true;
            result.StatusCode = Response.StatusCode;

            var cart = _cartSessionService.GetCart();

            if (cart.CartLines.Count == 0)
            {
                result.Message = "Sepetinizde ürün bulunmamaktadır.";
            }
            else
            {
                result.Data = _mapper.Map<CartDto>(cart);
            }
            return result;
        }

        [HttpDelete]
        public ApiResult RemoveAllCart()
        {
            var cart = _cartSessionService.GetCart();
            cart.CartLines.Clear();

            _cartSessionService.SetCart(cart);

            ApiResult result = new ApiResult()
            {
                Success = true,
                StatusCode = Response.StatusCode,
                Message = "Sepetiniz temizlendi."
            };

            return result;
        }
    }
}
