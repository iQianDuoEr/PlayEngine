using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using UnityEngine;

namespace Assets
{
    public class SqlAccess
    {
        public static MySqlConnection mySqlConnection;        //连接类对象
        private static string database = "PlayEngining";
        private static string host = "123.207.138.169";
        private static string id = "root";
        private static string pwd = "6622CKYcky2719";

        public SqlAccess()
        {
            OpenSql();
        }
        /// <summary>
        /// 打开数据库
        /// </summary>
        public static void OpenSql()
        {
            try
            {
                //string.Format是将指定的 String类型的数据中的每一个格式顶替换为响应对象的值得文本等效项
                string sqlString = string.Format("Database={0};Data Source={1};User Id={2};Password={3};", database, host, id, pwd);
                mySqlConnection = new MySqlConnection(sqlString);
                mySqlConnection.Open();
            }
            catch (Exception)
            {
                throw new Exception("连接数据库失败");
            }
        }
        /// <summary>
        /// 创建表
        /// </summary>
        /// <param name="name">表名</param>
        /// <param name="colName">属性列</param>
        /// <param name="colType">属性类型</param>
        /// <returns></returns>
        public DataSet CreateTable(string name, string[] colName, string[] colType)
        {
            if (colName.Length != colType.Length)
            {
                throw new Exception("输入不正确：" + "columns.Length!=colType.Length");
            }
            string query = "CREATE TABLE" + name + "(" + colName[0] + " " + colType[0];
            for (int i = 1; i < colName.Length; i++)
            {
                query += "," + colName[i] + " " + colType[i];
            }
            query += ")";
            return QuerySet(query);
        }
        /// <summary>
        /// 创建具有ID自增的表
        /// </summary>
        /// <param name="name">表名</param>
        /// <param name="col">属性列</param>
        /// <param name="colType">属性列类型</param>
        /// <returns></returns>
        public DataSet CreateTableAutoID(string name, string[] col, string[] colType)
        {
            if (col.Length != colType.Length)
            {
                throw new Exception("columns.Length!=colType.Length");
            }
            string query = "CREATE TABLE" + name + "(" + col[0] + " " + colType[0] + "NOT NULL AUTO_INCREMENT";

            for (int i = 1; i < col.Length; ++i)
            {
                query += "," + col[i] + " " + colType[i];
            }
            query += ",PRIMARY KEY(" + col[0] + ")" + ")";

            //Debug.Log(query);

            return QuerySet(query);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="items">需要查询的列</param>
        /// <param name="whereColName">查询的条件列</param>
        /// <param name="operation">条件操作符</param>
        /// <param name="value">条件的值</param>
        /// <returns></returns>
        public DataSet Select(string tableName, string[] items, string[] whereColName, string[] operation, string[] value)
        {
            if (whereColName.Length != operation.Length || operation.Length != value.Length)
            {
                throw new Exception("输入不正确:" + "col.Length!=operation.Length!=values.Length");
            }
            string query = "SELECT " + items[0];
            for (int i = 1; i < items.Length; i++)
            {
                query += "," + items[i];
            }
            query += " FROM " + tableName + " WHERE " + " " + whereColName[0] + operation[0] + " '" + value[0] + "'";
            for (int i = 1; i < whereColName.Length; i++)
            {
                query += " AND " + whereColName[i] + operation[i] + "' " + value[i] + "'";
            }
            return QuerySet(query);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="cols">条件：删除列</param>
        /// <param name="colsvalues">删除该列属性值所在的行</param>
        /// <returns></returns>
        public DataSet Delete(string tableName, string[] cols, string[] colsvalues)
        {
            string query = "DELETE FROM " + tableName + " WHERE " + cols[0] + " = " + colsvalues[0];
            for (int i = 1; i < colsvalues.Length; ++i)
            {
                query += " or " + cols[i] + " = " + colsvalues[i];
            }
            //Debug.Log(query);
            return QuerySet(query);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="cols">更新列</param>
        /// <param name="colsvalues">更新的值</param>
        /// <param name="selectkey">条件:列</param>
        /// <param name="selectvalue">条件:值</param>
        /// <returns></returns>
        public DataSet UpdateInto(string tableName, string[] cols, string[] colsvalues, string selectkey, string selectvalue)
        {
            string query = "UPDATE " + tableName + " SET " + cols[0] + " = " + colsvalues[0];
            for (int i = 1; i < colsvalues.Length; i++)
            {
                query += ", " + cols[i] + " =" + colsvalues[i];
            }
            query += " WHERE " + selectkey + " = " + selectvalue + " ";
            return QuerySet(query);
        }
        /// <summary>
        /// 插入一条数据，包括所有，不适用自动累加ID
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="values">插入值</param>
        /// <returns></returns>
        public DataSet InsertInto(string tableName, string[] values)
        {
            string query = "INSERT INTO " + tableName + " VALUES (" + "'" + values[0] + "'";
            for (int i = 1; i < values.Length; ++i)
            {
                query += ", " + "'" + values[i] + "'";
            }
            query += ")";
            Debug.Log(query);
            return QuerySet(query);
            ;
        }
        /// <summary>
        /// 插入部分
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="col">属性列</param>
        /// <param name="values">属性值</param>
        /// <returns></returns>
        public DataSet InsertInto(string tableName, string[] col, string[] values)
        {
            if (col.Length != values.Length)
            {
                throw new Exception("columns.Length!=colType.Length");
            }
            string query = "INSERT INTO " + tableName + " (" + col[0];
            for (int i = 1; i < col.Length; ++i)
            {
                query += ", " + col[i];
            }
            query += ")VALUES( " + "'" + values[0] + "'";
            for (int i = 1; i < values.Length; ++i)
            {
                query += ", " + "'" + values[i] + "'";
            }
            query += ")";
            //Debug.Log(query);
            return QuerySet(query);
        }
        /// <summary>
        /// 执行Sql语句
        /// </summary>
        /// <param name="sqlString">sql语句</param>
        /// <returns></returns>
        public static DataSet QuerySet(string sqlString)
        {
            if (mySqlConnection.State == ConnectionState.Open)
            {
                DataSet ds = new DataSet();
                try
                {
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sqlString, mySqlConnection);
                    mySqlDataAdapter.Fill(ds);
                }
                catch (Exception e)
                {
                    throw new Exception("SQL:" + sqlString + "/n" + e.Message.ToString());
                }
                finally
                {

                }
                return ds;
            }
            return null;
        }

        public void Close()
        {
            if (mySqlConnection != null)
            {
                mySqlConnection.Close();
                mySqlConnection.Dispose();
                mySqlConnection = null;
            }
        }
    }
}
