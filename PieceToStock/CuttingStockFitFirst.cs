using System;
using System.Collections.Generic;
using System.Linq;

namespace PieceToStock


{
    public struct CuttingInfo
    {
        public int stockCount;
        public decimal stockReduceSum;
        public decimal stockSum;
    }

    public class CuttingStockProblem
    {
        public CuttingStockProblem()
        {
        }

        /// <summary>
        /// 切料组成list组成编号长度的列表
        /// </summary>
        /// <param name="pieceLabel"></param>
        /// <param name="pieceDemandValue"></param>
        /// <param name="pieceLength"></param>
        /// <returns></returns>
        public List<Piece> CreatePieceList(string[] pieceLabel,
                                           uint[] pieceDemandValue,
                                           decimal[] pieceLength,
                                           decimal cuttingLegnth)
        {
            List<Piece> pieceList = new List<Piece>();
            //先检查输入的数据是否长度一致
            if(pieceLabel.Length != pieceDemandValue.Length || pieceLabel.Length != pieceLength.Length)
            {
                throw new Exception("输入数据长度不一致");
            }

            for(int index = 0; index < pieceLabel.Length; index++)
            {
                for(int i = 0; i < pieceDemandValue[index]; i++)
                {
                    Piece piece = new Piece();
                    piece.Label = pieceLabel[index];
                    piece.Length = pieceLength[index];
                    piece.cuttingLegnth = cuttingLegnth;
                    //插入到列表中
                    pieceList.Add(piece);
                }
            }
            if(pieceList == null || pieceList.Count == 0)
            {
                return null;
            }

            return pieceList;
        }

        /// <summary>
        /// 通过原料数据创建原料list
        /// </summary>
        /// <param name="stockLabels">原料标签</param>
        /// <param name="stockSupportValues">原料数量</param>
        /// <param name="stocklength">原料长度</param>
        /// <param name="holdingLength">夹持量</param>
        /// <returns></returns>
        public List<Stock> CreateStockList(string[] stockLabels,
                                           uint[] stockSupportValues,
                                           decimal[] stocklength,
                                           decimal holdingLength,
                                           decimal cuttingReduce)
        {
            //先检查所有数组长度是否一致
            bool isAllArrayHasSameLength = true;

            //原料名字数量和原料保有量数量
            isAllArrayHasSameLength = stockLabels.Length == stockSupportValues.Length;

            //原料标签和原料价格
            isAllArrayHasSameLength = isAllArrayHasSameLength && stockLabels.Length == stocklength.Length;

            //如果输入长度不一致
            if(!isAllArrayHasSameLength)
            {
                throw (new Exception("输入数据的长度不一致"));
            }

            //创建输出stocklist
            List<Stock> stockList = new List<Stock>();

            for(int index = 0; index < stockLabels.Length; index++)
            {
                //根据函数创建一个原料实例
                for(int i = 0; i < stockSupportValues[index]; i++)
                {
                    //创建新stock实例
                    Stock stock = new Stock();

                    //给stock赋值label、length、cuttingReduce和holddinglength
                    stock.Label = stockLabels[index];
                    stock.Length = stocklength[index];
                    stock.Margin = cuttingReduce;
                    stock.HoldingLength = holdingLength;

                    //将stock实例追加到stocklist中
                    stockList.Add(stock);
                }
            }

            return stockList;
        }


        public List<T> RandomSortList<T>(List<T> ListT)
        {
            Random random = new Random();
            List<T> randomedList = new List<T>();

            foreach(T item in ListT)
            {
                randomedList.Insert(random.Next(randomedList.Count + 1), item);
            }
            return new List<T>(randomedList.ToArray());
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
            try
            {
                CuttingStockProblem cuttingStockProblem = new CuttingStockProblem();
                //创建allpiece列表
                List<Piece> pieceList = cuttingStockProblem.CreatePieceList(pieceLabels,
                                                                            pieceDemandValues,
                                                                            pieceLengthes,
                                                                            cuttingLength);

                //按长度降序排序
                pieceList = pieceList.OrderByDescending((Piece => Piece.Length)).ToList();

                //创建allstock列表
                List<Stock> stockList = CreateStockList(stockLabels,
                                                        stockSupportValues,
                                                        stockLengthes,
                                                        holdingLength,
                                                        stockMargin);

                //按长度降序排序
                stockList = stockList.OrderByDescending((Stock => Stock.Length)).ToList();


                //进行切料计算
                arrangedAllstocks = cuttingStockProblem.CuttingStockArrangeFFDLR(pieceList,
                                                                                 stockList,
                                                                                 cutcutingLimitInOneStock);

                //切割信息
                cuttingInfo = cuttingStockProblem.GetCuttingInfo(arrangedAllstocks);
                return 0;
            }
            catch
            {
                throw new Exception("出现错误");
            }
        }

