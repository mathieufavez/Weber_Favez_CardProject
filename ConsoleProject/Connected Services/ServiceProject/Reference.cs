﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleProject.ServiceProject {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceProject.IServiceCard")]
    public interface IServiceCard {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCard/GetPersonById", ReplyAction="http://tempuri.org/IServiceCard/GetPersonByIdResponse")]
        DTO.Person GetPersonById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCard/GetPersonById", ReplyAction="http://tempuri.org/IServiceCard/GetPersonByIdResponse")]
        System.Threading.Tasks.Task<DTO.Person> GetPersonByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCard/GetPersonByUsername", ReplyAction="http://tempuri.org/IServiceCard/GetPersonByUsernameResponse")]
        DTO.Person GetPersonByUsername(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCard/GetPersonByUsername", ReplyAction="http://tempuri.org/IServiceCard/GetPersonByUsernameResponse")]
        System.Threading.Tasks.Task<DTO.Person> GetPersonByUsernameAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCard/AddMoneyToCard", ReplyAction="http://tempuri.org/IServiceCard/AddMoneyToCardResponse")]
        int AddMoneyToCard(int personID, double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCard/AddMoneyToCard", ReplyAction="http://tempuri.org/IServiceCard/AddMoneyToCardResponse")]
        System.Threading.Tasks.Task<int> AddMoneyToCardAsync(int personID, double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCard/PayCafetaria", ReplyAction="http://tempuri.org/IServiceCard/PayCafetariaResponse")]
        int PayCafetaria(int personID, double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCard/PayCafetaria", ReplyAction="http://tempuri.org/IServiceCard/PayCafetariaResponse")]
        System.Threading.Tasks.Task<int> PayCafetariaAsync(int personID, double value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceCardChannel : ConsoleProject.ServiceProject.IServiceCard, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceCardClient : System.ServiceModel.ClientBase<ConsoleProject.ServiceProject.IServiceCard>, ConsoleProject.ServiceProject.IServiceCard {
        
        public ServiceCardClient() {
        }
        
        public ServiceCardClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceCardClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceCardClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceCardClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public DTO.Person GetPersonById(int id) {
            return base.Channel.GetPersonById(id);
        }
        
        public System.Threading.Tasks.Task<DTO.Person> GetPersonByIdAsync(int id) {
            return base.Channel.GetPersonByIdAsync(id);
        }
        
        public DTO.Person GetPersonByUsername(string username) {
            return base.Channel.GetPersonByUsername(username);
        }
        
        public System.Threading.Tasks.Task<DTO.Person> GetPersonByUsernameAsync(string username) {
            return base.Channel.GetPersonByUsernameAsync(username);
        }
        
        public int AddMoneyToCard(int personID, double value) {
            return base.Channel.AddMoneyToCard(personID, value);
        }
        
        public System.Threading.Tasks.Task<int> AddMoneyToCardAsync(int personID, double value) {
            return base.Channel.AddMoneyToCardAsync(personID, value);
        }
        
        public int PayCafetaria(int personID, double value) {
            return base.Channel.PayCafetaria(personID, value);
        }
        
        public System.Threading.Tasks.Task<int> PayCafetariaAsync(int personID, double value) {
            return base.Channel.PayCafetariaAsync(personID, value);
        }
    }
}
