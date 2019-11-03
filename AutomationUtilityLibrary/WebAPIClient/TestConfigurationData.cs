using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AutomationUtilityLibrary.WebAPIClient
{
    [DataContract(Name = "testconfigdata")]
    public class TestConfigurationData
    {
        [DataMember(Name = "profile")]
        public string Profile { get; set; }

        [DataMember(Name = "cloudservice")]
        public string CloudService { get; set; }

        [DataMember(Name = "accountusername")]
        public string AccountUserName { get; set; }

        [DataMember(Name = "accesskey")]
        public string AccessKey { get; set; }

        [DataMember(Name = "server")]
        public string Server { get; set; }

    }
}
