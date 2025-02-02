﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WagerPlus.Data.Handlers
{
    public abstract class DataHandler<T> where T : new()
    {
        private readonly string _filePath;

        protected DataHandler(string fileName, string folderName)
        {
            _filePath = SetFilePath(fileName, folderName);
            InitializeFile();
        }

        private string SetFilePath(string fileName, string folderName)
        {
            string appBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(appBaseDirectory, folderName, fileName);

            // Ensure the directory exists
            string directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                Console.WriteLine($"Directory created: {directory}");
            }

            return filePath;
        }

        private void InitializeFile()
        {
            if (!File.Exists(_filePath))
            {
                Save(new T());
            }
        }

        public T Load()
        {
            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            }) ?? new T();
        }

        public void Save(T data)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
            File.WriteAllText(_filePath, json);
        }
    }
}
