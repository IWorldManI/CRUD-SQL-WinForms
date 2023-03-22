using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CRUDWithWinForms.Models;

namespace CRUDWithWinForms._Repositories
{
    public class ItemRepository : BaseRepository, IItemRepository
    {
        //Constructor
        public ItemRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        //Methods
        public void Add(ItemModel itemModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into Item values (@name, @type, @colour)";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = itemModel.Name;
                command.Parameters.Add("@type", SqlDbType.NVarChar).Value = itemModel.Type;
                command.Parameters.Add("@colour", SqlDbType.NVarChar).Value = itemModel.Colour;
                command.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "delete from Item where Item_Id=@id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;           
                command.ExecuteNonQuery();
            }
        }
        public void Edit(ItemModel itemModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"update Item 
                                        set Item_Name=@name,Item_Type= @type,Item_Colour= @colour 
                                        where Item_Id=@id";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = itemModel.Name;
                command.Parameters.Add("@type", SqlDbType.NVarChar).Value = itemModel.Type;
                command.Parameters.Add("@colour", SqlDbType.NVarChar).Value = itemModel.Colour;
                command.Parameters.Add("@id", SqlDbType.Int).Value = itemModel.Id;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<ItemModel> GetAll()
        {
            var itemList = new List<ItemModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select *from Item order by Item_Id desc";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var itemModel = new ItemModel();
                        itemModel.Id = (int)reader[0];
                        itemModel.Name = reader[1].ToString();
                        itemModel.Type = reader[2].ToString();
                        itemModel.Colour = reader[3].ToString();
                        itemList.Add(itemModel);
                    }
                }
            }
            return itemList;
        }

        public IEnumerable<ItemModel> GetByValue(string value)
        {
            int id;
            var itemList = new List<ItemModel>();
            int itemId = int.TryParse(value, out id) ? Convert.ToInt32(value) : 0;
            string itemName = value;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Select *from Item
                                        where Item_Id=@id or Item_Name like @name+'%' 
                                        order by Item_Id desc";
                command.Parameters.Add("@id", SqlDbType.Int).Value = itemId;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = itemName;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var itemModel = new ItemModel();
                        itemModel.Id = (int)reader[0];
                        itemModel.Name = reader[1].ToString();
                        itemModel.Type = reader[2].ToString();
                        itemModel.Colour = reader[3].ToString();
                        itemList.Add(itemModel);
                    }
                }
            }
            return itemList;
        }
    }
}
