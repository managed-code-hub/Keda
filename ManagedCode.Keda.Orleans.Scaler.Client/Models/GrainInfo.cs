namespace ManagedCode.Keda.Orleans.Scaler.Client.Models;

public record GrainInfo(string Type, string PrimaryKey, string SiloName);