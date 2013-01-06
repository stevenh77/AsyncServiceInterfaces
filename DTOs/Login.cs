using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DTOs
{
    [DataContract]
    public class GetLoginRequest
    { 
        [DataMember]
        public string Payload { get; set; } 
    }

    [DataContract]
    public class GetLoginResponse 
    {
        [DataMember]
        public string Payload { get; set; }
    }

    [DataContract]
    public class UpdateLoginRequest
    {
        [DataMember]
        public string Payload { get; set; } 
    }
    
    [DataContract]
    public class UpdateLoginResponse 
    { 
        [DataMember]
        public string Payload { get; set; } 
    }
}