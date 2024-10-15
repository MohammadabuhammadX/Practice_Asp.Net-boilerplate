using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Practice.Events.Dto
{
    [AutoMapTo(typeof(Speaker))]
    public class CreateSpeakerInput
    {
        [Required]
        public string Name { get; set; }
        public string Bio { get; set; }
    }
}
