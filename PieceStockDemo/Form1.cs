using PieceToStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PieceToStock
{
    public partial class Form1 : Form
    {
        /// <summary>
       


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { /// 出料标签
          /// </summary>
            string[] pieceLabels = new string[]
            {
            "4103H", "4104H", "6603H", "6604H", "2703H", "2704H", "2603H", "2604H", "6503H", "6504H", "3107H", "3108H",
            "4407H", "4408H", "3307H", "3308H", "3507H", "3508H", "2503H", "2504H", "3007H", "3008H", "3207H", "3208H",
            "5807H", "5808H", "3407H", "3408H", "2403H", "2404H", "3505H", "3506H", "2905H", "2906H", "3405H", "3406H",
            "4205H", "4206H", "6705H", "6706H", "2805H", "2806H", "2203H", "2204H", "1407H", "1408H", "3305H", "3306H",
            "3205H", "3206H", "1605H", "1606H", "5805H", "5806H", "1214APH", "1214PH", "1519H", "2903H", "2904H",
            "3105H", "3106H", "4203H", "4204H", "6703H", "6704H", "2803H", "2804H", "4405H", "4406H", "3005H", "3006H",
            "1014H", "1131H", "1413H", "1625H"
            };


            /// <summary>
            /// 出料数量
            /// </summary>
            uint[] pieceDemandValues = new uint[]
            {
            1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 3, 3, 5, 5, 5, 5, 5, 5, 2, 2, 1, 1, 1, 1, 3, 3, 1, 1, 1, 1,
            2, 2, 1, 1, 1, 1, 1, 1, 4, 4, 1, 1, 5, 5, 4, 4, 2, 2, 2, 2, 4, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 5, 5, 8,
            8, 8, 8
            };

            /// <summary>
            /// 出料长度
            /// </summary>
            decimal[] pieceLengthes = new decimal[]
            {
            11738.1m, 11738.1m, 11294.5m, 11294.5m, 11236.2m, 11236.2m, 10409.3m, 10409.3m, 10381.7m, 10381.7m,
            10200.8m, 10200.8m, 9990.2m, 9990.2m, 9967m, 9967m, 9805.3m, 9805.3m, 9615.8m, 9615.8m, 9557.1m, 9557.1m,
            9395.3m, 9395.3m, 9351.2m, 9351.2m, 9289.2m, 9289.2m, 8869.3m, 8869.3m, 8514.2m, 8514.2m, 8268.7m, 8268.7m,
            8133.4m, 8133.4m, 8067.2m, 8067.2m, 7744.2m, 7744.2m, 7675m, 7675m, 7612.6m, 7612.6m, 6578m, 6577.9m,
            6551.2m, 6551.2m, 6232.2m, 6232.2m, 6181.6m, 6181.5m, 6158.7m, 6158.7m, 6109.6m, 6109.6m, 6109.6m, 4706.8m,
            4706.8m, 4576.3m, 4576.3m, 4528.6m, 4528.6m, 4429.6m, 4429.6m, 4405m, 4405m, 4346.1m, 4346.1m, 4316.8m,
            4316.8m, 770m, 770m, 770m, 770m,
            };

            string[] stockLabels = new string[]
           {
            "STD_6500", "STD_7500", "STD_8000", "STD_8500", "STD_9000", "STD_9500", "STD_10000", "STD_10500",
            "STD_11000", "STD_11500", "STD_12000",
           };

            decimal[] stockLengthes = new decimal[]
           {
            6500.0m, 7500.0m, 8000.0m, 8500.0m, 9000.0m, 9500.0m, 10000.0m, 10500.0m, 11000.0m, 11500.0m, 12000.0m,
           };
            decimal[] stockWorthes = new decimal[]
           {
            6500.0m, 7500.0m, 8000.0m, 8500.0m, 9000.0m, 9500.0m, 10000.0m, 10500.0m, 11000.0m, 11500.0m, 12000.0m,
           };

            decimal[] stockCuttingReduces = new decimal[]
           {
            22m, 22m, 22m, 22m, 22m, 22m, 22m, 22m, 22m, 22m, 22m,
           };


            decimal[] stockHoldingLengthes = new decimal[]
           {
            30m, 30m, 30m, 30m, 30m, 30m, 30m, 30m, 30m, 30m, 30m,
           };

            uint[] stockSupportValues = new uint[]
           {
            26, 162, 23, 110, 395, 90, 318, 96, 52, 278, 359,
           };

            bool[] isAllowBuyNew = new bool[]
           {
            false, false, false, false, false, false, false, false, false, false, false,
           };


            /// <summary>
            /// 切割宽度
            /// </summary>
            decimal cuttingLength = 22;

            /// <summary>
            /// 夹持长度
            /// </summary>
            decimal holdingLength = 0;

            /// <summary>
            /// 料端余量
            /// </summary>
            decimal cuttingReduce = 30;


            int cutcutingLimitInOneStock = 4;

            //排料结果list
            List<Stock> arrangedAllstocks;

            //排料汇总信息
            CuttingInfo cuttingInfo;

            //进行排料
            CreateCuttingStockMode(pieceLabels, pieceDemandValues, pieceLengthes, stockLabels, stockLengthes, stockSupportValues, cuttingLength, holdingLength, cuttingReduce, cutcutingLimitInOneStock, out arrangedAllstocks, out cuttingInfo);

            //进行排料
            lsbArrange.Items.Clear();

            txtArrange.Text = "";
            StringBuilder s = new StringBuilder();
            foreach (Stock allStock in arrangedAllstocks)
            {
                if (allStock.PieceList.Count > 0)
                {
                    lsbArrange.Items.Add("原料标签：" + allStock.Label +
                                           "||||" +
                                           "方案：" + allStock.ToString() +
                                           "|||剩余长度" +
                                           (allStock.AvailableLength - allStock.UsedLength).ToString() +
                                           "|||切料类型总数" + allStock.PieceListTypeCount);

                    s.Append("原料标签：" + allStock.Label +
                                            "||||" +
                                            "方案：" + allStock.ToString() +
                                            "|||剩余长度" +
                                            (allStock.AvailableLength - allStock.UsedLength).ToString() +
                                            "|||切料类型总数" + allStock.PieceListTypeCount + "\r\n");
                }

            }
            txtArrange.Text = s.ToString();

            lsbSumInfo.Items.Clear();
            lsbSumInfo.Items.Add("用料总数:" + cuttingInfo.stockCount);
            lsbSumInfo.Items.Add("余料:" + cuttingInfo.stockReduceSum / 1000);
            lsbSumInfo.Items.Add("用量长度:" + cuttingInfo.stockSum / 1000);
            lsbSumInfo.Items.Add("使用率:" + 100 * (1 - cuttingInfo.stockReduceSum / cuttingInfo.stockSum) + "%");
        }

        /// <summary>
        /// 进行切料处理
        /// </summary>
        /// <param name="pieceLabels">待出料标签,如"3231H"</param>
        /// <param name="pieceDemandValues">待出料个数</param>
        /// <param name="pieceLengthes">长度</param>
        /// <param name="stockLabels">原料标签</param>
        /// <param name="stockLengthes">原料长度</param>
        /// <param name="stockSupportValues">原料个数</param>
        /// <param name="cuttingLength">切割宽度</param>
        /// <param name="holdingLength">夹持余量</param>
        /// <param name="stockMargin">料端余量</param>
        /// <param name="cutcutingLimitInOneStock">每原料可容纳切料类型数，设置打印标签上线</param>
        /// <param name="arrangedAllstocks"></param>
        /// <param name="cuttingInfo"></param>
        /// <returns></returns>
        public int CreateCuttingStockMode(string[] pieceLabels,
                                          uint[] pieceDemandValues,
                                          decimal[] pieceLengthes,
                                          string[] stockLabels,
                                          decimal[] stockLengthes,
                                          uint[] stockSupportValues,
                                          decimal cuttingLength,
                                          decimal holdingLength,
                                          decimal stockMargin,
                                          int cutcutingLimitInOneStock,
                                          out List<Stock> arrangedAllstocks,
                                          out CuttingInfo cuttingInfo)
        {
            //生成切料问题解决实例
            CuttingStockProblem cuttingStockProblem = new CuttingStockProblem();

            return cuttingStockProblem.CreateCuttingStockMode(pieceLabels, pieceDemandValues, pieceLengthes, stockLabels, stockLengthes, stockSupportValues, cuttingLength, holdingLength, stockMargin, cutcutingLimitInOneStock, out arrangedAllstocks, out cuttingInfo);


        }

        private void button2_Click(object sender, EventArgs e)
        {



            string[] pieceLabels = new string[]
          {
            "2423H", "1432H", "1433H", "1434H", "1435H", "1631H", "1632H", "1633H", "1634H", "3034H", "3035H", "3134H",
            "3135H", "2823H", "2824H", "2923H", "2924H", "2618H", "2619H", "2718H", "2719H", "4434H", "4435H", "3433H",
            "3434H", "3533H", "3534H", "4121H", "4122H", "4223H", "4224H", "3523H", "3524H", "3461H", "2415H", "2416H",
            "2515H", "2516H", "3230H", "3231H", "3330H", "3331H", "3460H", "1620H", "1120H", "1121H", "1422H", "1423H",
            "1110H", "4214H", "4215H", "3519H", "3520H", "1112H", "1111H", "3419H", "3420H", "1415H", "3590H",
          };

            uint[] pieceDemandValues = new uint[]
          {
            2, 2, 2, 2, 2, 2, 2, 2, 2, 5, 5, 2, 2, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 3, 3, 1, 1, 2, 2, 3, 3, 2, 1, 1,
            5, 5, 5, 5, 1, 1, 2, 8, 4, 4, 4, 4, 8, 2, 2, 3, 3, 4, 4, 1, 1, 8, 6,
          };

            decimal[] pieceLengthes = new decimal[]
           {
            7619.5m, 6774.4m, 6774.4m, 6774.4m, 6774.4m, 6176.3m, 6176.3m, 6176.3m, 6176.3m, 5725.7m, 5725.7m, 5725.7m,
            5725.7m, 5568.3m, 5568.3m, 5568.3m, 5568.3m, 5348m, 5348m, 5348m, 5348m, 5254.3m, 5254.3m, 5201.1m, 5201.1m,
            5201.1m, 5201.1m, 5110m, 5110m, 5110m, 5110m, 5065m, 5065m, 5033.7m, 5017.5m, 5017.5m, 5017.5m, 5017.5m,
            5017.5m, 5017.5m, 5017.5m, 5017.5m, 4283.8m, 3886m, 3720m, 3719.9m, 3530.3m, 3530.1m, 3466.2m, 3436.6m,
            3436.6m, 3386.3m, 3386.3m, 3365.2m, 3365m, 3334m, 3334m, 3231.5m, 550m,
           };


            string[] stockLabels = new string[]
           {
            "STD_7000", "STD_8000", "STD_11000", "STD_12000",
           };

            decimal[] stockLengthes = new decimal[]
           {
            7000.0m, 8000.0m, 11000.0m, 12000.0m,
           };
            uint[] stockSupportValues = new uint[]
           {
            29, 32, 70, 106,
           };

            /// <summary>
            /// 切割宽度
            /// </summary>
            decimal cuttingLength = 22;

            /// <summary>
            /// 夹持长度
            /// </summary>
            decimal holdingLength = 0;

            /// <summary>
            /// 料端余量
            /// </summary>
            decimal cuttingReduce = 30;


            int cutcutingLimitInOneStock = 4;

            //排料结果list
            List<Stock> arrangedAllstocks;

            //排料汇总信息
            CuttingInfo cuttingInfo;

            //进行排料
            CreateCuttingStockMode(pieceLabels, pieceDemandValues, pieceLengthes, stockLabels, stockLengthes, stockSupportValues, cuttingLength, holdingLength, cuttingReduce, cutcutingLimitInOneStock, out arrangedAllstocks, out cuttingInfo);
            lsbArrange.Items.Clear();

            txtArrange.Text = "";
            StringBuilder s = new StringBuilder();
            foreach (Stock allStock in arrangedAllstocks)
            {
                if (allStock.PieceList.Count > 0)
                {
                    lsbArrange.Items.Add("原料标签：" + allStock.Label +
                                            "||||" +
                                            "方案：" + allStock.ToString() +
                                            "|||剩余长度" +
                                            (allStock.AvailableLength - allStock.UsedLength).ToString() +
                                            "|||切料类型总数" + allStock.PieceListTypeCount);

                    s.Append("原料标签：" + allStock.Label +
                                            "||||" +
                                            "方案：" + allStock.ToString() +
                                            "|||剩余长度" +
                                            (allStock.AvailableLength - allStock.UsedLength).ToString() +
                                            "|||切料类型总数" + allStock.PieceListTypeCount + "\r\n");
                }

            }
            txtArrange.Text = s.ToString();

            lsbSumInfo.Items.Clear();
            lsbSumInfo.Items.Add("用料总数:" + cuttingInfo.stockCount);
            lsbSumInfo.Items.Add("余料:" + cuttingInfo.stockReduceSum / 1000);
            lsbSumInfo.Items.Add("用量长度:" + cuttingInfo.stockSum / 1000);
            lsbSumInfo.Items.Add("使用率:" + 100 * (1 - cuttingInfo.stockReduceSum / cuttingInfo.stockSum) + "%");
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}
