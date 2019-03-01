using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using NUnit.Framework;
using RealEstate.Rentals;
using System;
using System.Collections.Generic;

namespace RealEstate.Test
{
    [TestFixture]
    public class RentalTests : AssertionHelper
    {
        public RentalTests()
        {
            JsonWriterSettings.Defaults.Indent = true;
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ToDocument_RentalWithPrice_PriceRepresentedAsDouble()
        {
            var rental = new Rental
            {
                Price = 1
            };

            var document = rental.ToBsonDocument();

            Expect(document["Price"].BsonType, Is.EqualTo(BsonType.Double));
        }

        [Test]
        public void ToDocument_RentalWithAnId_IdIsRepresentedAsObjectId()
        {
            var rental = new Rental
            {
                Id = ObjectId.GenerateNewId().ToString()
            };

            var document = rental.ToBsonDocument();

            Expect(document["_id"].BsonType, Is.EqualTo(BsonType.ObjectId));
        }
    }
}