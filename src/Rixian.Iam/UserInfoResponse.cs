// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace Rixian.Iam
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Response object when getting the users information.
    /// </summary>
    public class UserInfoResponse
    {
        /// <summary>
        /// Gets or sets the tenantss that the user can access.
        /// </summary>
        [JsonProperty("tenants", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyCollection<Tenant> Tenants { get; set; }

        /// <summary>
        /// Gets or sets the subject ID of the user.
        /// </summary>
        [JsonProperty("subjectId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SubjectId { get; set; }

        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        [JsonProperty("email", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the users email has been confirmed.
        /// </summary>
        [JsonProperty("emailConfirmed", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool EmailConfirmed { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        [JsonProperty("userName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the user.
        /// </summary>
        [JsonProperty("phone", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the users phone number has been confirmed.
        /// </summary>
        [JsonProperty("phoneConfirmed", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool PhoneConfirmed { get; set; }
    }
}
