using MediatR;
using System.Collections.Generic;

namespace SceletonAPI.Application.UseCases.MasterData.Command.VendorCreateUpdate
{
	public class VendorCreateUpdateCommand : IRequest<VendorCreateUpdateDto>
	{
		public List<CreateDto> data { get; set; }		
	}
	public class CreateDto
	{
		public string lfa1_lifnr { set; get; }
		public string lfa1_name1 { set; get; }
		public string lfa1_name2 { set; get; }
		public string lfa1_name3 { set; get; }
		public string lfa1_land1 { set; get; }
		public string lda1_ort01 { set; get; }	
		public string lfa1_pstlz { set; get; }
		public string lfa1_regio { set; get; }
		public string lfa1_sortl { set; get;}
		public string lfa1_stras { set; get; }
		public string lfa1_loevm { set; get; }
		public string lfa1_sperr { set; get; }
		public string lfa1_sperm { set; get; }
		public string lfa1_erdat { set; get; }
		public string lfm1_ekorg { set; get; }
		public string lfm1_verkf { set; get; }
		public string lfm1_telf1 { set; get; }
		public string lfm1_erdat { set; get; }
		public string adr2_tel_number { set; get; }
		public string adr2_tel_extens { set; get; }
		public string adr6_smtp_addr { set; get; }
		public string created_by { set; get; }
		public string updated_by { set; get; }
	}
	
}
