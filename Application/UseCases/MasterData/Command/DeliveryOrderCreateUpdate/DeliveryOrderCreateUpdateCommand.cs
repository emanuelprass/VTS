using MediatR;
using System.Collections.Generic;

namespace SceletonAPI.Application.UseCases.MasterData.Command.DeliveryOrderCreateUpdate
{
	public class DeliveryOrderCreateUpdateCommand : IRequest<DeliveryOrderCreateUpdateDto>
	{
		public List<CreateDto> data { get; set; }		
	}       
	public class CreateDto
	{
		public string likp_vbeln { set; get; }
        public string likp_kunag { set; get; }
        public string likp_kunnr { set; get; }
        public string vbak_vdatu { set; get; }
        public string likp_wadat_ist { set; get; }
        public string equi_indbt { set; get; }
        public string lips_matnr { set; get; }
        public string equi_typbz { set; get; }
        public string zfudt0034_model { set; get; }
        public string zfudt0034_lcamatnr { set; get; }
        public string lips_arktx { set; get; }
        public string lips_lgort { set; get; }
        public string lips_ean11 { set; get; }
        public string equz_mapar { set; get; }
        public string lips_vgbel { set; get; }
		public string created_by { set; get; }
		public string updated_by { set; get; }
	}
	
}
