// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.CosmosDB.Models;

    public class PSMongoDBCollectionGetResults
    {
        public PSMongoDBCollectionGetResults()
        {
        }        
        
        public PSMongoDBCollectionGetResults(MongoDBCollectionGetResults mongoDBCollectionGetResults)
        {
            Name = mongoDBCollectionGetResults.Name;
            Id = mongoDBCollectionGetResults.Id;         
            MongoDBCollectionGetResultsId = mongoDBCollectionGetResults.MongoDBCollectionGetResultsId;
            
            List<PSMongoIndex> psMongoIndex = new List<PSMongoIndex>();
            if (mongoDBCollectionGetResults.Indexes != null)
            {
                foreach (MongoIndex mongoIndex in mongoDBCollectionGetResults.Indexes)
                {
                    psMongoIndex.Add(new PSMongoIndex(mongoIndex));
                }
            }

            Indexes = psMongoIndex;
            _rid = mongoDBCollectionGetResults._rid;
            _ts = mongoDBCollectionGetResults._ts;
            _etag = mongoDBCollectionGetResults._etag;
        }

        /// <summary>
        /// Gets or sets Name of the Cosmos DB MongoDB Collection 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Id of the Cosmos DB MongoDB Collection
        /// </summary>
        public string Id { get; set; }
        //
        // Summary:
        //     Gets or sets name of the Cosmos DB MongoDB collection
        public string MongoDBCollectionGetResultsId { get; set; }
        //
        // Summary:
        //     Gets or sets a key-value pair of shard keys to be applied for the request.
        public IDictionary<string, string> ShardKey { get; set; }
        //
        // Summary:
        //     Gets or sets list of index keys
        public IList<PSMongoIndex> Indexes { get; set; }
        //
        // Summary:
        //     Gets a system generated property. A unique identifier.
        public string _rid { get; set; }
        //
        // Summary:
        //     Gets a system generated property that denotes the last updated timestamp of the
        //     resource.
        public object _ts { get; set; }
        //
        // Summary:
        //     Gets a system generated property representing the resource etag required for
        //     optimistic concurrency control.
        public string _etag { get; set; }
    }
}