        /// <summary>
        /// 按FFDLR进进行装箱，参考文献VARIABLE SIZED BIN PACKING其中的FFDLR 主要思路如下  p(i)是指第i个物品，B(i)是指第i个箱子  步骤1：若i<n，则pack p(i) into
        /// the first bin of size 1 that has room for it。尺寸最大，有容量容下它，是否为空不重要。  步骤2：若i<l，则repack contents of B(i) into
        /// the smallest possible empty bin
        /// </summary>
        /// <param name="allPiece"></param>
        /// <param name="allStock"></param>
        public List<Stock> CuttingStockArrangeFFDLR(List<Piece> allPieces,
                                                    List<Stock> stockList,
                                                    int cutingLimitInOneStock)
        {
            //步骤1若i<n，则pack p(i) into the first bin of size 1 that has room for it。尺寸最大，有容量容下它，是否为空不重要。 
            List<Stock> arrangedStockList = new List<Stock>();
            //获得第一个要排序的材料
            for(int piecesesIndex = 0; piecesesIndex < allPieces.Count; piecesesIndex++)
            {
                for(int i = 0; i < stockList.Count; i++)
                {
                    //是否能从当前stock上切下来
                    bool canCutFromCurrentStock = true;

                    //piece长度是否小于剩余长度
                    canCutFromCurrentStock = canCutFromCurrentStock &&
                        (stockList[i].AvailableLength - stockList[i].UsedLength) >
                        (allPieces[piecesesIndex].Length + allPieces[piecesesIndex].cuttingLegnth);

                    //此料上是否已经安排了n中切割方案
                    canCutFromCurrentStock = canCutFromCurrentStock &&
                        stockList[i].PieceListTypeCount < cutingLimitInOneStock;

                    if(canCutFromCurrentStock)
                    {
                        //将剪切的信息记录到这个原料上
                        allPieces[piecesesIndex].IsArranged = true;

                        //将切料信息记录到stock上
                        stockList[i].PieceList.Add(allPieces[piecesesIndex]);

                        //跳出循环
                        break;
                    }
                }
            }

            //找出被安排的最大值
            int maxIndex = 0;
            for(int i = 0; i < stockList.Count; i++)
            {
                if(stockList[i].UsedLength == 0)
                {
                    maxIndex = i;
                    break;
                }
            }

            //步骤2，repack
            //从安排好的地方取数值
            for(int i = 0; i < maxIndex; i++)
            {
                //反向去盒子，就是smallest的
                for(int j = stockList.Count - 1; j >= maxIndex; j--)
                {
                    //大盒子中的内容可以被装入小盒子中
                    if(stockList[i].UsedLength <= stockList[j].AvailableLength - stockList[j].UsedLength &&
                        stockList[i].AvailableLength != stockList[j].AvailableLength &&
                        i + j + 1 != stockList.Count)
                    {
                        stockList[j].PieceList.AddRange(stockList[i].PieceList);
                        stockList[i].PieceList.RemoveRange(0, stockList[i].PieceList.Count);
                        break;
                    }
                }
            }

            //仅输出有安排的stock
            for(int i = 0; i < stockList.Count; i++)
            {
                //如果stock剩余长度还大于出料长度
                if(stockList[i].UsedLength > 0)
                {
                    //将这个数据填充到已安排allstock中
                    arrangedStockList.Add(stockList[i]);
                }
            }


            return arrangedStockList;
        }


        /// <summary>
        /// 获得切料表信心
        /// </summary>
        /// <param name="stockList"></param>
        /// <returns></returns>
        public CuttingInfo GetCuttingInfo(List<Stock> stockList)
        {
            CuttingInfo cuttingInfo;


            //原料数量
            cuttingInfo.stockCount = stockList.Count;

            //余料长度
            cuttingInfo.stockReduceSum = 0;

            //料长度
            cuttingInfo.stockSum = 0;

            foreach(Stock allStock in stockList)
            {
                cuttingInfo.stockSum += allStock.Length;
                cuttingInfo.stockReduceSum += allStock.AvailableLength - allStock.UsedLength;
            }
            return cuttingInfo;
        }
    }
}
