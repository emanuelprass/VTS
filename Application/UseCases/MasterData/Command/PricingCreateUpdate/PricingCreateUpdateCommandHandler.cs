﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoredProcedureEFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using SceletonAPI.Application.UseCases.MasterData.Command.PricingCreateUpdate;
using SceletonAPI.Application.Interfaces;
using SceletonAPI.Domain.Entities;

namespace SceletonAPI.Application.UseCases.MasterData.Command.PricingCreateUpdate
{
    public class PricingCreateUpdateCommandHandler : IRequestHandler<PricingCreateUpdateCommand, PricingCreateUpdateDto>
    {
        private readonly IVTSDBContext _context;
        private readonly IMapper _mapper;

        public PricingCreateUpdateCommandHandler(IVTSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PricingCreateUpdateDto> Handle(PricingCreateUpdateCommand request, CancellationToken cancellationToken)
        {
            var response = new PricingCreateUpdateDto();

            foreach(var i in request.Data)
            {
                List<MasterDataPricing> spinsertPricing = null;
                _context.loadStoredProcedureBuilder("SP_InsertUpdate_PricingMasterData")
                    .AddParam("Region", i.Region)
                    .AddParam("DestinationCode", i.DestinationCode)
                    .AddParam("VendorCode", i.VendorCode)
                    .AddParam("ModelName", i.CarModel)
                    .AddParam("Price", i.Price)
                    .AddParam("DeliveryMode", i.DeliveryMode)
                    .AddParam("UpdatedBy", i.UpdatedBy)
                    .Exec(r => spinsertPricing = r.ToList<MasterDataPricing>());
            }
            response.Success = true;
            response.Message = "Pricing berhasil dibuat atau diupdate";
            
            return response;
        }
    }
}
