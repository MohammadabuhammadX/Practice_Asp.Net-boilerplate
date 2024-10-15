using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Events.Dto
{
    public class UpdateSpeakerInput :EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Bio { get; set; }

    }
}
