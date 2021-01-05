//
// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.
//

// Warning: This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    public abstract class ComputeAutomationBaseCmdlet : Microsoft.Azure.Commands.Compute.ComputeClientBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        protected static PSArgument[] ConvertFromObjectsToArguments(string[] names, object[] objects)
        {
            var arguments = new PSArgument[objects.Length];

            for (int index = 0; index < objects.Length; index++)
            {
                arguments[index] = new PSArgument
                {
                    Name = names[index],
                    Type = objects[index].GetType(),
                    Value = objects[index]
                };
            }

            return arguments;
        }

        protected static object[] ConvertFromArgumentsToObjects(object[] arguments)
        {
            if (arguments == null)
            {
                return null;
            }

            var objects = new object[arguments.Length];

            for (int index = 0; index < arguments.Length; index++)
            {
                if (arguments[index] is PSArgument)
                {
                    objects[index] = ((PSArgument)arguments[index]).Value;
                }
                else
                {
                    objects[index] = arguments[index];
                }
            }

            return objects;
        }

        public IContainerServicesOperations ContainerServicesClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.ContainerServices;
            }
        }

        public IDedicatedHostGroupsOperations DedicatedHostGroupsClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.DedicatedHostGroups;
            }
        }

        public IDedicatedHostsOperations DedicatedHostsClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.DedicatedHosts;
            }
        }

        public IDiskEncryptionSetsOperations DiskEncryptionSetsClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.DiskEncryptionSets;
            }
        }

        public IDisksOperations DisksClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.Disks;
            }
        }

        public IDiskAccessesOperations DiskAccessesClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.DiskAccesses;
            }
        }

        public IGalleriesOperations GalleriesClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.Galleries;
            }
        }

        public IGalleryImagesOperations GalleryImagesClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.GalleryImages;
            }
        }

        public IGalleryImageVersionsOperations GalleryImageVersionsClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.GalleryImageVersions;
            }
        }

        public IImagesOperations ImagesClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.Images;
            }
        }

        public ILogAnalyticsOperations LogAnalyticsClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.LogAnalytics;
            }
        }

        public IProximityPlacementGroupsOperations ProximityPlacementGroupsClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.ProximityPlacementGroups;
            }
        }

        public IResourceSkusOperations ResourceSkusClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.ResourceSkus;
            }
        }

        public ISnapshotsOperations SnapshotsClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.Snapshots;
            }
        }

        public IVirtualMachineRunCommandsOperations VirtualMachineRunCommandsClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.VirtualMachineRunCommands;
            }
        }

        public IVirtualMachineScaleSetRollingUpgradesOperations VirtualMachineScaleSetRollingUpgradesClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.VirtualMachineScaleSetRollingUpgrades;
            }
        }

        public IVirtualMachineScaleSetsOperations VirtualMachineScaleSetsClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.VirtualMachineScaleSets;
            }
        }

        public IVirtualMachineScaleSetVMExtensionsOperations VirtualMachineScaleSetVMExtensionsClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.VirtualMachineScaleSetVMExtensions;
            }
        }

        public IVirtualMachineScaleSetVMsOperations VirtualMachineScaleSetVMsClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.VirtualMachineScaleSetVMs;
            }
        }

        public IVirtualMachinesOperations VirtualMachinesClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.VirtualMachines;
            }
        }

        public static string FormatObject(Object obj)
        {
            var objType = obj.GetType();

            System.Reflection.PropertyInfo[] pros = objType.GetProperties();
            string result = "\n";
            var resultTuples = new List<Tuple<string, string, int>>();
            var totalTab = GetTabLength(obj, 0, 0, resultTuples) + 1;
            foreach (var t in resultTuples)
            {
                string preTab = new string(' ', t.Item3 * 2);
                string postTab = new string(' ', totalTab - t.Item3 * 2 - t.Item1.Length);

                result += preTab + t.Item1 + postTab + ": " + t.Item2 + "\n";
            }
            return result;
        }

        private static int GetTabLength(Object obj, int max, int depth, List<Tuple<string, string, int>> tupleList)
        {
            var objType = obj.GetType();
            var propertySet = new List<PropertyInfo>();
            if (objType.BaseType != null)
            {
                foreach (var property in objType.BaseType.GetProperties())
                {
                    propertySet.Add(property);
                }
            }
            foreach (var property in objType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public))
            {
                propertySet.Add(property);
            }

            foreach (var property in propertySet)
            {
                Object childObject = property.GetValue(obj, null);

                var isJObject = childObject as Newtonsoft.Json.Linq.JObject;
                if (isJObject != null)
                {
                    var objStringValue = Newtonsoft.Json.JsonConvert.SerializeObject(childObject);

                    int i = objStringValue.IndexOf("xmlCfg");
                    if (i >= 0)
                    {
                        var xmlCfgString = objStringValue.Substring(i + 7);
                        int start = xmlCfgString.IndexOf('"');
                        int end = xmlCfgString.IndexOf('"', start + 1);
                        xmlCfgString = xmlCfgString.Substring(start + 1, end - start - 1);
                        objStringValue = objStringValue.Replace(xmlCfgString, "...");
                    }

                    tupleList.Add(MakeTuple(property.Name, objStringValue, depth));
                    max = Math.Max(max, depth * 2 + property.Name.Length);
                }
                else
                {
                    var elem = childObject as IList;
                    if (elem != null)
                    {
                        if (elem.Count != 0)
                        {
                            max = Math.Max(max, depth * 2 + property.Name.Length + 4);
                            for (int i = 0; i < elem.Count; i++)
                            {
                                Type propType = elem[i].GetType();

                                if (propType.IsSerializable || propType.Equals(typeof(Newtonsoft.Json.Linq.JObject)))
                                {
                                    tupleList.Add(MakeTuple(property.Name + "[" + i + "]", elem[i].ToString(), depth));
                                }
                                else
                                {
                                    tupleList.Add(MakeTuple(property.Name + "[" + i + "]", "", depth));
                                    max = Math.Max(max, GetTabLength((Object)elem[i], max, depth + 1, tupleList));
                                }
                            }
                        }
                    }
                    else
                    {
                        if (property.PropertyType.IsSerializable)
                        {
                            if (childObject != null)
                            {
                                tupleList.Add(MakeTuple(property.Name, childObject.ToString(), depth));
                                max = Math.Max(max, depth * 2 + property.Name.Length);
                            }
                        }
                        else
                        {
                            var isDictionary = childObject as IDictionary;
                            if (isDictionary != null)
                            {
                                tupleList.Add(MakeTuple(property.Name, Newtonsoft.Json.JsonConvert.SerializeObject(childObject), depth));
                                max = Math.Max(max, depth * 2 + property.Name.Length);
                            }
                            else if (childObject != null)
                            {
                                tupleList.Add(MakeTuple(property.Name, "", depth));
                                max = Math.Max(max, GetTabLength(childObject, max, depth + 1, tupleList));
                            }
                        }
                    }
                }
            }
            return max;
        }

        private static Tuple<string, string, int> MakeTuple(string key, string value, int depth)
        {
            return new Tuple<string, string, int>(key, value, depth);
        }

        public static string GetResourceGroupName(string resourceId)
        {
            if (string.IsNullOrEmpty(resourceId)) { return null; }
            Regex r = new Regex(@"(.*?)/resourcegroups/(?<rgname>\S+)/providers/(.*?)", RegexOptions.IgnoreCase);
            Match m = r.Match(resourceId);
            return m.Success ? m.Groups["rgname"].Value : null;
        }

        public static string GetResourceName(string resourceId, string resourceName, string instanceName = null, string version = null)
        {
            if (string.IsNullOrEmpty(resourceId)) { return null; }
            Regex r = (instanceName == null && version == null)
                      ? new Regex(@"(.*?)/" + resourceName + @"/(?<rgname>\S+)", RegexOptions.IgnoreCase)
                      : new Regex(@"(.*?)/" + resourceName + @"/(?<rgname>\S+)/" + instanceName + @"/(?<instanceId>\S+)", RegexOptions.IgnoreCase);
            Match m = r.Match(resourceId);
            return m.Success ? m.Groups["rgname"].Value : null;
        }

        public static string GetInstanceId(string resourceId, string resourceName, string instanceName, string version = null)
        {
            if (string.IsNullOrEmpty(resourceId)) { return null; }
            Regex r = (version == null)
                    ? new Regex(@"(.*?)/" + resourceName + @"/(?<rgname>\S+)/" + instanceName + @"/(?<instanceId>\S+)", RegexOptions.IgnoreCase)
                    : new Regex(@"(.*?)/" + resourceName + @"/(?<rgname>\S+)/" + instanceName + @"/(?<instanceId>\S+)/" + version + @"/(?<version>\S+)", RegexOptions.IgnoreCase);
            Match m = r.Match(resourceId);
            return m.Success ? m.Groups["instanceId"].Value : null;
        }

        public static string GetVersion(string resourceId, string resourceName, string instanceName, string version)
        {
            if (string.IsNullOrEmpty(resourceId)) { return null; }
            Regex r = new Regex(@"(.*?)/" + resourceName + @"/(?<rgname>\S+)/" + instanceName + @"/(?<instanceId>\S+)/" + version + @"/(?<version>\S+)", RegexOptions.IgnoreCase);
            Match m = r.Match(resourceId);
            return m.Success ? m.Groups["version"].Value : null;
        }
    }
    public static class LocationStringExtensions
    {
        public static string Canonicalize(this string location)
        {
            if (!string.IsNullOrEmpty(location))
            {
                StringBuilder sb = new StringBuilder();
                foreach (char ch in location)
                {
                    if (!char.IsWhiteSpace(ch))
                    {
                        sb.Append(ch);
                    }
                }

                location = sb.ToString().ToLower();
            }

            return location;
        }
    }
}
