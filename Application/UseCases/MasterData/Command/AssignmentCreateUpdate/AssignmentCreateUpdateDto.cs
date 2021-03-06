using SceletonAPI.Application.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SceletonAPI.Application.UseCases.MasterData.Command.AssignmentCreateUpdate
{
    
    public class AssignmentCreateUpdateDto : BaseDto
    {
		public AssignmentCreateUpdateDtoData Data { set; get; }
    }
	
	public class AssignmentCreateUpdateDtoData
    {
		public int Id { set; get; }
    }

}
