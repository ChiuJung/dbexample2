
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace ActivitySystemEntity
{

    public class Member
    {
        #region 
        public int id { get; set; }
        public string department { get; set; }
        public string staffCard { get; set; }
        public string idCard { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string role { get; set; }
        #endregion

        /// <summary>
        /// 更新單筆資料
        /// </summary>
        /// <returns></returns>
        public bool update()
        {
            // A.資料庫位址
            string connectionString = "您的SOMEE資料庫位址(Connection string)";
            // B.SQL指令
            string sql = ;

            int reply = 0;
            // 1.連接資料庫
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // 2.開啟資料庫
                conn.Open();
                // 3.處理SQL語法
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    try
                    {
                        // 4.接收SQL結果
                        reply = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        reply = 0;
                    }

                }
            }

            // C.回傳結果
            bool result = reply == 1 ? true : false;
            return result;
        }
        /// <summary>
        /// 查詢單筆資料
        /// </summary>
        /// <param name="staffCard"></param>
        /// <returns></returns>
        public Member selectSingleObject(string staffCard)
        {
            Member member = new Member();
            string connectionString = ;
            string sql = "SELECT department, staffCard, idCard, userName, userPassword, role FROM tb_member WHERE staffCard = @staffCard";

            this.staffCard = staffCard;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@staffCard", this.staffCard);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        member.department = reader[0].ToString();
                        member.staffCard = reader[1].ToString();
                        member.idCard = reader[2].ToString();
                        member.userName = reader[3].ToString();
                        member.userPassword = reader[4].ToString();
                        member.role = reader[5].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return member;
        }

        #region
        public bool insert()
        {
            return true;
        }
        public bool delete(string staffCard)
        {
            return true;
        }
        public List<Member> selectMultiObjects()
        {
            List<Member> members = new List<Member>();
            return members;
        }
        #endregion
    }

}
