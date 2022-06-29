using System.Runtime.Serialization;

namespace Contracts.Models;

[DataContract]
public class AesEncryptionModel
{
    [DataMember]
    public string Key { get; set; }
}