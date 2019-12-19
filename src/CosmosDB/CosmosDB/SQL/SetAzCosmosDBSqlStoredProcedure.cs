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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlStoredProcedure", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSSqlStoredProcedureGetResults))]
    public class SetAzCosmosDBSqlStoredProcedure : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.DatabaseNameHelpMessage)]
        public string DatabaseName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ContainerNameHelpMessage)]
        public string ContainerName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.StoredProcedureNameHelpMessage)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.StoredProcedureBodyHelpMessage)]
        public string Body { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.SqlContainerObjectHelpMessage)]
        public PSSqlContainerGetResults InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            //if(ParameterSetName.Equals(ParentObjectParameterSet))
            //{
            //    ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
            //    ResourceGroupName = resourceIdentifier.ResourceGroupName;
            //    ContainerName = resourceIdentifier.ResourceName;
            //    DatabaseName = resourceIdentifier.ParentResource;
            //}

            SqlStoredProcedureCreateUpdateParameters sqlStoredProcedureCreateUpdateParameters = new SqlStoredProcedureCreateUpdateParameters
            {
                Resource = new SqlStoredProcedureResource
                {
                    Id = Name,
                    Body = Body
                },
                Options = new Dictionary<string, string>() { }
            };

            SqlStoredProcedureGetResults sqlStoredProcedureGetResults = CosmosDBManagementClient.SqlResources.CreateUpdateSqlStoredProcedureWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName, ContainerName, Name, sqlStoredProcedureCreateUpdateParameters).GetAwaiter().GetResult().Body;
            WriteObject(new PSSqlStoredProcedureGetResults(sqlStoredProcedureGetResults));

            return;
        }
    }
}
