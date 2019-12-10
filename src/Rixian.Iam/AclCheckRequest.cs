// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace Rixian.Iam
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Request object for checking tenant access.
    /// </summary>
    public class AclCheckRequest
    {
        /// <summary>
        /// Gets the subject IDs that will be checked for tenant access.
        /// </summary>
        [JsonProperty("subjectIds", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<string> SubjectIds { get; } = new List<string>();
    }
}
