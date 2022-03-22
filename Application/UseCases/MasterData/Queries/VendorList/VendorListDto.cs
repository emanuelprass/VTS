using SceletonAPI.Application.Models.Query;
using System.Collections.Generic;
using System;

namespace SceletonAPI.Application.UseCases.MasterData.Queries.VendorList
{
	public class VendorListDto : BaseDto
	{
		public List<VendorListDtoData> Data { set; get; }
	}

	public class VendorListDtoData
	{
		public Int64 ID { set; get; }
		public string VendorCode { set; get; }
		public string VendorName { set; get; }
		public string VendorName2 { set; get; }
		public string VendorGrade { set; get; }
		public string VendorCountry { set; get; }
		public string VendorCity { set; get; }
		public string VendorPostalCode { set; get; }
		public string VendorRegion { set; get; }
		public string VendorStreet { set; get; }
		public string VendorDeletionFlag { set; get; }
		public string VendorPostingBlock { set; get; }
		public string VendorPurchaseBlock { set; get; }
		public DateTime VendorCreatedOn { set; get; }
		public string VendorTelephone { set; get; }
		public string VendorEmail { set; get; }
		public string CreatedBy { set; get; }
		public string UpdatedBy { set; get; }
	}
}
