using ChatClientForm.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClientForm.Models
{
    public record Chat(long roomId, string username, string message, ChatState state);
}
