using System.Net.NetworkInformation;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using s14112310482.Data;
using s14112310482.Models;

namespace s14112310482.Services
{
    public class CatProDBService
    {
        public AppDbContext _dbS;
        //讀取 Category 資料表的內容
        public List<Category> GetCategoryList()
        {
            //直接使用dbContext取得資料，適合簡單查詢
            List<Category> objCategoryList = _dbS.Categories.ToList();
            return objCategoryList;
        }
        public List<Product> GetProductList(int cid)
        {
            //宣告連線變數
            var conn = (SqlConnection)_dbS.Database.GetDbConnection();
            //SQL 查詢語句 (Where條件設定為輸入的 Category 的 Id)
            string sql = $@" SELECT * FROM Products WHERE CategoryId={cid};";
            //準備回傳的結構(將表格所有資料串接成一個串列)
            List<Product> PList = new List<Product>();
            try
            {
                conn.Open(); // 開啟資料庫連線
                SqlCommand cmd = new SqlCommand(sql, conn); // 執行Sql 指令
                SqlDataReader dr = cmd.ExecuteReader(); // 取得查詢的資料
                while (dr.Read()) //獲得下一筆資料, 直到沒有資料
                {
                    Product Data = new Product(); //宣告一個暫存單筆資料的結構
                    Data.Id = Convert.ToInt32(dr["Id"]);
                    Data.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                    Data.Difficulty = Convert.ToDouble(dr["Difficulty"]);
                    Data.Name = dr["Name"].ToString();
                    Data.ImgF = dr["ImgF"].ToString();
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
            return PList
            ;
        }
        public string GetCatName(int cid) //給一個Category的Id值, 取得Category的名稱
        {
            var conn = (SqlConnection)_dbS.Database.GetDbConnection(); //宣告連線變數
            string catName = "";
            string sql = $@" SELECT Name FROM Categories WHERE Id = {cid};";
            try
            {
                conn.Open(); // 開啟資料庫連線
                SqlCommand cmd = new SqlCommand(sql, conn); // 執行Sql 指令
                SqlDataReader dr = cmd.ExecuteReader(); // 取得查詢的資料
                while (dr.Read()) //獲得下一筆資料, 直到沒有資料
                {
                    catName = dr["Name"].ToString();
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
            return catName;
        }
        public void InsertPro(Product newData)
        {
            //Sql 新增語法
            string sql = $@" INSERT INTO Products(Name,Difficulty,ImgF,Description, CategoryId)
VALUES ( '{newData.Name}',{newData.Difficulty},'{newData.ImgF}','{newData.Description}',{newData.CategoryId});";
            var conn = (SqlConnection)_dbS.Database.GetDbConnection(); //宣告連線變數
                                                                       // 確保程式不會因執行錯誤而整個中斷
            try
            {
                conn.Open(); // 開啟資料庫連線
                SqlCommand cmd = new SqlCommand(sql, conn); // 執行Sql 指令
                SqlDataReader dr = cmd.ExecuteReader(); // 取得查詢的資料
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString()); // 丟出錯誤
            }
            finally
            {
                conn.Close(); // 關閉資料庫連線
            }
        }
        public Product GetProById(int pid)
        {
            Product Data = new Product();
            string sql = $@" SELECT * FROM Products WHERE Id = '{pid}'; "; //Sql 語法
                                                                           //宣告連線變數
            var conn = (SqlConnection)_dbS.Database.GetDbConnection();
            // 確保程式不會因執行錯誤而整個中斷
            try
            {
                conn.Open();
                // 開啟資料庫連線
                SqlCommand cmd = new SqlCommand(sql, conn); // 執行Sql 指令
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                
                Data.Id = Convert.ToInt32(dr["Id"]);
                Data.Name = dr["Name"].ToString();
                Data.Difficulty = Convert.ToDouble(dr["Difficulty"]);
                Data.Description = dr["Description"].ToString();
                Data.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                Data.ImgF = dr["ImgF"].ToString();
            }
            catch (Exception e)
            {
                Data = null; // 查無資料
            }
            finally
            {
                conn.Close(); // 關閉資料庫連線
            }
            // 回傳根據編號所取得的資料
            return Data;
        }
        public void UpdatePro(Product UpdateData)
        {
            //Sql 修改語法
            string sql = $@" UPDATE Products SET Name = '{UpdateData.Name}', 
            Difficulty ={UpdateData.Difficulty},  Description= '{UpdateData.Description}',
            ImgF = '{UpdateData.ImgF}',  CategoryId= {UpdateData.CategoryId}
             where Id = {UpdateData.Id} ";
            var conn = (SqlConnection)_dbS.Database.GetDbConnection();
            try
            // 確保程式不會因執行錯誤而整個中斷
            {
                conn.Open();
                // 開啟資料庫連線
                SqlCommand cmd = new SqlCommand(sql, conn);  // 執行Sql 指令
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                conn.Close(); // 關閉資料庫連線
            }
     
         }
        public List<Product> GetProductList_page(ForPaging paging, int cid)
        {
            //宣告連線變數
            var conn = (SqlConnection)_dbS.Database.GetDbConnection();
            //呼叫方法, 設定paging 物件的屬性MaxPage(最大頁數) 的值
            SetMaxPaging(paging);
            int start = (paging.NowPage - 1) * paging.ItemNum + 1;
            int end = paging.NowPage * paging.ItemNum;
            //SQL 查詢語句(Where條件設定為輸入的Category 的Id)
            string sql = $@" SELECT * FROM (SELECT row_number() OVER(order by Id) AS sort,*FROM Products ) m WHERE m.CategoryId={cid} AND m.sort BETWEEN {start} AND {end}; ";
            //準備回傳的結構(將表格所有資料串接成一個串列)
            List<Product> PList = new List<Product>();
            try
            {
                conn.Open(); // 開啟資料庫連線
                SqlCommand cmd = new SqlCommand(sql, conn); // 執行Sql 指令
                SqlDataReader dr = cmd.ExecuteReader(); // 取得查詢的資料
                while (dr.Read()) //獲得下一筆資料, 直到沒有資料
                {
                    Product Data = new Product(); //宣告一個暫存單筆資料的結構
                    Data.Id = Convert.ToInt32(dr["Id"]);
                    Data.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                    Data.Difficulty = Convert.ToDouble
                    (dr["Difficulty"]);
                    Data.Name = dr["Name"].ToString();
                    Data.ImgF = dr["ImgF"].ToString();
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
            return PList
            ;
        }
        public void SetMaxPaging(ForPaging Paging)
        {
            //宣告連線變數
            var conn = (SqlConnection)_dbS.Database.GetDbConnection();
            int Row = 0; // 計算列數
       
            string sql = $@" SELECT COUNT(*) AS num FROM Products; ";
            // 確保程式不會因執行錯誤而整個中斷
            try
            {
                conn.Open();
                // 開啟資料庫連線
                SqlCommand cmd = new SqlCommand(sql, conn);
                // 取得Sql 資料
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                // 執行Sql 指令
                //只有一筆, 不用迴圈
                Row = Convert.ToInt32(dr["num"]); //將取得的資料存入Product資料結構
                
             }
            catch (Exception e)
            {
                // 丟出錯誤
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                // 關閉資料庫連線
                conn.Close();
            }

 // 計算所需的總頁數= 資料筆數/每頁個數
            Paging.MaxPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Row) / Paging.ItemNum));
            // 呼叫方法，重新設定正確的頁數，避免有不正確值傳入
            Paging.SetRightPage();
        }

        // CatProDBService.cs
        public void DeletePro(int pid)
        {
            var prod = _dbS.Products.Find(pid);   // 找到要刪的那筆
            if (prod != null)
            {
                _dbS.Products.Remove(prod);       // 刪掉
                _dbS.SaveChanges();               // 寫入 DB
            }
        }

    }
}

   

   
