using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Member_hy.Dto;
using Member_hy.Dto.IdCard;
using Member_hy.Entitys;
using Member_hy.enums;
using Microsoft.EntityFrameworkCore;

namespace Member_hy.Dao.IdCard
{
    public class IdCardDaoImpl : BaseDaoImpl, IdCardDao
    {
        public IdCardDaoImpl(MemberContext dbContext) : base(dbContext)
        {
        }
        //public Clubercar FindClubercarsousuo(IdCardDto icd)
        //{
        //    var query = from n in _dbContext.Clubercar
        //                where n.CCardId == icd




        //}

        //获取id卡信息
        public Clubercars Cber(string id)
        {
            var query = from n in _dbContext.Clubercar
                        where n.CCardId == id
                        select new Clubercars
                        {
                            CCardId = n.CCardId,
                            ClubId = n.ClubId,
                            Cardtype = n.Cardtype,
                            Collectiontype = n.Collectiontype,
                            Cardseller = n.Cardseller,
                            CUdeadline = n.CUdeadline,
                            CUdeadlinestr = n.CUdeadline.Value.ToString("d") + ' ' + n.CUdeadline.Value.ToString("t"),
                            State = n.State,
                            Sort = n.Sort,
                            Cda = n.Cda,
                            Xda = n.Xda,
                            //CExpiretime = n.CExpiretime,
                            CExpiretimestr = n.CExpiretimestr,
                            CFrequency = n.CFrequency,
                            //PAmount = Clu.PAmount
                            Cdatring = Math.Ceiling(n.Cda.Value).ToString()
                        };
                 var data = query.FirstOrDefault();
                //o.CExpiretimestr = o.CExpiretime.Value.ToString("d") + ' ' + o.CExpiretime.Value.ToString("t");
           
            return data;
        }

        ////根据用户查询会员卡
        //public List<Clubercar> FindClubercar(Vmparameter pageCond)
        //{
        //    var query = from n in _dbContext.Clubercar
        //                join Clu in _dbContext.Cluber on n.ClubId equals Clu.ClubId
        //                where Clu.ClubId == pageCond.dataId && n.ClubId == pageCond.dataId
        //                select n;
        //    var data = query.ToList();
        //    foreach (var o in data)
        //    {
        //        o.CUdeadlinestr = o.CUdeadline.Value.ToString("d") + ' ' + o.CUdeadline.Value.ToString("t");
        //        o.CExpiretimestr = o.CExpiretime.Value.ToString("d") + ' ' + o.CExpiretime.Value.ToString("t");
        //    }



        //    List<Clubercar> PageResult = new List<Clubercar>(data);
        //    return data;
        //}

        //根据用户查询会员卡
        public List<Clubercars> FindClubercars(Vmparameter pageCond)
        {
            //dataid 会员ID
            // idcard 卡号



            //(
            //                // “||”取其中一个就可以了
            //                //1.会员id如果为空，就什么sql where条件也不拼接
            //                //2.会员id如果不为空，拼接对应where条件， and q.clubid=页面传入的会员ID
            //                (pageCond.dataId == null || q.ClubId == pageCond.dataId)//如果会员ID不为空，传入查询条件
            //                &&
            //                //取其中一个就可以了
            //                //1.会员id如果为空，就什么sql where条件也不拼接
            //                //2.会员id如果不为空，拼接对应where条件， and q.clubid=页面传入的会员ID
            //                (string.IsNullOrEmpty(pageCond.idcard) || n.CCardId == pageCond.idcard)//如果卡号不为空，传入卡号查询条件
            //            )
            var query = from
                              q in _dbContext.Cluber
                        join n in _dbContext.Clubercar on q.ClubId equals n.ClubId
                        //join Clu in _dbContext.Consumption on n.CCardId equals Clu.CCardId
                        where
                        //用卡号去查
                        //会员ID为空，卡号不为空
                        (pageCond.dataId==null&& !string.IsNullOrEmpty(pageCond.idcard)&& n.CCardId == pageCond.idcard)
                        ||
                        //用会员ID去查询
                        //会员ID不为空，卡号为空
                        (pageCond.dataId != null && string.IsNullOrEmpty(pageCond.idcard) && q.ClubId == pageCond.dataId)
                        ||
                        //用会员ID去查询
                        //会员ID不为空，卡号为空
                        (pageCond.dataId != null && !string.IsNullOrEmpty(pageCond.idcard) && q.ClubId == pageCond.dataId && n.CCardId == pageCond.idcard)
                        select new Clubercars
                        {
                            CCardId = n.CCardId,
                            ClubId = n.ClubId,
                            Cardtype = n.Cardtype,
                            Collectiontype = n.Collectiontype,
                            Cardseller = n.Cardseller,
                            CUdeadline = n.CUdeadline,
                            CUdeadlinestr = n.CUdeadlinestr,
                            State = n.State,
                            Sort = n.Sort,
                            Cda = n.Cda,
                            Xda = n.Xda,
                            //CExpiretime = n.CExpiretime,
                            CExpiretimestr = n.CExpiretimestr,
                            CFrequency = n.CFrequency,
                            //PAmount = Clu.PAmount
                            Cdatring = Math.Ceiling(n.Cda.Value).ToString()
                        };
                       
           
            var data = query.ToList();
            foreach (var o in data)
            {
                if (o.CUdeadline != null) {
                    o.CUdeadlinestr = o.CUdeadline.Value.ToString("d") + ' ' + o.CUdeadline.Value.ToString("t");
                    
                }
                
                

                //o.CExpiretimestr = o.CExpiretime.Value.ToString("d") + ' ' + o.CExpiretime.Value.ToString("t");
            }



            List<Clubercars> PageResult = new List<Clubercars>(data);
            return data;
        }




