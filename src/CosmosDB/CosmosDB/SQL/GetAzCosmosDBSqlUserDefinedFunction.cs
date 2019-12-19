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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlUserDefinedFunction"), OutputType(typeof(PSSqlUserDefinedFunctionGetResults))]
    public class GetAzCosmosDBSqlUserDefinedFunction : AzureCosmosDBCmdletBase
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

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.UserDefinedFunctionNameHelpMessage)]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {       
            if(!string.IsNullOrEmpty(Name))
            {
                SqlUserDefinedFunctionGetResults sqlUserDefinedFunctionGetResults = CosmosDBManagementClient.SqlResources.GetSqlUserDefinedFunctionWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName, ContainerName, Name).GetAwaiter().GetResult().Body;
                WriteObject(new PSSqlUserDefinedFunctionGetResults(sqlUserDefinedFunctionGetResults));
            }
            else
            {
                IEnumerable<SqlUserDefinedFunctionGetResults> sqlUserDefinedFunctions = CosmosDBManagementClient.SqlResources.ListSqlUserDefinedFunctionsWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName, ContainerName).GetAwaiter().GetResult().Body;
                
                foreach(SqlUserDefinedFunctionGetResults sqlUserDefinedFunction in sqlUserDefinedFunctions)
                    WriteObject(new PSSqlUserDefinedFunctionGetResults(sqlUserDefinedFunction));
            }

            return;
        }
    }
}
