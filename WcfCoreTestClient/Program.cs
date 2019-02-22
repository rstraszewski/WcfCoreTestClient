using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace WcfCoreTestClient
{
  class Program
  {
    [ServiceContract]
    [FooContractBehavior] //// if set here, it throws on new ChannelFactory
    public interface IFooQuery
    {
      [OperationContract]
      string GetFoo();
    }

    static void Main(string[] args)
    {
      var channel = new ChannelFactory<IFooQuery>(new NetTcpBinding(SecurityMode.None), new EndpointAddress("net.tcp://host:1234/FooQuery"));
      //// channel.Endpoint.Contract.ContractBehaviors.Add(new FooContractBehaviorAttribute()); // If set here, not as attribute, it works
      var fooQuery = channel.CreateChannel();
      fooQuery.GetFoo();
    }
  }

  internal class FooContractBehaviorAttribute : Attribute, IContractBehavior
  {
    public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
    {
    }

    public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
    {
    }

    public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
    {
    }

    public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
    {
    }
  }
}
