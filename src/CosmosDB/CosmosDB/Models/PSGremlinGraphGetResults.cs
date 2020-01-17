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
    using Microsoft.Azure.Management.CosmosDB.Models;

    public class PSGremlinGraphGetResults
    {
        public PSGremlinGraphGetResults()
        {
        }        
        
        public PSGremlinGraphGetResults(GremlinGraphGetResults gremlinGraphGetResults)
        {
            Name = gremlinGraphGetResults.Name;
            Id = gremlinGraphGetResults.Id;
            GremlinGraphGetResultsId = gremlinGraphGetResults.GremlinGraphGetResultsId;
            IndexingPolicy = gremlinGraphGetResults.IndexingPolicy;
            PartitionKey = gremlinGraphGetResults.PartitionKey;
            DefaultTtl = gremlinGraphGetResults.DefaultTtl;
            UniqueKeyPolicy = gremlinGraphGetResults.UniqueKeyPolicy;
            ConflictResolutionPolicy = gremlinGraphGetResults.ConflictResolutionPolicy;
            _rid = gremlinGraphGetResults._rid;
            _ts = gremlinGraphGetResults._ts;
            _etag = gremlinGraphGetResults._etag;
        }

        /// <summary>
        /// Gets or sets Name of the Cosmos DB Gremlin graph
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Id of the Cosmos DB Gremlin graph
        /// </summary>
        public string Id { get; set; }
        //
        // Summary:
        //     Gets or sets name of the Cosmos DB Gremlin graph
        public string GremlinGraphGetResultsId { get; set; }
        //
        // Summary:
        //     Gets or sets the configuration of the indexing policy. By default, the indexing
        //     is automatic for all document paths within the graph
        public IndexingPolicy IndexingPolicy { get; set; }
        //
        // Summary:
        //     Gets or sets the configuration of the partition key to be used for partitioning
        //     data into multiple partitions
        public ContainerPartitionKey PartitionKey { get; set; }
        //
        // Summary:
        //     Gets or sets default time to live
        public int? DefaultTtl { get; set; }
        //
        // Summary:
        //     Gets or sets the unique key policy configuration for specifying uniqueness constraints
        //     on documents in the collection in the Azure Cosmos DB service.
        public UniqueKeyPolicy UniqueKeyPolicy { get; set; }
        //
        // Summary:
        //     Gets or sets the conflict resolution policy for the graph.
        public ConflictResolutionPolicy ConflictResolutionPolicy { get; set; }
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
