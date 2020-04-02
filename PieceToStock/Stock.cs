using PieceToStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PieceToStock
{
    public class Stock
    {
        public Stock()
        {
            PieceList = new List<Piece>();
        }
        /// <summary>
        /// 原料长度
        /// </summary>
        public decimal Length;

        /// <summary>
        /// 原料标签
        /// </summary>
        public string Label;

        /// <summary>
        /// 原料切割方案列表
        /// </summary>
        public List<Piece> PieceList;


        /// <summary>
        /// 共有几个切割方案
        /// </summary>
        public int PieceListTypeCount
        {
            get
            {
                int pieceListTypeCount = 0;
                foreach(var item in PieceList.GroupBy(s => s.Label))
                {
                    pieceListTypeCount++;
                }
                return pieceListTypeCount;
            }
        }

        /// <summary>
        /// 夹持长度
        /// </summary>
        public decimal HoldingLength;

        /// <summary>
        /// 料端余量
        /// </summary>
        public decimal Margin;

        /// <summary>
        /// 可用长度，原始长度-夹持长度-料端余量
        /// </summary>
        public decimal AvailableLength
        {
            get => Length - HoldingLength - Margin;
        }

        public decimal UsedLength
        {
            get => GetUsedLength();
            set => UsedLength = value;
        }


        private decimal GetUsedLength()
        {
            decimal pieceLengthSum = 0;
            for(int i = 0; i < PieceList.Count; i++)
            {
                pieceLengthSum += PieceList[i].Length;
            }
            return pieceLengthSum;
        }

        public override string ToString()
        {
            string toSTring = "";
            for(int i = 0; i < PieceList.Count; i++)
            {
                string pieceString = PieceList[i].ToString();
                toSTring = toSTring + pieceString + ";";
            }
            return toSTring;
        }
    }
}
