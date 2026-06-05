using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using s14112310482.Data;
using s14112310482.Models;

namespace s14112310482.Services
{
    public class s14112310482Service
    {
        public AppDbContext _dbS;
        public List<ImgCarousel> GetImgList()
        {
            var conn = (SqlConnection)_dbS.Database.GetDbConnection();
            string sql = @" SELECT * FROM ImgCarousels;";
            List<ImgCarousel> imgList = new List<ImgCarousel>();
            try
            {
                conn.Open();   
                SqlCommand cmd = new SqlCommand(sql, conn); 
                SqlDataReader dr = cmd.ExecuteReader();     
                while (dr.Read())
                {
                    ImgCarousel Data = new ImgCarousel();
                    Data.Id = Convert.ToInt32(dr["Id"]);
                    if (!dr["ImgF"].Equals(DBNull.Value))
                    {
                        Data.ImgF = dr["ImgF"].ToString();
                    }
                    imgList.Add(Data);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString()); 
            }
            finally
            {
                conn.Close(); 
            }
            return imgList;
        }
        //取得產品Product 的資料
        public List<Product> GetProductList()
        {
            var conn = (SqlConnection)_dbS.Database.GetDbConnection();
            string sql = @" SELECT * FROM Products;"; 
            List<Product> PList = new List<Product>();
            try
            {
                conn.Open();   
                SqlCommand cmd = new SqlCommand(sql, conn); 
                SqlDataReader dr = cmd.ExecuteReader();   
                while (dr.Read()) 
                {
                  Product Data = new Product(); 
                
                Data.Id = Convert.ToInt32(dr["Id"]);
                Data.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                Data.Difficulty = Convert.ToDouble(dr["Difficulty"]);
                Data.Name = dr["Name"].ToString();
                Data.ImgF = dr["ImgF"].ToString();
                // 資料庫允許空值的欄位先確定資料不為空值再轉換
                if (!dr["Description"].Equals(DBNull.Value))
                {
                    Data.Description = dr["Description"].ToString();
                }
                PList.Add(Data); //將單筆資料加入串列中
            }
 }
                 catch (Exception e)
     {
                 throw new Exception(e.Message.ToString()); // 丟出錯誤
                }
                 finally
                     {
                        conn.Close(); // 關閉資料庫連線
                      }
                        return PList;
             }
        public List<Product> GetAllProduct(string skey)
        {
            //宣告連線變數
            var conn = (SqlConnection)_dbS.Database.GetDbConnection();
            //準備回傳的結構(將表格所有資料串接成一個串列)
            List<Product> PList = new List<Product>();
        
//Sql 語法
string sql = string.Empty;
            if (!string.IsNullOrWhiteSpace(skey))
            {
                // 有搜尋條件時
                sql = $@" SELECT * FROM Products WHERE Name LIKE '%{skey}%' OR Description LIKE '%{skey}%'; ";
            }
            else
            {
                // 無搜尋條件時
                sql = @" SELECT * FROM Products; ";
            }
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Product Data = new Product();

                    Data.Id = Convert.ToInt32(dr["Id"]);
                    Data.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                    Data.Difficulty = Convert.ToDouble(dr["Difficulty"]);
                    Data.Name = dr["Name"].ToString();
                    Data.ImgF = dr["ImgF"].ToString();
                    // 資料庫允許空值的欄位先確定資料不為空值再轉換
                    if (!dr["Description"].Equals(DBNull.Value))
                    {
                        Data.Description = dr["Description"].ToString();
                    }
                    PList.Add(Data); //將單筆資料加入串列中
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString()); // 丟出錯誤
            }
            finally
            {
                conn.Close(); // 關閉資料庫連線
            }
            return PList;
        }
    }
}
                
   