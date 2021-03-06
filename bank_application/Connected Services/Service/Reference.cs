﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bank_application.Service {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Service.ICountService")]
    public interface ICountService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountService/CalcCredit", ReplyAction="http://tempuri.org/ICountService/CalcCreditResponse")]
        int CalcCredit(int Duration, int Money, System.DateTime date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountService/CalcCredit", ReplyAction="http://tempuri.org/ICountService/CalcCreditResponse")]
        System.Threading.Tasks.Task<int> CalcCreditAsync(int Duration, int Money, System.DateTime date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountService/CalcDeposit", ReplyAction="http://tempuri.org/ICountService/CalcDepositResponse")]
        double CalcDeposit(int Duration, int Money, System.DateTime date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountService/CalcDeposit", ReplyAction="http://tempuri.org/ICountService/CalcDepositResponse")]
        System.Threading.Tasks.Task<double> CalcDepositAsync(int Duration, int Money, System.DateTime date);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICountServiceChannel : bank_application.Service.ICountService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CountServiceClient : System.ServiceModel.ClientBase<bank_application.Service.ICountService>, bank_application.Service.ICountService {
        
        public CountServiceClient() {
        }
        
        public CountServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CountServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CountServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CountServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int CalcCredit(int Duration, int Money, System.DateTime date) {
            return base.Channel.CalcCredit(Duration, Money, date);
        }
        
        public System.Threading.Tasks.Task<int> CalcCreditAsync(int Duration, int Money, System.DateTime date) {
            return base.Channel.CalcCreditAsync(Duration, Money, date);
        }
        
        public double CalcDeposit(int Duration, int Money, System.DateTime date) {
            return base.Channel.CalcDeposit(Duration, Money, date);
        }
        
        public System.Threading.Tasks.Task<double> CalcDepositAsync(int Duration, int Money, System.DateTime date) {
            return base.Channel.CalcDepositAsync(Duration, Money, date);
        }
    }
}
