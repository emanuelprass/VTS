﻿using SceletonAPI.Application.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Queries.PricingList
{
    public class PricingListDto : BaseDto
    {
        public PricingListDtoMeta Meta { set; get; }
		public List<ModelKendaraan> Model { set; get; }
        public List<PricingListDtoData> Data { set; get; }
    }

    public class PricingListDtoMeta
    {
        public int? Page { get; set; }
        public int? Limit { get; set; }
        public int TotalData { get; set; }
        public int TotalPage { get; set; }
    }
	
	public class ModelKendaraan
	{
		public string ModelName { get; set; }
	}

    public class PricingListDtoData
    {
        public int Id { get; set; }
        public string Region { set; get; }
        public string DestinationCode { set; get; }
        public string DestinationName { set; get; }
        public string VendorName { set; get; }
        public string VendorGrade { set; get; }
		public List<Pricing> Pricing { get; set; }
		public string DeliveryMode { set; get; }
        public string CreatedBy { set; get; }
        public DateTime CreatedTime { set; get; }
        public string UpdatedBy { set; get; }
        public DateTime UpdatedTime { set; get; }
    }
	
	public class Pricing
    {
		public long Price { get; set; }
		public string ModelName { get; set; }
	}
}
