﻿using MediatR;
using SceletonAPI.Application.Models.Query;

namespace SceletonAPI.Application.UseCases.MasterData.Command.VendorCreateUpdate
{
	public class VendorCreateUpdateCommand : BaseQueryCommand, IRequest<VendorCreateUpdateDto>
	{
		public int ID { set; get; }
		public string Code { set; get; }
		public string Name { set; get; }
		public string Name2 { set; get; }
		public string Grade { set; get; }
		public string Country { set; get; }
		public string City { set; get; }
		public string PostalCode { set; get; }
		public string Region { set; get; }
		public string Street { set; get; }
		public string DeletionFlag { set; get; }
		public string PostingBlock { set; get; }
		public string PurchBlock { set; get; }
		public string CreatedOn { set; get; }
		public string Telephone { set; get; }
		public string Email { set; get; }
		public string CreatedBy { set; get; }
		public string UpdatedBy { set; get; }
	}
}
