using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poc.Tenants.Models
{
    public class Customer
    {
        [BsonElement("_id")]
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; protected set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("national_insurance_number")]
        public string Nin { get; set; }

        [BsonElement("create_at")]
        public DateTime CreateAt { get; protected set; } = DateTime.UtcNow;
    }
}