        //添加用户会员卡
        public int SaveIdcard(SaveAll sall)
        {
            var ccar = sall.Ccar;

            _dbContext.Clubercar.AddRange(ccar);
            _dbContext.SaveChanges();
            return (int)EnumDataStatus.OK;

        }

        /// <summary>
        /// 生成消费记录
        /// </summary>
        /// <param name="consumption"></param>
        /// <returns></returns>
        public int SaveConsum(Consumption consumption)
        {
            _dbContext.Consumption.AddRange(consumption);
            _dbContext.SaveChanges();
            return (int)EnumDataStatus.OK;
        }


        //消费
        public int Updateqian(Clubercar cube)
        {
            var qu = cube.CFrequency.Trim();
            if (cube.Xda != null) {
                
                if (qu != "不限")
                {
                    var cis = int.Parse(qu);
                    if (cis >= 1)
                    {
                        Clubercar c = new Clubercar();

                        c.CFrequency = (cis - 1).ToString();
                        c.CCardId = cube.CCardId;
                        _dbContext.Attach(c);
                        _dbContext.Entry(c).Property(po => po.CFrequency).IsModified = true;
                        _dbContext.SaveChanges();
                        return (int)EnumDataStatus.OK;

                    }
                    else
                    {

                        return (int)EnumDataStatus.EXCC;
                    }

                }
                else {
                    if (qu == "不限")
                    {
                        Clubercar c = new Clubercar();
                        if (cube.Cardseller==0)
                        {
                            cube.Cardseller = 1;
                            var a = Convert.ToDecimal(cube.Cardseller);
                            if (cube.Xda * a * cube.Consum > cube.Cda)
                            {
                                return (int)EnumDataStatus.EXLSS;
                            }
                            else
                            {
                                c.Cda = cube.Cda - (cube.Xda * a * cube.Consum);
                                c.CCardId = cube.CCardId;
                                _dbContext.Attach(c);
                                _dbContext.Entry(c).Property(po => po.Cda).IsModified = true;
                                _dbContext.SaveChanges();
                                return (int)EnumDataStatus.OK;
                            }
                        }
                        else
                        {
                          
                            var a = Convert.ToDecimal(cube.Cardseller);
                            if (cube.Xda * a * cube.Consum > cube.Cda)
                            {
                                return (int)EnumDataStatus.EXLSS;
                            }
                            else
                            {
                                c.Cda = cube.Cda - (cube.Xda * a * cube.Consum);
                                c.CCardId = cube.CCardId;
                                _dbContext.Attach(c);
                                _dbContext.Entry(c).Property(po => po.Cda).IsModified = true;
                                _dbContext.SaveChanges();
                                return (int)EnumDataStatus.OK;

                            }
                        }
                    }
                }
            }
            else{
                return (int)EnumDataStatus.DEL;
            }
            return (int)EnumDataStatus.DEL;

        }

        public int Update(Clubercar cube)
        {
            Clubercar c = new Clubercar();
            c.ClubId = cube.ClubId;
            c.CCardId = cube.CCardId;
            c.Cardtype = cube.Cardtype;
            c.Collectiontype = cube.Collectiontype;
            c.Cardseller = cube.Cardseller;
            c.CUdeadline = cube.CUdeadline;
            c.Cda = cube.Cda;
            //c.CExpiretime = cube.CExpiretime;
            c.CFrequency = cube.CFrequency;

            _dbContext.Attach(c);

            _dbContext.Entry(c).Property(po => po.Cardtype).IsModified = true;
            _dbContext.Entry(c).Property(po => po.Collectiontype).IsModified = true;
            _dbContext.Entry(c).Property(po => po.Cardseller).IsModified = true;
            _dbContext.Entry(c).Property(po => po.CUdeadline).IsModified = true;
            _dbContext.Entry(c).Property(po => po.Cda).IsModified = true;
            //_dbContext.Entry(c).Property(po => po.CExpiretime).IsModified = true;
            _dbContext.Entry(c).Property(po => po.CFrequency).IsModified = true;


            _dbContext.SaveChanges();
            return (int)EnumDataStatus.OK;

        }

        public int Delet(string id)
        {
            SqlParameter[] sqlParameters = new[] {
                new SqlParameter("@id",id)
        };
            _dbContext.Database.ExecuteSqlCommand("delete from clubercar where cCardId = @id", sqlParameters);
            return (int)EnumDataStatus.OK;



        }

        
    }
}
