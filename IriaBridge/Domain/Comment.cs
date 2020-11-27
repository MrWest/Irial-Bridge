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
        public String comment { get; set; }

        public String date_created { get; set; }
        public String id_user { get; set; }
        public String user_first_name { get; set; }
        public String user_last_name { get; set; }

        public String user_picture { get; set; }

        public String Message { get { return comment; } }
        public String Date { get { return date_created; } }
        public String UserName { get { return $"{user_first_name} {user_last_name}"; } }
        public String UserPicture { get { return comment; } }
    }
}
