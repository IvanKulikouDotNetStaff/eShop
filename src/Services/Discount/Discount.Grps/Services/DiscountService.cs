using AutoMapper;
using Discount.Grps.Entities;
//using Discount.Grps.Protos;
using Discount.Grps.Repositories;
using Grpc.Core;

namespace Discount.Grps.Services
{
    public class DiscountService //: //DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _repository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public DiscountService(ILogger logger, IDiscountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        //public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        //{
        //    Coupon coupon = await _repository.GetDiscount(request.ProdictName);

        //    if (coupon == null)
        //    {
        //        throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName={request.ProdictName} is not found."));
        //    }

        //    _logger.LogInformation("Discount founded");

        //    var couponModel = _mapper.Map<CouponModel>(coupon);
        //    return couponModel;
        //}

        //public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        //{
        //    var coupon = _mapper.Map<Coupon>(request.Coupon);

        //    await _repository.CreateDiscount(coupon);
        //    _logger.LogInformation("Succes");

        //    CouponModel couponModel = _mapper.Map<CouponModel>(coupon);
        //    return couponModel;
        //}

        //public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        //{
        //    var coupon = _mapper.Map<Coupon>(request.Coupon);

        //    await _repository.UpdateDiscount(coupon);
        //    _logger.LogInformation("Succes");

        //    CouponModel couponModel = _mapper.Map<CouponModel>(coupon);
        //    return couponModel;
        //}

        //public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        //{
        //    bool deleted = await _repository.DeleteDiscount(request.ProductName);

        //    DeleteDiscountResponse deleteDiscountResponse = new()
        //    {
        //        Success = deleted
        //    };

        //    return deleteDiscountResponse;
        //}
    }
}
