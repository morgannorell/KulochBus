using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace KulochBus
{
    class Member
    {
        public int PersonId;
        public string Responsibility;
        public string Membership;
        public bool PictureAllowed;
        public bool IsLeader;
        public int Price;
        
        public Member(int personId, string responsibility, string membership, bool pictureAllowed, bool isLeader, int price)
        {
            PersonId = personId;
            Responsibility = responsibility;
            Membership = membership;
            PictureAllowed = pictureAllowed;
            IsLeader = isLeader;
            Price = price;
          
        }

        public int createMember()
        {
            NpgsqlConnection conn = new NpgsqlConnection
                ("Server = 81.25.82.40; Port = 5432; User Id = adminkulobus; Password = developer; Database = kulochbus");

            try
            {
                conn.Open();

                string sqlMember = "INSERT INTO member (personid, membership, responsibility, pictureallowed, isleader, price) values (" + PersonId + ",'" + Membership + "', '" + Responsibility + "', " + PictureAllowed + ", " + IsLeader + ", " + Price + ")RETURNING memberid;";
                NpgsqlCommand cmd = new NpgsqlCommand(sqlMember, conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                var id = 0;

                while (dr.Read())
                {
                    id = (int)dr["memberid"];
                }

                dr.Close();
                conn.Close();

                return id;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
    }
}
