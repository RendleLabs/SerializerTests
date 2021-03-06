﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializerTests.Serializers
{
    class FastJson<T> : TestBase<T, fastJSON.JSONParameters> where T : class
    {
        public FastJson(Func<int, T> testData)
        {
            base.CreateNTestData = testData;
        }

        protected override void Serialize(T obj, Stream stream)
        {
            var text = new StreamWriter(stream);
            var jsonString = fastJSON.JSON.ToJSON(obj);
            text.WriteLine(jsonString);
            text.Flush();
        }

        protected override T Deserialize(Stream stream)
        {
            TextReader text = new StreamReader(stream);
            string fullText = text.ReadToEnd();
            var lret = fastJSON.JSON.ToObject<T>(fullText);
            return lret;
        }
    }
}
