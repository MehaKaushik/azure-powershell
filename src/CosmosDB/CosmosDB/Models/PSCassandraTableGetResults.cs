﻿// ----------------------------------------------------------------------------------
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

    public class PSCassandraTableGetResults
    {
        public PSCassandraTableGetResults()
        {
        }        
        
        public PSCassandraTableGetResults(CassandraTableGetResults cassandraTableGetResults)
        {
            Name = cassandraTableGetResults.Name;
            Id = cassandraTableGetResults.Id;
            CassandraTableGetResultsId = cassandraTableGetResults.CassandraTableGetResultsId;
            DefaultTtl = cassandraTableGetResults.DefaultTtl;
            Schema = cassandraTableGetResults.Schema;
            _rid = cassandraTableGetResults._rid;
            _ts = cassandraTableGetResults._ts;
            _etag = cassandraTableGetResults._etag;
        }

        /// <summary>
        /// Gets or sets Name of the Cosmos DB Cassandra table
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Id of the Cosmos DB Cassandra table
        /// </summary>
        public string Id { get; set; }
        //
        // Summary:
        //     Gets or sets name of the Cosmos DB Cassandra table
        public string CassandraTableGetResultsId { get; set; }
        //
        // Summary:
        //     Gets or sets time to live of the Cosmos DB Cassandra table
        public int? DefaultTtl { get; set; }
        //
        // Summary:
        //     Gets or sets schema of the Cosmos DB Cassandra table
        public CassandraSchema Schema { get; set; }
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
