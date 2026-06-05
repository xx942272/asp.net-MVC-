namespace s14112310482.Services
{
    public class ForPaging
    {
        public int NowPage { get; set; } //目前頁碼
        public int MaxPage { get; set; } // 最大頁數
                                         // 一頁的個數，在此設為唯讀
        public int ItemNum
        {
            get
            {
                return 5;
            }
        }
        //建構子
        public ForPaging()
        {
            this.NowPage = 1; // 預設當前頁碼為1
        }
        //建構子(有傳入頁碼)
        public ForPaging(int Page)
        {
            this.NowPage = Page; // 設定當前頁碼
        }
        //方法
        // 設定正確頁數的方法，以避免傳入不確正值
        public void SetRightPage()
        {
            // 判斷當前頁數是否小於1
        if (this.NowPage < 1)
            {
                // 將頁數設回為1
        this.NowPage = 1;
            }
            // 判斷當前頁數是否大於總頁數
            else if (this.NowPage > this.MaxPage
            )
            {
                // 設定當前頁數為總頁數
                this.NowPage = this.MaxPage
                ;
            }
            // 將無資料時的當前頁數，重新設回1
        if (this.MaxPage.Equals(0))
            {
                this.NowPage = 1;
            }
        }
    }
}
 
