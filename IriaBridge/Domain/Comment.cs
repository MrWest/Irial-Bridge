using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.Domain
{
    // Irial patform users commnets regarding  certain item
    public class Comment: Entity
    {
        int Owner { get; set; }
        String comment { get; set; }

        String date_created { get; set; }
        String id_user { get; set; }
        String user_first_name { get; set; }
        String user_last_name { get; set; }

        String user_picture { get; set; }

        String Message { get { return comment; } }
        String Date { get { return comment; } }
        String UserName { get { return $"{user_first_name} {user_last_name}"; } }
        String UserPicture { get { return comment; } }
    }
}
