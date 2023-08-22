using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventsWebApiCore.Models
{
    public class EventUserViewModel
    {
        public Event Event { get; set; }

        public UserModel User { get; set; }
    }
}
