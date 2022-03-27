
namespace SceletonAPI.Domain.Entities
{
	public class MasterDataDestination
	{
		public int ID { set; get; }
		public string DealerCode { set; get; }
		public string DealerName { set; get; }
		public string SoldToParty { set; get; }
		public string TempDestinationCode { set; get; }
		public string DestinationCode { set; get; }
		public string DestinationName { set; get; }
		public string SearchTerm { set; get; }
		public string StreetName { set; get; }
		public string City { set; get; }
		public string Region { set; get; }
		public string PostalCode { set; get; }
		public string CustomerGroup { set; get; }
		public int DelvLeadTime { set; get; }
		public string CreatedBy { set; get; }
		public string UpdatedBy { set; get; }
	}
}
