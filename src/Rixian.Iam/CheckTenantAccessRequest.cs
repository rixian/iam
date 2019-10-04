// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace Rixian.Iam
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Request object for checking tenant access.
    /// </summary>
    public class CheckTenantAccessRequest
    {
        /// <summary>
        /// Gets or sets the subject IDs that will be checked for tenant access.
        /// </summary>
        [JsonProperty("userIds", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
#pragma warning disable CA2227 // Collection properties should be read only
        public ICollection<string> SubjectIds { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
