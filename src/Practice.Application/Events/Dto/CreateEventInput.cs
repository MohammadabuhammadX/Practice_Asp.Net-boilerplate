﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Practice.Events.Dto
{
    public class CreateEventInput
    {
        [Required]
        [StringLength(Event.MaxTitleLength)]
        public string Title { get; set; }
        [StringLength(Event.MaxDescriptionLength)]
        public string Description { get; set; }

        public DateTime Date { get; set; }
        [Range(0, int.MaxValue)]
        public int MaxRegistrationCount { get; set; }

        public List<Guid> SpeakerIds{ get; set; } // Modified 

    }
}
