using MediatR;
using System.Collections.Generic;

namespace SceletonAPI.Application.UseCases.MasterData.Command.DestinationCreateUpdate
{
	public class DestinationCreateUpdateCommand : IRequest<DestinationCreateUpdateDto>
	{
		public List<CreateDto> data { get; set; }		
	}
	public class CreateDto
	{
		public string kunag { set; get; }
		public string name2 { set; get; }
        public string destcodex { set; get; }
        public string destcode { set; get; }
        public string name1 { set; get; }
        public string dlrdc { set; get; }
        public string sort1 { set; get; }
        public string street { set; get; }
        public string post_code1 { set; get; }
        public string city1 { set; get; }
        public string region { set; get; }
        public string kvgr1 { set; get; }
        public string dlvlt { set; get; }
        public string erdat { set; get; }
        public string erzet { set; get; }
        public string ernam { set; get; }
        public string sdate { set; get; }
        public string stime { set; get; }
        public string sname { set; get; }
		public string created_by { set; get; }
		public string updated_by { set; get; }
	}
	
}
