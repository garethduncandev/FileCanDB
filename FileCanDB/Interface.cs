﻿using System.Collections.Generic;
namespace Duncan.FileCanDB
{
    public interface IFileCanDB
    {
        /// <summary>
        /// Inserts object into collection. If password is provided the enum StorageMethod value will be changed to "encrypted".
        /// </summary>
        /// <typeparam name="T">Type of object to store in the database</typeparam>
        /// <param name="ObjectData">The object to store in the database</param>
        /// <returns>Returns an ID of the newly inserted object into the database</returns>
        string InsertObject<T>(T ObjectData, string Area, string Collection, string FileName = "", string Password = "", List<string> KeyWords = null);

        /// <summary>
        /// Update an object in the database
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="ObjectId"></param>
        /// <param name="ObjectData"></param>
        /// <param name="Area"></param>
        /// <param name="Collection"></param>
        /// <param name="Password"></param>
        /// <param name="KeyWords"></param>
        /// <returns>bool: Returns true if the object is updated successfully</returns>
        bool UpdateObject<T>(string ObjectId, T ObjectData, string Area, string Collection, string Password = "", List<string> KeyWords = null);

        /// <summary>
        /// Deletes an object from the database
        /// </summary>
        /// <param name="ObjectId">Object ID</param>
        /// <param name="Area">Database ID</param>
        /// <param name="Collection">Collection ID</param>
        /// <returns>Returns true if file has been deleted</returns>
        bool DeleteObject(string ObjectId, string Area, string Collection);

        /// <summary>
        /// Get an object from the database. If the Password is provided, the enum StorageMethod value will changed to "encrypted"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ObjectId">Object ID</param>
        /// <param name="Area">Database ID</param>
        /// <param name="Collection">Collection ID</param>
        /// <param name="Password">Optional password parametert to enable encryption</param>
        /// <returns>Object stored in database</returns>
        T GetObject<T>(string ObjectId, string Area, string Collection, string Password = "");

        /// <summary>
        /// Retrieves all objects in a collection in a database
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="Area">Database Id</param>
        /// <param name="Collection">Collection Id</param>
        /// <param name="Password">Optional password parametert to enable encryption</param>
        /// <returns></returns>
        IList<T> GetObjects<T>(string Area, string Collection, int skip, int take, string Password = "");

        /// <summary>
        /// Delete a database from the system
        /// </summary>
        /// <param name="Area">Database Id</param>
        /// <returns></returns>
        bool DeleteDatabase(string Area);

        /// <summary>
        /// Delete an entire collection from the database
        /// </summary>
        /// <param name="Area">Database Id</param>
        /// <param name="Collection">Collection Id</param>
        /// <returns>Returns true if the collection was deleted</returns>
        bool DeleteCollection(string Area, string Collection);

        /// <summary>
        /// List all collection ids in a Database
        /// </summary>
        /// <param name="Area"></param>
        /// <returns>List of collection ids</returns>
        IList<string> GetCollections(string Area);

        /// <summary>
        /// Counts the number of collections in a database
        /// </summary>
        /// <param name="Area"></param>
        /// <returns>Returns a </returns>
        int DatabaseCollectionsCount(string Area);

        /// <summary>
        /// Counts the number of objects in a collection
        /// </summary>
        /// <param name="Area"></param>
        /// <param name="Collection"></param>
        /// <returns>An interger value representing the number of objects in a collection</returns>
        int CollectionObjectsCount(string Area, string Collection);

        /// <summary>
        /// Returns a list of object ids in a collection
        /// </summary>
        /// <param name="Area">Database Id</param>
        /// <param name="Collection">Collection Id</param>
        /// <param name="skip">Number of objects to skip</param>
        /// <param name="take">Number of objects to take</param>
        /// <returns></returns>
        IEnumerable<string> ListObjects(string Area, string Collection, int skip, int take);

        /// <summary>
        /// Find objects in a collection using the index file
        /// </summary>
        /// <param name="query">Space separated list of strings to query</param>
        /// <param name="Area">Database Id</param>
        /// <param name="Collection">Collection Id</param>
        /// <param name="skip">Number of objects to skip</param>
        /// <param name="take">Number of objects to take</param>
        /// <returns></returns>
        IList<string> FindObjectsUsingKeywords(string query, string Area, string Collection, int skip, int take);

        string GenerateFileName();
    }
}
