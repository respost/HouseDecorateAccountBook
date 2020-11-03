using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;//引入 Microsoft Office Access 数据库
using System.Windows.Forms;

namespace 装修记账
{
    class DBhelper
    {
        #region 数据库连接字符串
        public static string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db\\DB_spruce.mdb";//数据库位于根目录下 db\DB_spruce.mdb
        OleDbConnection jfl = new OleDbConnection(strConn);//解放路
        OleDbConnection wml = new OleDbConnection(strConn);//文明路
        #endregion

        #region 临时数据集
        public DataSet ds = new DataSet();
        public OleDbDataAdapter feiji = null;
        #endregion

        #region 添加类型
        public bool AddType(string name)
        {
            bool flag = false;
            try
            {
                jfl.Open();
                string sql = string.Format("insert into type (typeName) values('{0}')", name);
                OleDbCommand bmw = new OleDbCommand(sql, jfl);
                int result = bmw.ExecuteNonQuery();
                if (result == 1)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                jfl.Close();
            }
            return flag;
        }
        #endregion

        #region 查询类型
        public void SelectType()
        {
            try
            {
                string sql = "select ID as 序号,typeName as 类名  from type";
                feiji = new OleDbDataAdapter(sql, jfl);
                if (ds.Tables["newType"] != null)
                {
                    ds.Tables["newType"].Clear();
                }
                feiji.Fill(ds, "newType");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 修改类型
        public bool UpdateType(string name,int id)
        {
            bool flag = false;
            try
            {
                jfl.Open();
                string sql = string.Format("update type set typeName='{0}' where id={1}", name,id);
                OleDbCommand bmw = new OleDbCommand(sql, jfl);
                int result = bmw.ExecuteNonQuery();
                if (result == 1)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                jfl.Close();
            }
            return flag;
        }
        #endregion

        #region 删除类型
        public bool DeleteType( int id)
        {
            bool flag = false;
            try
            {
                jfl.Open();
                string sql = string.Format("delete from type where id={0}", id);
                OleDbCommand bmw = new OleDbCommand(sql, jfl);
                int result = bmw.ExecuteNonQuery();
                if (result >0)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                jfl.Close();
            }
            return flag;
        }
        #endregion

        #region 通过类型名称获取类型ID
        public int GetTypeIdByName(string name)
        {
            int jg = 0;
            try
            {
                jfl.Open();
                string sql = string.Format("select id from type where typeName='{0}'", name);
                OleDbCommand bmw = new OleDbCommand(sql, jfl);
                jg = Convert.ToInt32(bmw.ExecuteScalar());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                jfl.Close();
            }
            return jg;
        }
        #endregion

        #region 通过ID查询明细
        public OleDbDataReader GetDetailsById(int uid)
        {
            jfl.Open();
            string sql = string.Format("select de_name,de_price,de_num,de_sumPrice,(select typeName from type where type.Id=de_typeId ) ,de_store,de_address,de_user,de_phone,de_date  from detail where  de_id={0}", uid);
            OleDbCommand bmw = new OleDbCommand(sql, jfl);
            return bmw.ExecuteReader(CommandBehavior.CloseConnection);
        }
        #endregion

        #region 添加明细
        public bool AddDetails(string name, double price, double num, double sumPrice, int typeId, string store, string address, string user, string phone,string date)
        {
            bool flag = false;
            try
            {
                jfl.Open();
                string sql = "";
                if (typeId==0)
                {
                    sql = string.Format("insert into detail(de_name,de_price,de_num,de_sumPrice,de_store,de_address,de_user,de_phone,de_date) values('{0}',{1},{2},{3},'{4}','{5}','{6}','{7}','{8}')", name, price, num, sumPrice, store, address, user, phone, date);
                }
                else
                {
                    sql = string.Format("insert into detail(de_name,de_price,de_num,de_sumPrice,de_typeId,de_store,de_address,de_user,de_phone,de_date) values('{0}',{1},{2},{3},{4},'{5}','{6}','{7}','{8}','{9}')", name, price, num, sumPrice, typeId, store, address, user, phone, date);
                }
       
                OleDbCommand bmw = new OleDbCommand(sql, jfl);
                int result = bmw.ExecuteNonQuery();
                if (result == 1)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                jfl.Close();
            }
            return flag;
        }
        #endregion

        #region 查询明细
        public void SelectDetails()
        {
            try
            {
                string sql = "select de_id as 编号,de_name as 名称,de_price as 单价,de_num as 数量,de_sumPrice as 合计,(select typeName from type where type.Id=de_typeId )  as 类型,de_store as 店铺,de_address as 地址,de_user as 联系人,de_phone as 联系电话,de_date as 日期  from detail";
                //string sql = "select * from detail";
                feiji = new OleDbDataAdapter(sql, jfl);
                if (ds.Tables["newDetail"] != null)
                {
                    ds.Tables["newDetail"].Clear();
                }
                feiji.Fill(ds, "newDetail");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 修改明细
        public bool UpdateDetails(string name, double price, double num, double sumPrice, int typeId, string store, string address, string user, string phone, string date,int uid)
        {
            bool flag = false;
            try
            {
                jfl.Open();
                string sql = "";
                if (typeId == 0)
                {
                    sql = string.Format("update detail set de_name='{0}',de_price={1},de_num={2},de_sumPrice={3},de_store='{4}',de_address='{5}',de_user='{6}',de_phone='{7}',de_date='{8}' where de_id={9}", name, price, num, sumPrice, store, address, user, phone, date,uid);
                }
                else
                {
                    sql = string.Format("update detail set de_name='{0}',de_price={1},de_num={2},de_sumPrice={3},de_typeId={4},de_store='{5}',de_address='{6}',de_user='{7}',de_phone='{8}',de_date='{9}' where de_id={10}", name, price, num, sumPrice, typeId, store, address, user, phone, date,uid);
                }

                OleDbCommand bmw = new OleDbCommand(sql, jfl);
                int result = bmw.ExecuteNonQuery();
                if (result == 1)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                jfl.Close();
            }
            return flag;
        }
        #endregion

        #region 删除明细
        public bool DeleteDetails(int id)
        {
            bool flag = false;
            try
            {
                jfl.Open();
                string sql = string.Format("delete from detail where de_id={0}", id);
                OleDbCommand bmw = new OleDbCommand(sql, jfl);
                int result = bmw.ExecuteNonQuery();
                if (result==1)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                jfl.Close();
            }
            return flag;
        }
        #endregion

        #region 统计全部支出
        public OleDbDataReader SumAllPay(string startTime, string endTime)
        {
            jfl.Open();
            string sql = string.Format("select sum(de_sumPrice) from detail  where de_date between  #{0}# and  #{1}# ", startTime, endTime);
            OleDbCommand bmw = new OleDbCommand(sql, jfl);
            return bmw.ExecuteReader(CommandBehavior.CloseConnection);
        }
        #endregion
        
        #region 按类型分组统计支出
        public OleDbDataReader SumPayByType(string startTime,string endTime)
        {
            wml.Open();
            string sql =string.Format("select (select typeName from type where type.Id=de_typeId ) as 类型,sum(de_sumPrice) as 总支出  from detail  where de_date between  #{0}# and  #{1}#  group by de_typeId", startTime,endTime);
            OleDbCommand bmw = new OleDbCommand(sql, wml);
            return bmw.ExecuteReader(CommandBehavior.CloseConnection);
        }
        #endregion

        #region 按月份统计支出
        public OleDbDataReader TjPayByMonth()
        {
            wml.Open();
            string sql = string.Format("select year(de_date) as 年,month(de_date) as 月 ,sum(de_sumPrice) as 总支出 from detail group by year(de_date),month(de_date) order by year(de_date) desc ");
            OleDbCommand bmw = new OleDbCommand(sql, wml);
            return bmw.ExecuteReader(CommandBehavior.CloseConnection);
        }
        #endregion
    }
}
